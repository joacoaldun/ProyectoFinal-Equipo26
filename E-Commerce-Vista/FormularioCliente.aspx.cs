using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Vista
{
    public partial class FormularioCliente : System.Web.UI.Page
    {

        public bool confirmarEliminar { get; set; }
        public bool modificando { get; set; }

        public bool verId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            txtId.Enabled = false;
            try
            {

                confirmarEliminar = false;
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";


                if (id == "")
                {
                    verId = false;
                    modificando = false;
                }
                else
                {

                    verId = true;
                    modificando = true;

                }


                if (!IsPostBack)
                {



                  

                    //bool estado = true;
                    //txtPublicar.Text = estado.ToString();

                    List<string> valores = new List<string>();
                    valores.Add("Alta");
                    valores.Add("Baja");
                    ddlBajaLogica.DataSource = valores;
                    ddlBajaLogica.DataBind();

                    if (id != "")
                    {


                       UsuarioNegocio negocio = new UsuarioNegocio();
                        List<Cliente> temporal = negocio.listarClientesConSp();

                        Cliente seleccionada = temporal.Find(x => x.Id == int.Parse(id));

                       

                        txtId.Text = seleccionada.Id.ToString();
                        txtId.ReadOnly = true;
                        txtNombre.Text = seleccionada.Nombre;
                        txtApellido.Text = seleccionada.Apellido;
                        txtUserName.Text = seleccionada.UserName;
                        txtEmail.Text = seleccionada.Email;
                        txtDni.Text = seleccionada.Dni;
                       txtFechaNacimiento.Text = seleccionada.FechaNacimiento.ToString();



                        //txtPublicar.Text= seleccionada.Estado.ToString();
                        string estado = seleccionada.EstadoActivo ? "Alta" : "Baja";
                        ddlBajaLogica.SelectedValue = estado;

                       

                        //txtImagenUrl.Text = seleccionada.Imagenes.Url
                        txtNombre.CssClass = "form-control is-valid";
                        txtApellido.CssClass = "form-control is-valid";
                        txtUserName.CssClass = "form-control is-valid";
                        txtEmail.CssClass = "form-control is-valid";
                        txtDni.CssClass = "form-control is-valid";

                  


                        modificando = true;
                        updatePanelCliente.Update();

                    }

                    

                   

                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }

        }

        public bool validarFormulario()
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(txtApellido.Text.Trim()))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {

                return false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {

                return false;

            }
            else if (string.IsNullOrEmpty(txtDni.Text.Trim()))
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                txtNombre.CssClass = "form-control is-invalid";
            }
            else
            {
                txtNombre.CssClass = "form-control is-valid";
            }
            updatePanelCliente.Update();
        }


        protected void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtApellido.Text.Trim()))
            {
                txtApellido.CssClass = "form-control is-invalid";
            }
            else
            {
                txtApellido.CssClass = "form-control is-valid";
            }
            updatePanelCliente.Update();
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                txtUserName.CssClass = "form-control is-invalid";
            }
            else
            {
                txtUserName.CssClass = "form-control is-valid";
            }
            updatePanelCliente.Update();
        }
        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                txtEmail.CssClass = "form-control is-invalid";
            }
            else
            {
                txtEmail.CssClass = "form-control is-valid";
            }
            updatePanelCliente.Update();
        }

        protected void txtDni_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDni.Text.Trim()))
            {
                    txtDni.CssClass = "form-control is-invalid";
                errorDni.InnerText = "Campo obligatorio";
            }
            else
            {
                txtDni.CssClass = "form-control is-valid";
            }


            if (!soloNumeros(txtDni.Text))
            {
                txtDni.CssClass = "form-control is-invalid";
                errorDni.InnerText = "Ingrese un campo numérico.";
            }
            else
            {
                txtDni.CssClass = "form-control is-valid";
            }
            int stock;
            if (int.TryParse(txtDni.Text, out stock))
            {
                if (stock < 0)
                {
                    txtDni.CssClass = "form-control is-invalid";
                    errorDni.InnerText = "Ingrese un valor positivo.";
                }
                else
                {
                    txtDni.CssClass = "form-control is-valid";
                }
            }


            updatePanelCliente.Update();
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if ((char.IsNumber(caracter)))
                    return true;
            }
            return false;
        }


      





        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (validarFormulario())
                {



                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    Cliente cliente = new Cliente();




                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.UserName = txtUserName.Text;
                    cliente.Email = txtEmail.Text;
                    cliente.Dni = txtDni.Text;
                    cliente.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                    //articulo.Estado = bool.Parse(txtPublicar.Text);
                    if (ddlBajaLogica.Text == "Alta")
                    {
                        cliente.EstadoActivo = true;
                    }
                    else
                    {
                        cliente.EstadoActivo = false;
                    }
                    //articulo.Estado = bool.Parse(ddlPublicar.Text);





                    //SI NO TIENE ID ES PARA CREAR UN NUEVO ARTICULO Y SUS IMAGENES
                    if (id == "")
                    {

                    }

                }




                else
                {
                    return;
                }

               
                Response.Redirect("GestionCliente.aspx?id=1", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }

    }
}