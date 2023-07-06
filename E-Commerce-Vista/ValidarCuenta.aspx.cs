using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace E_Commerce_Vista
{
    public partial class ValidarCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
           if (Session["ClienteSinValidar"]==null)
           {
               Response.Redirect("Default.aspx", false);
           }
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {   
                UsuarioNegocio negocio= new UsuarioNegocio();
                List<Cliente> listaClientes = negocio.listarClientesConSp();
                Cliente cliente=new Cliente();

                if (Session["ClienteSinValidar"] != null)
                {
                    cliente = (Cliente)Session["ClienteSinValidar"];
                }

                //buscamos si coincide el codigo enviado x mail con el codigo ingresado...
                string codigoValidacion = cliente.CodigoValidacion;

                if (codigoValidacion == txtCodigoValidacion.Text)
                {
                    //cambiamos estado a validado y redirigimos a login...
                    negocio.validarCliente(cliente);
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    //mensaje de error.. codigo incorrecto
                }


                
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx",false);
            }


           

        }
    }
}