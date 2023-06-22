﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Vista
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        string imgReemplazo = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";
        public bool confirmarEliminar { get; set; }
        public bool modificando { get; set; }

        public bool verId { get; set; }

        public int indiceActual { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            txtId.Enabled = false;
            try
            {
                
                confirmarEliminar = false;
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                

                if (id == "")
                {
                    verId = false;
                    modificando = false;
                }
                else { 
                
                    verId = true;
                    modificando = true;

                }


                if (!IsPostBack)
                {

                   

                    Session.Remove("Imagenes");
                    Session.Remove("ImagenesId");
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                    List<Marca> listaMarcas = marcaNegocio.listar();
                    List<Categoria> listaCategorias = categoriaNegocio.listar();

                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "NombreMarca";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "NombreCategoria";
                    ddlCategoria.DataBind();


                    if (id != "")
                    {
                        
                        
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        List<Articulo> temporal = negocio.listarConSP();

                        Articulo seleccionada = temporal.Find(x => x.Id == int.Parse(id));

                        //LISTA DE URLS PARA CREAR IMAGENES EN ARTICULOS NUEVOS, Y HACER VALIDACIONES EN MODIFICACION
                        List<string> listaImagenesModificar = new List<string>();
                        
                        //LISTA DONDE VAMOS A CAMBIAR O ELIMINAR LOS URLS PERO DEJAR LOS ID, PARA HACER MODIFICACIONES
                        List<Imagen> imagenes = seleccionada.Imagenes;


                        txtId.Text = seleccionada.Id.ToString();
                        txtId.ReadOnly = true;
                        txtNombre.Text = seleccionada.Nombre;
                        txtCodigoArticulo.Text = seleccionada.CodigoArticulo;
                        txtDescripcion.Text = seleccionada.Descripcion;
                        txtPrecio.Text = seleccionada.Precio.ToString();
                        ddlMarca.SelectedValue = seleccionada.Marcas.Id.ToString();
                        ddlCategoria.SelectedValue = seleccionada.Categorias.Id.ToString();

                        txtStock.Text=seleccionada.StockArticulo.Cantidad.ToString();

                        //txtImagenUrl.Text = seleccionada.Imagenes.Url
                        txtNombre.CssClass = "form-control is-valid";
                        txtCodigoArticulo.CssClass = "form-control is-valid";
                        txtDescripcion.CssClass = "form-control is-valid";
                        txtPrecio.CssClass = "form-control is-valid";

                        foreach (var item in seleccionada.Imagenes) { 
                        
                        listaImagenesModificar.Add(item.UrlImagen.ToString());
                           
                        
                        }

                        if (imagenes.Count > 0)
                        {

                            txtImagenUrl.CssClass = "form-control is-valid";

                        }

                        Session["ObjetoImagen"] = imagenes;
                        Session["Imagenes"] = listaImagenesModificar;
                       

                        modificando = true;
                        updatePanelArticulo.Update();

                    }

                    // Obtener la lista de URLs de imágenes de la sesión
                    List<string> urls_imagenes = (List<string>)Session["Imagenes"];

                    // Verificar si existen imagenes en la session
                    if (urls_imagenes != null && urls_imagenes.Count > 0)
                    {
                        // Mostrar la primera imagen
                        imgCarrusel.ImageUrl = urls_imagenes[0];
                        Session["IndiceImagenActual"] = 0;
                        indiceActual = 0;
                    }
                    else
                    {
                        if (urls_imagenes == null)
                        {
                            imgCarrusel.ImageUrl = imgReemplazo;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }


        }

        public bool validarFormulario()
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(txtCodigoArticulo.Text.Trim()))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {

                return false;

            }
            else if (string.IsNullOrEmpty(txtPrecio.Text.Trim()))
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                txtNombre.CssClass = "form-control is-invalid";
            }
            else
            {
                txtNombre.CssClass = "form-control is-valid";
            }
            updatePanelArticulo.Update();
        }


        protected void txtCodigoArticulo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoArticulo.Text.Trim()))
            {
                txtCodigoArticulo.CssClass = "form-control is-invalid";
            }
            else
            {
                txtCodigoArticulo.CssClass = "form-control is-valid";
            }
            updatePanelArticulo.Update();
        }

        protected void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                txtDescripcion.CssClass = "form-control is-invalid";
            }
            else
            {
                txtDescripcion.CssClass = "form-control is-valid";
            }
            updatePanelArticulo.Update();
        }

        protected void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrecio.Text.Trim()))
            {
                txtPrecio.CssClass = "form-control is-invalid";
                errorPrecio.InnerText = "Campo obligatorio";
            }
            else
            {
                txtPrecio.CssClass = "form-control is-valid";
            }


            if (!soloNumeros(txtPrecio.Text))
            {
                txtPrecio.CssClass = "form-control is-invalid";
                errorPrecio.InnerText = "Ingrese un campo numérico.";
            }
            else
            {
                txtPrecio.CssClass = "form-control is-valid";
            }
            int stock;
            if (int.TryParse(txtPrecio.Text, out stock))
            {
                if (stock < 0)
                {
                    txtPrecio.CssClass = "form-control is-invalid";
                    errorPrecio.InnerText = "Ingrese un valor positivo.";
                }
                else
                {
                    txtPrecio.CssClass = "form-control is-valid";
                }
            }


            updatePanelArticulo.Update();
        }
        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtImagenUrl.Text.Trim()) && Session["Imagenes"] == null)
            {

                txtImagenUrl.CssClass = "form-control is-invalid";
            }
            else if (Session["Imagenes"] != null && txtImagenUrl.Text != "")
            {

                txtImagenUrl.CssClass = "form-control is-valid";

                updatePanelArticulo.Update();
            }

            updatePanelArticulo.Update();
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (validarFormulario())
                {
                   
                    
                    
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    Articulo articulo = new Articulo();
                    StockNegocio stockNegocio= new StockNegocio();  
                    articulo.Marcas = new Marca();
                    articulo.Categorias = new Categoria();
                    articulo.StockArticulo = new Stock();

                    articulo.Imagenes = new List<Imagen>();

                    articulo.Nombre = txtNombre.Text;
                    articulo.CodigoArticulo = txtCodigoArticulo.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.Precio = decimal.Parse(txtPrecio.Text);
                    articulo.Marcas.Id = int.Parse(ddlMarca.SelectedValue);
                    articulo.Categorias.Id = int.Parse(ddlCategoria.SelectedValue);


                   
                    int cantidad = txtStock.Text != "" ? int.Parse(txtStock.Text) : 0;
                    articulo.StockArticulo.Cantidad = cantidad;


                    if (id == "")
                    {
                        List<string> urlsImagenes = new List<string>();
                        urlsImagenes = (List<string>)Session["Imagenes"];

                        foreach (string urlImagen in urlsImagenes)
                        {
                            articulo.Imagenes.Add(new Imagen { UrlImagen = urlImagen });
                        }

                        articuloNegocio.agregarArticuloConSp(articulo);
                        articuloNegocio.guardarListaImagenes(articulo);
                        stockNegocio.agregarStockConSP(articulo);
                    }
                    else {
                        articulo.Id = int.Parse(id);
                        articuloNegocio.modificarArticulo(articulo);
                        stockNegocio.modificarStockConSP(articulo);
                    
                    
                    }

                   


                }
                else
                {
                    return;
                }

                Response.Redirect("GestionArticulos.aspx", false);
                Session.Remove("Imagenes");
                Session.Remove("Stock");
                
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }


        public void btnAgregarImagen_Click(object sender, EventArgs e)
        {

            if (Session["Imagenes"] == null && txtImagenUrl.Text != "")
            {

                List<string> urlsImagenes = new List<string>();
                urlsImagenes.Add(txtImagenUrl.Text);

                Session.Add("Imagenes", urlsImagenes);

                imgCarrusel.ImageUrl = txtImagenUrl.Text;
                Session.Add("IndiceImagenActual", urlsImagenes.Count - 1);
                txtImagenUrl.CssClass = "form-control is-valid";

            }
            else if (Session["Imagenes"] != null && txtImagenUrl.Text != "")
            {

                List<string> urlsImagenes = new List<string>();
                urlsImagenes = (List<string>)Session["Imagenes"];
                urlsImagenes.Add(txtImagenUrl.Text);

                imgCarrusel.ImageUrl = txtImagenUrl.Text;

                Session.Add("Imagenes", urlsImagenes);
                Session.Add("IndiceImagenActual", urlsImagenes.Count - 1);

            }

            if (txtImagenUrl.Text == "")
            {
                txtImagenUrl.CssClass = "form-control is-invalid";
            }


            txtImagenUrl.Text = "";
            updatePanelArticulo.Update();

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["Imagenes"] != null)
                updatePanelArticulo.Update();

        }



        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            List<string> urls_imagenes = (List<string>)Session["Imagenes"];
            indiceActual = (int)Session["IndiceImagenActual"];

            if (urls_imagenes != null && indiceActual > 0)
            {

                indiceActual--;
                imgCarrusel.ImageUrl = urls_imagenes[indiceActual];
                txtImagenUrl.Text = urls_imagenes[indiceActual];
                Session["IndiceImagenActual"] = indiceActual;
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            List<string> urls_imagenes = (List<string>)Session["Imagenes"];

            indiceActual = (int)Session["IndiceImagenActual"];

            if (urls_imagenes != null && indiceActual < urls_imagenes.Count - 1)
            {

                indiceActual++;
                imgCarrusel.ImageUrl = urls_imagenes[indiceActual];
                txtImagenUrl.Text = urls_imagenes[indiceActual];
                Session["IndiceImagenActual"] = indiceActual;
            }
        }

        protected void btnModificarImagen_Click(object sender, EventArgs e)
        {

            List<Imagen> imagenes = new List<Imagen>(); 
            List<string> urlsImagenes = new List<string>();
           
            urlsImagenes = (List<string>)Session["Imagenes"];
            imagenes = (List<Imagen>)Session["ObjectoImagen"];


            urlsImagenes[(int)Session["IndiceImagenActual"]] = txtImagenUrl.Text;
            imagenes[(int)Session["IndiceImagenActual"]].UrlImagen = txtImagenUrl.Text;


            Session["Imagenes"] = urlsImagenes;
            Session["ObjectoImagen"] = imagenes;
            imgCarrusel.ImageUrl = txtImagenUrl.Text;
            txtImagenUrl.Text = "";
            updatePanelArticulo.Update();
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            List<string> urlsImagenes = new List<string>();
            urlsImagenes = (List<string>)Session["Imagenes"];
            if (urlsImagenes.Count > 1)
            {
                urlsImagenes.RemoveAt((int)Session["IndiceImagenActual"]);

                List<string> nuevaLista = new List<string>(urlsImagenes.Count); // Crear nueva lista con capacidad inicial igual al número de elementos restantes

                for (int i = 0; i < urlsImagenes.Count; i++)
                {
                    nuevaLista.Add(urlsImagenes[i]);
                }
                Session["Imagenes"] = nuevaLista;

                if ((int)Session["IndiceImagenActual"] >= 1)
                {
                    imgCarrusel.ImageUrl = nuevaLista[(int)Session["IndiceImagenActual"] - 1];

                    updatePanelArticulo.Update();
                }
                else {
                    imgCarrusel.ImageUrl = nuevaLista[(int)Session["IndiceImagenActual"]];

                    updatePanelArticulo.Update();

                }



            }
            else
            {
                txtImagenUrl.CssClass = "form-control is-invalid";
                Session.Remove("Imagenes");

                imgCarrusel.ImageUrl = imgReemplazo;
                updatePanelArticulo.Update();

            }


        }

        protected void txtStock_TextChanged(object sender, EventArgs e)
        {
            
            if (!soloNumeros(txtStock.Text))
            {
                txtStock.CssClass = "form-control is-invalid";
                errorStock.InnerText = "Ingrese un campo numérico.";
            }
            else
            {
                txtStock.CssClass = "form-control is-valid";
            }
            int stock;
            if(int.TryParse(txtStock.Text, out stock))
            {
                if (stock < 0)
                {
                    txtStock.CssClass = "form-control is-invalid";
                    errorStock.InnerText = "Ingrese un valor positivo.";
                }
                else
                {
                    txtStock.CssClass = "form-control is-valid";
                }
            }
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

        protected void btnActualizarStock_Click(object sender, EventArgs e)
        {
            //Session.Add("Stock", txtStock.Text);
        }
    }
}