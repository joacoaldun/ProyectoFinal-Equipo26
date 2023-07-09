using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace E_Commerce_Vista
{
    public partial class Login : System.Web.UI.Page
    {   
        
        protected void Page_Load(object sender, EventArgs e)
        {   //Despues del registro nos queda la session con los datos del cliente...
            if (Session["Cliente"] != null)
            {
                Cliente cliente = new Cliente();
                cliente = (Cliente)Session["Cliente"];
                txtUser.Text = cliente.UserName;
                txtPassword.Text = cliente.Pass;
                
            }
            
        }

        public void btnIngresar_Click(object sender, EventArgs e)
        {   
            btnIngresar.Enabled = false;
            if(!string.IsNullOrEmpty(txtUser.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                try
                {
                    if (esAdmin())
                    {
                        Response.Redirect("PanelGestion.aspx",false);
                    }
                    else if (esCliente())
                    {
                        Cliente clienteLogueado = new Cliente();
                        UsuarioNegocio negocio=new UsuarioNegocio();
                        List<Cliente> lista = negocio.listarClientesConSp();
                        if (Session["Cliente"] != null)
                        {
                            clienteLogueado = (Cliente)Session["Cliente"];
                        }
                        else
                        {
                            clienteLogueado = lista.Find(x => x.UserName == txtUser.Text);
                        }
                        
                        if (clienteLogueado.Validado == false)
                        {
                            Session["ClienteSinValidar"] = clienteLogueado;
                            Response.Redirect("ValidarCuenta.Aspx", false);
                        }
                        else
                        {
                            Session["ClienteLogueado"] = clienteLogueado;

                            Response.Redirect("Default.aspx",false);
                        }
                    }
                    else
                    {
                        //Mensaje de error - usuario o contraseña incorrectos - 
                        lblMensajeError.Text = "Usuario o contraseña incorrectos";
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
            else
            {
                //Mensaje de error - falta de datos - 
                lblMensajeError.Text = "Ingrese un usuario y contraseña";
                lblMensajeError.Visible = true;
                updatePanelMensajeError.Update();
                timerMensajeError.Enabled = true;
            }
            btnIngresar.Enabled = true;
        }

        public bool esAdmin()            
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            List<Admin> admins  = negocio.listarAdminsConSp();
            string username = txtUser.Text;
            string pass=txtPassword.Text;

            foreach (var admin in admins)
            {

                if (admin.UserName.ToLower() == username.ToLower() && admin.Pass == pass)
                {
                    return true;
                }

            }
            return false;

        }

        public bool esCliente()
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            List<Cliente> clientes = negocio.listarClientesConSp();
            
            foreach (var cliente in clientes)
            {

                if (cliente.UserName.ToLower() == txtUser.Text.ToLower() && cliente.Pass == txtPassword.Text)
                {
                    Session["Cliente"] = cliente;
                    return true;
                }

            }
            return false;
        }


        protected void timerMensajeError_Tick(object sender, EventArgs e)
        {
            lblMensajeError.Visible = false;
            timerMensajeError.Enabled = false;
            updatePanelMensajeError.Update();
        }


    }
}