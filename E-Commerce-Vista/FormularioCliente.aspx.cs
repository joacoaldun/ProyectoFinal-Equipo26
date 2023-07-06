using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Vista
{
    public partial class FormularioCliente : System.Web.UI.Page
    {

        
        public bool modificando { get; set; }

        public bool verId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            txtId.Enabled = false;
            try
            {

               
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
                        txtMostrarFecha.Text = seleccionada.FechaNacimiento.ToString("dd/MM/yyyy");
                        

                        //txtPublicar.Text= seleccionada.Estado.ToString();
                        string estado = seleccionada.EstadoActivo ? "Alta" : "Baja";
                        ddlBajaLogica.SelectedValue = estado;

                       

                      
                        txtNombre.CssClass = "form-control is-valid";
                        txtApellido.CssClass = "form-control is-valid";
                        txtUserName.CssClass = "form-control is-valid";
                        txtEmail.CssClass = "form-control is-valid";
                        txtDni.CssClass = "form-control is-valid";
                        txtMostrarFecha.CssClass = "form-control is-valid";
                  


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
            else if (string.IsNullOrEmpty(txtMostrarFecha.Text.Trim()))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool validarPass() {

            if (Request.QueryString["id"] != null)
            {


                return true;

            }
            else if (string.IsNullOrEmpty(txtPass.Text.Trim()))
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
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                txtEmail.CssClass = "form-control is-invalid";
               
            }
            else if (!IsinvalidEmail(email))
            {
                txtEmail.CssClass = "form-control is-invalid";
               errorEmail.InnerHtml = "Formato inválido: El correo electrónico no es válido.";
              
            }
            else
            {
                txtEmail.CssClass = "form-control is-valid";
                errorEmail.InnerHtml = "";
            }

            updatePanelCliente.Update();
        }

        protected void txtMostrarFecha_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMostrarFecha.Text.Trim()))
            {
                txtMostrarFecha.CssClass = "form-control is-invalid";
            }
            else
            {
                txtMostrarFecha.CssClass = "form-control is-valid";
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
            


            updatePanelCliente.Update();
        }
        protected void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Text.Trim()))
            {
                txtPass.CssClass = "form-control is-invalid";
            }
            else
            {
                txtPass.CssClass = "form-control is-valid";
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

                if (validarFormulario() || validarPass())
                {



                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    Cliente cliente = new Cliente();




                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.UserName = txtUserName.Text;
                    cliente.Email = txtEmail.Text;
                    cliente.Dni = txtDni.Text;
                    cliente.FechaNacimiento = DateTime.Parse(txtMostrarFecha.Text);
                    cliente.Pass = txtPass.Text;

                    

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
                        string codigoValidacion = generarCodigo();
                        cliente.CodigoValidacion = codigoValidacion;
                        usuarioNegocio.agregarClienteConSp(cliente);
                    }
                    else
                    {
                        cliente.Id = int.Parse(id); 
                        usuarioNegocio.ModificarClienteConSp(cliente);


                    }

                }




                else
                {
                    return;
                }

               
                Response.Redirect("GestionUsuarios.aspx?id=1", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }


        public string generarCodigo()
        {

            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int longitudCodigo = 8;

            Random random = new Random();
            StringBuilder codigo = new StringBuilder();

            for (int i = 0; i < longitudCodigo; i++)
            {
                int indice = random.Next(caracteres.Length);
                codigo.Append(caracteres[indice]);
            }

            return codigo.ToString();
        }

        protected void txtFechaNacimiento_TextChanged(object sender, EventArgs e)
        {
            DateTime prueba = Convert.ToDateTime(txtFechaNacimiento.Text);

            txtMostrarFecha.Text = prueba.ToString("dd/MM/yyyy");

            txtMostrarFecha.CssClass = "form-control is-valid";
        }

      

        private bool IsinvalidEmail(string email)
        {
            // Utilizar expresión regular para validar el formato del correo electrónico
            string pattern = @"\A(?:[a-zA-Z0-9_\.]+@(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-]*[a-zA-Z0-9])?)\Z";





            return Regex.IsMatch(email, pattern);
            

            
        }


    }
}