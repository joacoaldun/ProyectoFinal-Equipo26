using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Vista
{


    public partial class FormularioAdmin : System.Web.UI.Page
    {

        public bool modificando { get; set; }

        public bool verId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("Default.aspx",false);

            }

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
                        List<Admin> temporal = negocio.listarAdminsConSp();

                        Admin seleccionada = temporal.Find(x => x.Id == int.Parse(id));



                        txtId.Text = seleccionada.Id.ToString();
                        txtId.ReadOnly = true;
                        txtNombre.Text = seleccionada.Nombre;
                        txtApellido.Text = seleccionada.Apellido;
                        txtUserName.Text = seleccionada.UserName;
                        txtEmail.Text = seleccionada.Email;



                        //txtPublicar.Text= seleccionada.Estado.ToString();
                        string estado = seleccionada.EstadoActivo ? "Alta" : "Baja";
                        ddlBajaLogica.SelectedValue = estado;




                        txtNombre.CssClass = "form-control is-valid";
                        txtApellido.CssClass = "form-control is-valid";
                        txtUserName.CssClass = "form-control is-valid";
                        txtEmail.CssClass = "form-control is-valid";
                        ;



                        modificando = true;
                        updatePanelAdmin.Update();

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

            else
            {
                return true;
            }

        }

        public bool validarPass()
        {

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
            updatePanelAdmin.Update();
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
            updatePanelAdmin.Update();
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
            updatePanelAdmin.Update();
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

            updatePanelAdmin.Update();
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
            updatePanelAdmin.Update();

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
                    Admin admin = new Admin();




                    admin.Nombre = txtNombre.Text;
                    admin.Apellido = txtApellido.Text;
                    admin.UserName = txtUserName.Text;
                    admin.Email = txtEmail.Text;

                    admin.Pass = txtPass.Text;
                    //articulo.Estado = bool.Parse(txtPublicar.Text);
                    if (ddlBajaLogica.Text == "Alta")
                    {
                        admin.EstadoActivo = true;
                    }
                    else
                    {
                        admin.EstadoActivo = false;
                    }
                    //articulo.Estado = bool.Parse(ddlPublicar.Text);





                    //SI NO TIENE ID ES PARA CREAR UN NUEVO ARTICULO Y SUS IMAGENES
                    if (id == "")
                    {
                        usuarioNegocio.agregarAdminConSp(admin);
                    }
                    else
                    {
                        admin.Id = int.Parse(id);
                        usuarioNegocio.ModificarAdminConSp(admin);


                    }

                }




                else
                {
                    return;
                }


                Response.Redirect("GestionUsuarios.aspx?id=2", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }





        private bool IsinvalidEmail(string email)
        {
            // Utilizar expresión regular para validar el formato del correo electrónico
            string pattern = @"\A(?:[a-zA-Z0-9_\.]+@(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\-]*[a-zA-Z0-9])?)\Z";





            return Regex.IsMatch(email, pattern);



        }


    }
}


    
