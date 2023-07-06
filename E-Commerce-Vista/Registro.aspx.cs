using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Diagnostics.Eventing.Reader;

namespace E_Commerce_Vista
{
    public partial class Registro : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {


            txtPass.Attributes["value"] = txtPass.Text;

            txtConfirmarPass.Attributes["value"] = txtConfirmarPass.Text;


        }

        public bool validarFormulario()
        {

            if (txtNombre.CssClass == "form-control is-invalid")
            {

                return false;

            }
            else if (txtApellido.CssClass == "form-control is-invalid")
            {
                return false;
            }
            else if (txtUserName.CssClass == "form-control is-invalid")
            {
                return false;
            }
            else if (txtEmail.CssClass == "form-control is-invalid")
            {
                return false;
            }
            else if (txtMostrarFecha.CssClass == "form-control is-invalid")
            {
                return false;
            }
            else if (txtDni.CssClass == "form-control is-invalid")
            {
                return false;
            }
            else if (txtPass.CssClass == "form-control is-invalid")
            {
                return false;
            }
            else if (txtConfirmarPass.CssClass == "form-control is-invalid")
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
            else if (usernameEnUso(txtUserName.Text))
            {

                txtUserName.CssClass = "form-control is-invalid";
                errorUsername.InnerText = "Este Username ya se encuentra en uso, ingrese otro";

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
                errorEmail.InnerText = "Formato inválido: El correo electrónico no es válido.";

            }
            else if (mailEnUso(email))
            {

                txtEmail.CssClass = "form-control is-invalid";
                errorEmail.InnerText = "Ese Email ya esta en uso, seleccione otro";


            }
            else
            {
                txtEmail.CssClass = "form-control is-valid";
                errorEmail.InnerText = "";
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
            else if (txtPass.Text.Length < 8)
            {
                txtPass.CssClass = "form-control is-invalid";
                errorPass.InnerText = "La contraseña debe tener al menos 8 caracteres";

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

        private bool mailEnUso(string email)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            List<Admin> usuarios = negocio.listarMailYUsernameConSp();


            foreach (var emailClientes in usuarios)
            {

                if (emailClientes.Email == email)
                {
                    return true;
                }

            }


            return false;
        }


        private bool usernameEnUso(string username)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            List<Admin> usuarios = negocio.listarMailYUsernameConSp();


            foreach (var usernameClientes in usuarios)
            {

                if (usernameClientes.UserName == username)
                {
                    return true;
                }

            }


            return false;
        }

        protected void ConfirmarPass_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtConfirmarPass.Text.Trim()))
            {
                txtConfirmarPass.CssClass = "form-control is-invalid";
            }
            else if (txtPass.Text != txtConfirmarPass.Text)
            {
                txtConfirmarPass.CssClass = "form-control is-invalid";
                errorConfirmarPass.InnerText = "Las contraseñas no coinciden, intente nuevamente";

            }

            else
            {
                txtConfirmarPass.CssClass = "form-control is-valid";
            }
            updatePanelCliente.Update();

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                if (validarFormulario())
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Cliente cliente = new Cliente();


                    cliente.Nombre = txtNombre.Text;

                    cliente.Apellido = txtApellido.Text;

                    cliente.UserName = txtUserName.Text;

                    cliente.Pass = txtConfirmarPass.Text;

                    cliente.Dni = txtDni.Text;

                    cliente.Email = txtEmail.Text;

                    cliente.FechaNacimiento = DateTime.Parse(txtMostrarFecha.Text);

                    cliente.EstadoActivo = true;


                    negocio.agregarClienteConSp(cliente);

                    //Enviamos mail de bienvenida
                    EmailService emailService = new EmailService();
                    emailService.armarCorreo(cliente.Email, "Bienvenido/a a maxiGamingShop",
                        "Hola " + cliente.Nombre + " ,te damos la bienvenida a maxiGamingShop!!! Gracias por registrarte.");

                    emailService.enviarCorreo();

                    Session["Cliente"] = cliente;
                    Response.Redirect("Login.aspx", false);
                }
                else {
                    return;
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx");
            }

        }
    }
}