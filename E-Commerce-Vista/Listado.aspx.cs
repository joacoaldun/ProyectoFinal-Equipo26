using System;
using System.Collections.Generic;
using System.Drawing;
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
        public List<int> ListaArticuloFavoritos { get; set; } 
        protected void Page_Load(object sender, EventArgs e)
        {   


            //VERIFICAMOS SI LOS ID YA ESTAN SELECCIONADOS COMO FAVORITOS
            if (Session["ListaArticuloFavoritos"] != null)
            {
                ListaArticuloFavoritos = (List<int>)Session["ListaArticuloFavoritos"];
            }

            
            if (ListaArticuloFavoritos != null)
            {
                foreach (RepeaterItem item in repRepetidor.Items)
                {
                    Button btnFavorito = item.FindControl("btnFavorito") as Button;
                    int id = Convert.ToInt32(btnFavorito.CommandArgument);

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

            //LISTAMOS ARTICULOS
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

            //CARGAMOS LISTA FILTRADA 
            if (Session["listaArticulosFiltrada"] == null)
            {
                //ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
                //repRepetidor.DataSource = ListaArticulo;
                //repRepetidor.DataBind();
            }
            else
            {
                repRepetidor.DataSource = (List<Articulo>)Session["ListaArticulosFiltrada"];
                repRepetidor.DataBind();
                Session["ListaArticulosFiltrada"] = null;
                
            }

            if (!IsPostBack)
            {
                cargarCboCriterio("Mayor a", "Menor a", "Igual a");

            }

            if (!IsPostBack)
            {
               
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
                    btnAgregar.Style["background-color"] = "purple";
                    btnAgregar.Style["color"] = "white";
                    btnAgregar.Style["border"] = "none";
                    btnAgregar.Text = "Sin stock";
                }
            }

           
            //CAMBIAMOS VISUAL DEL BOTON SI ESTA SELECCIONADO O NO

            if (ListaArticuloFavoritos != null)
            {
                    Button btnFavorito = e.Item.FindControl("btnFavorito") as Button;
                    int id = Convert.ToInt32(btnFavorito.CommandArgument);

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

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((Button)sender).CommandArgument);

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
            }
            else
            {
                ListaArticuloFavoritos.Add(id); //si no esta lo sumamos
            }

            
            Session["ListaArticuloFavoritos"] = ListaArticuloFavoritos;

            string script = string.Format("btnFavoritoClick('{0}');", ((Button)sender).ClientID);
            ScriptManager.RegisterStartupScript(this, GetType(), "btnFavoritoClick", script, true);


        }


        //FUNCIONES FILTROS
        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["ListaArticulo"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            repRepetidor.DataSource = listaFiltrada;
            repRepetidor.DataBind();
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            txtFiltroAvanzado.Enabled = true;
            string opcion = ddlCampo.SelectedItem.ToString();

            if (opcion == "Precio")
            {
                cargarCboCriterio("Mayor a", "Menor a", "Igual a");
            }
            else if (opcion == "Categorías")
            {
                txtFiltroAvanzado.Enabled = false;
                cargarCboCategorias();
            }
            else if (opcion == "Marcas")
            {
                txtFiltroAvanzado.Enabled = false;
                cargarCboMarcas();
            }
            else
            {
                cargarCboCriterio("Comienza con", "Termina con", "Contiene");
            }
        }

        private void cargarCboCriterio(string criterio1, string criterio2, string criterio3)
        {
            ddlCriterio.Items.Add(criterio1);
            ddlCriterio.Items.Add(criterio2);
            ddlCriterio.Items.Add(criterio3);
        }

        private void cargarCboMarcas()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            List<Marca> marcas = new List<Marca>();
            marcas = negocio.listar();

            foreach (Marca marca in marcas)
            {
                ddlCriterio.Items.Add(marca.NombreMarca);
            }
        }

        private void cargarCboCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            List<Categoria> categorias = new List<Categoria>();
            categorias = negocio.listar();

            foreach (Categoria categoria in categorias)
            {
                ddlCriterio.Items.Add(categoria.NombreCategoria);
            }

        }


        protected void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            
            repRepetidor.DataSource = Session["ListaArticulo"];
            repRepetidor.DataBind();
            Session["ListaFiltrada"] = null;
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

        private bool validarFiltro()
        {
            if (ddlCampo.SelectedIndex < 0 || ddlCampo.SelectedIndex < 0)
            {
                //lblMensajeError.Text = "Debe seleccionar un campo y un criterio de búsqueda.";
                //lblMensajeError.Visible = true;
                //updatePanelMensajeError.Update();
                //timerMensajeError.Enabled = true;
                //("Debe seleccionar un campo y un criterio de búsqueda.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    //lblMensajeError.Text = "Ingrese un filtro para la búsqueda.";
                    //lblMensajeError.Visible = true;
                    //updatePanelMensajeError.Update();
                    //timerMensajeError.Enabled = true;
                    // ("Por favor ingresa un filtro para numéricos");
                    return false;
                }
                if (!soloNumeros(txtFiltroAvanzado.Text))
                {
                    //lblMensajeError.Text = "Por favor ingrese un filtro para numéricos";
                    //lblMensajeError.Visible = true;
                    //updatePanelMensajeError.Update();
                    //timerMensajeError.Enabled = true;
                    //("Solo se aceptan números para filtrar un campo numerico");
                    return false;
                }
                int filtroAvanzado;
                if (int.TryParse(txtFiltroAvanzado.Text, out filtroAvanzado))
                {
                    if (filtroAvanzado < 0)
                    {
                        //lblMensajeError.Text = "El filtro para números no puede ser menor que 0";
                        //lblMensajeError.Visible = true;
                        //updatePanelMensajeError.Update();
                        //timerMensajeError.Enabled = true;
                        return false;
                    }
                }
                if (ddlCriterio.SelectedItem.ToString() == "Menor a")
                {
                    if (int.TryParse(txtFiltroAvanzado.Text, out filtroAvanzado))
                    {
                        if (filtroAvanzado == 0)
                        {
                            //lblMensajeError.Text = "El filtro para números no puede ser menor que 0";
                            //lblMensajeError.Visible = true;
                            //updatePanelMensajeError.Update();
                            //timerMensajeError.Enabled = true;
                            return false;
                        }

                    }
                }


            }

            if (ddlCampo.SelectedItem.ToString() == "Nombre")
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    //lblMensajeError.Text = "Ingrese un filtro para la búsqueda.";
                    //lblMensajeError.Visible = true;
                    //updatePanelMensajeError.Update();
                    //timerMensajeError.Enabled = true;
                    return false;
                }

            }


            return true;
        }



        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                ArticuloNegocio negocio = new ArticuloNegocio();
                if (validarFiltro())
                {

                    string campo = ddlCampo.SelectedItem.ToString();
                    string criterio = ddlCriterio.SelectedItem.ToString();
                    string filtro = txtFiltroAvanzado.Text;


                    if (ddlCampo.SelectedItem.ToString() == "Marcas" || ddlCampo.SelectedItem.ToString() == "Categorías")
                    {
                        filtro = criterio;
                    }

                    if (string.IsNullOrWhiteSpace(filtro))
                    {
                        repRepetidor.DataSource = Session["ListaArticulo"];
                        repRepetidor.DataBind();
                    }
                    else
                    {
                       
                        ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
                        List<Articulo> listaFiltrada = new List<Articulo>();

                        if (campo == "Precio")
                        {
                            switch (criterio)
                            {
                                case "Mayor a":
                                    listaFiltrada = ListaArticulo.FindAll(x => x.Precio > decimal.Parse(filtro));
                                    break;
                                case "Menor a":
                                    listaFiltrada = ListaArticulo.FindAll(x => x.Precio < decimal.Parse(filtro));
                                    break;
                                case "Igual a":
                                    listaFiltrada = ListaArticulo.FindAll(x => x.Precio == decimal.Parse(filtro));
                                    break;
                            }
                        }
                        else if (campo == "Nombre")
                        {
                            switch (criterio)
                            {
                                case "Comienza con":
                                    listaFiltrada = ListaArticulo.FindAll(x => x.Nombre.ToUpper().StartsWith(filtro.ToUpper()));
                                    break;
                                case "Termina con":
                                    listaFiltrada = ListaArticulo.FindAll(x => x.Nombre.ToUpper().EndsWith(filtro.ToUpper()));
                                    break;
                                case "Contiene":
                                    listaFiltrada = ListaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
                                    break;
                            }
                        }
                        else if (campo == "Marcas")
                        {
                            listaFiltrada = ListaArticulo.FindAll(x => x.Marcas.NombreMarca == ddlCriterio.SelectedValue);
                        }
                        else if (campo == "Categorías")
                        {
                            listaFiltrada = ListaArticulo.FindAll(x => x.Categorias.NombreCategoria == ddlCriterio.SelectedValue);
                        }

                        
                        Session["ListaFiltrada"] = listaFiltrada;

                        repRepetidor.DataSource = listaFiltrada;
                        repRepetidor.DataBind();


                    }

                }

                txtFiltroAvanzado.Text = string.Empty;

            }
            catch (Exception ex)
            {
                Session.Add("Error.aspx", ex);
                Response.Redirect("Error.aspx");
                throw ex;
            }

    }

        protected void ddlOrdenar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //ORDENAR
        protected void Option1_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "A-Z"
            List<Articulo> listaFiltrada=new List<Articulo>();

            if (Session["ListaFiltrada"] == null)
            {
                ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
                listaFiltrada = ListaArticulo.OrderBy(x => x.Nombre).ToList();
            }
            else
            {
                ListaArticulo = (List<Articulo>)Session["ListaFiltrada"];
                listaFiltrada = ListaArticulo.OrderBy(x => x.Nombre).ToList();
            }

            repRepetidor.DataSource = listaFiltrada;
            repRepetidor.DataBind();

        }

        protected void Option2_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "Z-A"
            List<Articulo> listaFiltrada = new List<Articulo>();

            if (Session["ListaFiltrada"] == null)
            {
                ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
                listaFiltrada = ListaArticulo.OrderByDescending(x => x.Nombre).ToList();
            }
            else
            {
                ListaArticulo = (List<Articulo>)Session["ListaFiltrada"];
                listaFiltrada = ListaArticulo.OrderByDescending(x => x.Nombre).ToList();
            }

            
            repRepetidor.DataSource = listaFiltrada;
            repRepetidor.DataBind();
        }

        protected void Option3_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "Mayor a menor"
            List<Articulo> listaFiltrada = new List<Articulo>();
            if (Session["ListaFiltrada"] == null)
            {
                ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
                listaFiltrada = ListaArticulo.OrderByDescending(x => x.Precio).ToList();
            }
            else
            {
                ListaArticulo = (List<Articulo>)Session["ListaFiltrada"];
                listaFiltrada = ListaArticulo.OrderByDescending(x => x.Precio).ToList();
            }

            
            
            repRepetidor.DataSource = listaFiltrada;
            repRepetidor.DataBind();
        }

        protected void Option4_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "Menor a mayor"
            List<Articulo> listaFiltrada = new List<Articulo>();
            if (Session["ListaFiltrada"] == null)
            {
                ListaArticulo = (List<Articulo>)Session["ListaArticulo"];
                listaFiltrada = ListaArticulo.OrderBy(x => x.Precio).ToList();
            }
            else
            {
                ListaArticulo = (List<Articulo>)Session["ListaFiltrada"];
                listaFiltrada = ListaArticulo.OrderBy(x => x.Precio).ToList();
            }

            
            repRepetidor.DataSource = listaFiltrada;
            repRepetidor.DataBind();
        }

    }
}