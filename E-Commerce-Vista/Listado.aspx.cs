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
    public partial class Articulos : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["ListaArticulo"]==null)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("ListaArticulo", negocio.listarConSP().Where(a => a.Estado == true).ToList());
                ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();


            }
            else if  (!IsPostBack && Session["ListaArticulo"]!=null && Request.Params["id"] != null)
                {

                string id = Request.Params["id"];
                if (id.StartsWith("M_"))
                {
                    int marcaId = int.Parse(id.Substring(2));
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Marca marca = new Marca();
                    Session.Add("ListaArticulo", negocio.listarConSP().Where(a => a.Marcas.Id == marcaId).ToList());
                    ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
                    repRepetidor.DataSource = ListaArticulo;
                    repRepetidor.DataBind();
                }
                else if (id.StartsWith("C_"))
                {
                    int categoriaId = int.Parse(id.Substring(2));
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Categoria categoria= new Categoria();
                    Session.Add("ListaArticulo", negocio.listarConSP().Where(a => a.Categorias.Id == categoriaId).ToList());
                    ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
                    repRepetidor.DataSource = ListaArticulo;
                    repRepetidor.DataBind();
                }
                    
            }




            else if(!IsPostBack && Session["ListaArticulo"] != null)
                {
                
                ArticuloNegocio negocio = new ArticuloNegocio();
                    Session.Add("ListaArticulo", negocio.listarConSP().Where(a => a.Estado == true).ToList());
                    ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
                    repRepetidor.DataSource = ListaArticulo;
                    repRepetidor.DataBind();
                    //repRepetidor.DataSource = (List<Articulo>)Session["ListaArticulo"];
                    //repRepetidor.DataBind();
                }
               
            
           

        }


        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
            }



            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Articulo articulo = e.Item.DataItem as Articulo;
                Button btnAgregar = e.Item.FindControl("btnEjemplo") as Button;

                if (articulo.StockArticulo.Cantidad == 0)
                {
                    btnAgregar.Enabled = false;
                    btnAgregar.CssClass = "btn btn-danger btn-pg-1";
                    btnAgregar.Text = "Sin stock";
                }
            }

        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnDetalle = (Button)sender;
                var id = btnDetalle.CommandArgument;
                Response.Redirect("DetalleArticulo.aspx?id=" + id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //AGREGAMOS ARTICULOS A LA LISTA DE ARTICULOS DE LA CLASE CARRITO
        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            Carrito carrito = (Carrito)Session["Carrito"];
            Articulo articulo = new Articulo();
            ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
            articulo = ListaArticulo.Find(a => a.Id == id);

            carrito.AgregarArticulo(articulo);
            Session["Carrito"] = carrito;
          
         
        }

        // Funcion para actualizar y llamar a la funcion despues del updatePanel para que vuelva a asignar los eventos 
        protected void panel1_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "AsignarEventos", "asignarEventos();", true);
            }
        }

    }
}