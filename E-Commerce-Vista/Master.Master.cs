using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace E_Commerce_Vista
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public bool MostrarFiltros { get; set; }

        public bool MostrarCarrito { get; set; }


        public bool NavContentVisible
        {
            get { return NavContent.Visible; }
            set { NavContent.Visible = value; }
        }

        public void ToggleNavContent(bool visible)
        {
            NavContent.Visible = visible;
        }



        protected void Page_Load(object sender, EventArgs e)
        {



            panelContador.Update();
            try
            {

                if (Session["Carrito"] == null)
                {
                    Carrito carrito = new Carrito();
                    Session["Carrito"] = carrito;
                }

                else if (Session["Carrito"] != null)
                {
                    Carrito carrito2 = (Carrito)Session["Carrito"];
                    int cantidadTotalArticulos = carrito2.ObtenerCantidadTotalArticulos();

                    //if (lblTotalCantCarrito != null)
                    if (cantidadTotalArticulos > 0 && lblTotalCantCarrito != null)
                    {
                        //Carrito carrito = (Carrito)Session["Carrito"];
                        //int cantidadTotalArticulos = carrito.ObtenerCantidadTotalArticulos();
                        lblTotalCantCarrito.Text = " (" + cantidadTotalArticulos.ToString() + ")";
                        panelContador.Update();
                    }


                    else
                    {

                        lblTotalCantCarrito.Text = " (0)";
                    }
                }

                if (Session["ClienteLogueado"] != null)
                {
                    var cliente = (Cliente)Session["ClienteLogueado"];
                    UserNameLabel.Text = "Bienvenido/a " + cliente.Nombre;

                }
                else if (Session["Admin"] != null)
                {
                    var admin = (Admin)Session["Admin"];
                    UserNameLabel.Text ="Bienvenido/a " + admin.Nombre;
                }


            }


            catch (Exception ex)
            {

                throw ex;
            }



        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["Carrito"] != null)
            {
                Carrito carrito2 = (Carrito)Session["Carrito"];
                int cantidadTotalArticulos = carrito2.ObtenerCantidadTotalArticulos();
                if (lblTotalCantCarrito != null)
                {
                    lblTotalCantCarrito.Text = " (" + cantidadTotalArticulos.ToString() + ")";
                    panelContador.Update();
                }
                else
                {

                    lblTotalCantCarrito.Text = " (0)";
                }


                //lblMensaje.Text = Session["Carrito"].ToString();
            }
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            
            Session.Remove("Admin");

            
            Session.Remove("ClienteLogueado");
            Session.Remove("Cliente");
            // También puedes redirigir a una página de logout si es necesario
            Response.Redirect("Default.aspx");
        }





    }
}