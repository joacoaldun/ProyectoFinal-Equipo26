using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Vista
{
    public partial class RecuperarCuenta : System.Web.UI.Page
    {
        public bool codigoEnviado { get; set; }
        public bool codigoValidado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                codigoEnviado = false;
                codigoValidado = false;
                
            }

            txtPass.Attributes["value"] = txtPass.Text;

            txtConfirmarPass.Attributes["value"] = txtConfirmarPass.Text;

        }

       

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
                {

                    UsuarioNegocio negocio = new UsuarioNegocio();
                    List<Cliente> listaClientes = negocio.listarClientesConSp();
                    Cliente cliente = listaClientes.Find(x => x.Email == txtEmail.Text);

                    string codigoRecuperacion;


                    if (string.IsNullOrEmpty(cliente.CodigoRecuperacion))
                    {
                        codigoRecuperacion = generarCodigo();
                        cliente.CodigoRecuperacion = codigoRecuperacion;

                        //insertamos este codigo en bd
                        negocio.agregarCodigoRecuperacion(cliente);
                    }
                    else
                    {
                        codigoRecuperacion = cliente.CodigoRecuperacion;
                    }
                    Session["Cliente"] = cliente;

                    //enviamos mail
                    EmailService emailService = new EmailService();
                    emailService.armarCorreo(cliente.Email, "Recuperación de cuenta maxiGamingShop",
                        "Hola " + cliente.Nombre + ",tu Usuario es: " + cliente.UserName +
                        ". Por favor ingresá el siguiente código en la web para reestablecer la contraseña: " + codigoRecuperacion);

                    emailService.enviarCorreo();
                    //cambiamos variable de front a true para que muestre los campos de "nueva contraseña"
                    codigoEnviado = true;

                }
                else
                {
                    //error. no se ingreso un email
                    lblMensajeError.Text = "Ingrese el email a recuperar";
                    lblMensajeError.Visible = true;
                    updatePanelMensajeError.Update();
                    timerMensajeError.Enabled = true;

                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("error.aspx", false);
            }
            

        }


        protected void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtCodigoValidacion.Text.Trim()))
                {
                    Cliente cliente = (Cliente)Session["Cliente"];
                    if (cliente.CodigoRecuperacion == txtCodigoValidacion.Text)
                    {
                        codigoValidado = true;
                    }
                    else
                    {
                        //codigo  incorrecto, ingrese nuevamente.
                        lblMensajeError.Text = "Codigo incorrecto, intente nuevamente.";
                        lblMensajeError.Visible = true;
                        updatePanelMensajeError.Update();
                        timerMensajeError.Enabled = true;
                    }
                }
                else
                {
                    lblMensajeError.Text = "Ingrese el código enviado por email.";
                    lblMensajeError.Visible = true;
                    updatePanelMensajeError.Update();
                    timerMensajeError.Enabled = true;
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("error.aspx", false);
            }
            
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarFormulario())
                {
                    //ok validado, cambiamos pass (updateamos)

                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Cliente cliente=(Cliente)Session["Cliente"];
                    cliente.Pass = txtConfirmarPass.Text;

                    negocio.cambiarPass(cliente);

                    //redireccionamos a login.
                    Response.Redirect("Login.aspx", false);
                    



                }
               
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("error.aspx", false);
            }
        }



        public bool validarFormulario()
        {
            if (txtPass.CssClass == "form-control is-invalid")
            {
                return false;
            }
            if(txtConfirmarPass.CssClass == "form-control is-invalid")
            {
                return false;
            }
            return true;
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

            Session["Recuperando"] = true;

            panelPass.Update();

        }

        protected void txtConfirmarPass_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmarPass.Text.Trim()))
            {
                txtConfirmarPass.CssClass = "form-control is-invalid";
            }
            else if (txtConfirmarPass.Text != txtPass.Text)
            {
                txtConfirmarPass.CssClass = "form-control is-invalid";
                errorPass.InnerText = "Las contraseñas no coinciden. Intente nuevamente";
            }
            else
            {
                txtConfirmarPass.CssClass = "form-control is-valid";
            }

            Session["Recuperando"] = true;
            panelPass.Update();
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


        protected void timerMensajeError_Tick(object sender, EventArgs e)
        {
            lblMensajeError.Visible = false;
            timerMensajeError.Enabled = false;
            updatePanelMensajeError.Update();
        }


    }
}