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
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        public Articulo articulo = new Articulo();
        public List<Articulo> ListaArticulo { get; set; }
        public List<int> ListaArticuloFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    //TRAIGO DESDE LISTADO EL ID DEL ARTICULO QUE QUIERO MOSTRAR A TRAVES DEL CLICK EN EL BUTTON
                    int id = int.Parse(Request.QueryString["id"]);

                    //GENERO UNA LISTA DE ARTICULOS CON LO QUE HAY EN EL SESSION DE ListaArticulo
                    List<Articulo> ListaArticulo = (List<Articulo>)Session["ListaArticulo"];


                    //ENCUENTRO EL ID DEL ARTICULO EN LA LISTA Y COPIO EL OBJETO EN EL NUEVO OBJETO ARTICULO
                    articulo = ListaArticulo.Find(x => x.Id == id);
                    Session["UltimoIdArticulo"] = id;

                    //FAVORITO

                    if (Session["ListaArticuloFavoritos"] != null)
                    {
                        ListaArticuloFavoritos = (List<int>)Session["ListaArticuloFavoritos"];
                    }


                    if (ListaArticuloFavoritos != null)
                    {


                        if (ListaArticuloFavoritos.Contains(id))
                        {
                            btnFavorito.CssClass += " btn-favorito-activo";
                        }
                        else
                        {
                            btnFavorito.CssClass = "btn btnFav";
                        }
                    }

                }
            }
            else
            {   //validacion recarga de pag.
                int ultimoIdArticulo = (int)Session["UltimoIdArticulo"];
                List<Articulo> ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
                articulo = ListaArticulo.Find(x => x.Id == ultimoIdArticulo);

            }


        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listado.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                Carrito carrito = (Carrito)Session["Carrito"];



                carrito.AgregarArticulo(articulo);
                Session["Carrito"] = carrito;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);

            List<Articulo> listaFavoritos = (List<Articulo>)Session["Favoritos"];

            if (listaFavoritos == null)
            {
                listaFavoritos = new List<Articulo>();
            }

            Articulo articulo = new Articulo();
            ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
            articulo = ListaArticulo.Find(a => a.Id == id);

            // VEMOS SI EL ARTICULO YA EXISTE EN LA LISTA
            if (listaFavoritos.Exists(a => a.Id == id))
            {
                listaFavoritos.RemoveAll(a => a.Id == id); // si esta, lo borramos
            }
            else
            {
                listaFavoritos.Add(articulo); //si no esta lo sumamos
            }


            Session["Favoritos"] = listaFavoritos;

            List<int> ListaArticuloFavoritos = (List<int>)Session["ListaArticuloFavoritos"];

            if (ListaArticuloFavoritos == null)
            {
                ListaArticuloFavoritos = new List<int>();
            }

            // VEMOS SI EL ID ARTICULO YA EXISTE EN LA LISTA
            if (ListaArticuloFavoritos.Contains(id))
            {
                ListaArticuloFavoritos.Remove(id); // si esta, lo borramos
                btnFavorito.CssClass = "btn btnFav";
            }
            else
            {
                ListaArticuloFavoritos.Add(id); //si no esta lo sumamos
                btnFavorito.CssClass += " btn-favorito-activo";
            }


            Session["ListaArticuloFavoritos"] = ListaArticuloFavoritos;

            

        }
    }
}