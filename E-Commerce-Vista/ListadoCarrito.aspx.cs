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
    public partial class ListadoCarrito : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            //ArticuloNegocio negocio=new ArticuloNegocio();
            if (!IsPostBack)
            {
                if (Session["Carrito"] != null)
                {

                    Carrito carrito = (Carrito)Session["Carrito"];

                    repCarrito.DataSource = carrito.ListaArticulo;
                    repCarrito.DataBind();
                    //lblPrecioTotal.Text = "$" + carrito.PrecioTotal.ToString();
                     string precio =  string.Format("{0:#,##0.00}", carrito.PrecioTotal.ToString());

                    lblPrecioTotal.Text = precio;
                    lblPrecioTotal.DataBind();

                }
               

                


            }
           
           
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {


            //var id = dgvArticulos.SelectedDataKey.Value.ToString();
            // Response.Redirect("DetalleArticulo.aspx?id=" +  id);


        }


        protected void repCarrito_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Dominio.Articulo art = (Dominio.Articulo)e.Item.DataItem;
                System.Web.UI.WebControls.Image imgImagen = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgImagen");

                /* Place holder si la imagen original falla */


                string urlImagenOriginal = art.Imagenes[0].UrlImagen;
                string urlImagenReemplazo = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";

                imgImagen.ImageUrl = urlImagenOriginal;
                imgImagen.Attributes["onerror"] = "this.onerror=null;this.src='" + urlImagenReemplazo + "';";



                Label lblCantidad = (Label)e.Item.FindControl("lblCantidad");

                if (art != null && lblCantidad != null && Session["Carrito"] is Carrito carrito)
                {
                    int cantidad = carrito.ObtenerCantidadArticulo(art.Id);
                    lblCantidad.Text = cantidad.ToString();


                    decimal precio = art.Precio;
                    decimal total = precio * cantidad;
                    Label lblTotalCantXart = (Label)e.Item.FindControl("lblTotalCantXart");
                    //lblTotalCantXart.Text = "$" + total.ToString();
                    string precio2 = string.Format("{0:#,##0.00}", carrito.PrecioTotal);

                    lblTotalCantXart.Text = precio2;
                    lblTotalCantXart.DataBind();
                }



            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Articulo articulo = e.Item.DataItem as Articulo;
                Button btnAgregar = e.Item.FindControl("btnSumar") as Button;

                if (articulo.StockArticulo.Cantidad == 0)
                {
                    btnAgregar.Enabled = false;

                }
            }
            //updatePanelCarrito.Update();
        }
        //SUMAR Y RESTAR ART. DEL CARRITO
        protected void btnRestar_Click(object sender, EventArgs e)
        {
            Carrito carritoAct = (Carrito)Session["Carrito"];
            Button btnRestar = (Button)sender;
            int id = int.Parse(btnRestar.CommandArgument);

            Articulo art = carritoAct.ListaArticulo.FirstOrDefault(a => a.Id == id);
            carritoAct.RestarArticulo(art);
            Session["Carrito"] = carritoAct;
            updatePanelCarrito.Update();
        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            Carrito carritoAct = (Carrito)Session["Carrito"];
            Button btnSumar = (Button)sender;
            int id = int.Parse(btnSumar.CommandArgument);

            Articulo art = carritoAct.ListaArticulo.FirstOrDefault(a => a.Id == id);
            
            carritoAct.AgregarArticulo(art);

            Session["Carrito"] = carritoAct;
            updatePanelCarrito.Update();
        }


        protected void Page_PreRender(object sender, EventArgs e)
        {


            if (Session["Carrito"] != null)
            {
                Carrito carrito = (Carrito)Session["Carrito"];

                repCarrito.DataSource = carrito.ListaArticulo;
                repCarrito.DataBind();
                string precio = string.Format("{0:#,##0.00}", carrito.PrecioTotal);

                lblPrecioTotal.Text = precio;
                lblPrecioTotal.DataBind();

            }
           
        }

        protected void btnPedido_Click(object sender, EventArgs e)
        {
                 ArticuloNegocio negocio = new ArticuloNegocio();
                  List<Articulo> articulosInsuficientes = new List<Articulo>();  
                 List<Articulo> lista = negocio.listarConSP();

            Carrito carrito = (Carrito)Session["Carrito"];

            for(int i = 0; i < carrito.ListaArticulo.Count; i++) {
            
            for(int x = 0; x<lista.Count; x++)
                {

                    if (carrito.ListaArticulo[i].Id == lista[x].Id) {


                        if (carrito.ArticulosCantidad[carrito.ListaArticulo[i].Id] > lista[x].StockArticulo.Cantidad) {

                            articulosInsuficientes.Add(lista[x]);

                        }
                    
                    
                    
                    }


                }


            }

            if (!filtroStock(articulosInsuficientes))
            {

                Response.Redirect("CompletarDatos.aspx");
            }
            else {
                StringBuilder stringBuilder = new StringBuilder();

                foreach (var item in articulosInsuficientes)
                {
                    stringBuilder.Append("Articulo: " +item.Nombre.ToString() + " ,Stock disponible: " + item.StockArticulo.Cantidad + " || ") ;

                }

                lblMensajeError.Text = "No hay stock suficiente para los siguientes articulos: || " + stringBuilder;
                lblMensajeError.Visible = true;
                updatePanelMensajeError.Update();
                


            }

            
                      
        }


        protected bool filtroStock(List<Articulo> lista)
        {

            if (lista.Count > 0) {

                return true;
            }




            return false;
        }

        protected void timerMensajeError_Tick(object sender, EventArgs e)
        {
            lblMensajeError.Visible = false;
            
            updatePanelMensajeError.Update();
        }

    }
}