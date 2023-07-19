using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using System.Web.Script.Serialization;

namespace E_Commerce_Vista
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public bool MostrarFiltros { get; set; }

        public bool MostrarCarrito { get; set; }
        public string JsonArticulos { get; set; }

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

           if (!IsPostBack)
            {
                //PROBANDO PARA AUTOCOMPLETAR DE BUSCADOR
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> listaArticulos = negocio.listarConSP();
                List<String> listaArts = new List<String>();
                List<int> listaIds = new List<int>();

                foreach (Articulo articulo in listaArticulos)
                {
                    if (articulo.Estado == true)
                    {
                    listaArts.Add(articulo.Nombre);
                    listaIds.Add(articulo.Id);

                    }
                }

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                //JsonArticulos = serializer.Serialize(listaArts);
                JsonArticulos = serializer.Serialize(new { Nombres = listaArts, Ids = listaIds });
                //
            }


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
                    UserNameLabel.Text = "Bienvenido/a " + admin.Nombre;
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


        //protected void txtArticulo_TextChanged(object sender, EventArgs e)
        //{
        //    string articulo = txtArticulo.Text;

            
        //    ArticuloNegocio negocio = new ArticuloNegocio();
        //    List<Articulo> articulos = negocio.listarConSP();
        //    List<Articulo> articulosFiltrados = articulos
        //        .Where(a => a.Nombre.ToLower().Contains(txtArticulo.Text.ToLower()))
        //        .ToList();

            
        //    dlOpciones.DataSource = articulosFiltrados;
        //    dlOpciones.DataBind();
        //    updateBuscador.Update();
        //}

        //protected void dlOpciones_ItemCommand(object source, DataListCommandEventArgs e)
        //{
        //    if (e.CommandName == "VerArticulo")
        //    {
        //        string idArticulo = e.CommandArgument.ToString();
        //        Response.Redirect("DetalleArticulo.aspx?id=" + idArticulo);
        //    }
        //}

        
    }
}
