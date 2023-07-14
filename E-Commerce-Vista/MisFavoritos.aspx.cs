using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Vista
{
    public partial class MisFavoritos : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        public List<Articulo> listaFavoritos { get; set; }
        public List<int> ListaArticuloFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ClienteLogueado"] == null)
            {
                Response.Redirect("Default.aspx", false);

            }


            if (!IsPostBack && Session["Favoritos"]!=null)
            {
                
                listaFavoritos = (List<Articulo>)Session["Favoritos"];

                    repFavoritos.DataSource = listaFavoritos;
                    repFavoritos.DataBind();
                
            }
           
          


        }

        protected void repFavoritos_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

             
        }

        protected void btnEliminarFav_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);
            Articulo articulo = new Articulo();
            ListaArticulo = (List <Articulo>) Session["ListaArticulo"];

            articulo = ListaArticulo.Find(a => a.Id == id);

            ListaArticuloFavoritos= (List<int>)Session["ListaArticuloFavoritos"];
            listaFavoritos = (List<Articulo>)Session["Favoritos"];

            ListaArticuloFavoritos.Remove(id);
            listaFavoritos.RemoveAll(a => a.Id == id);

            Session["ListaArticuloFavoritos"] = ListaArticuloFavoritos;
            Session["Favoritos"] = listaFavoritos;

           
            repFavoritos.DataSource = listaFavoritos;
            repFavoritos.DataBind();
            updatePanelFavorito.Update();

        }
    }
}