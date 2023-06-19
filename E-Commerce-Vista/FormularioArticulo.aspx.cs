using Dominio;
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

        public bool confirmarEliminar { get; set; }
        public bool modificando { get; set; }

        public bool verId { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {

            txtId.Enabled = false;
            try
            {
                modificando = false;
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                confirmarEliminar = false;
                verId = false;

                if (!IsPostBack)
                {
                    Session.Remove("Imagenes");
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

                        txtId.Text = seleccionada.Id.ToString();
                        txtId.ReadOnly = true;
                        txtNombre.Text = seleccionada.Nombre;
                        txtCodigoArticulo.Text = seleccionada.CodigoArticulo;
                        txtDescripcion.Text = seleccionada.Descripcion;
                        txtPrecio.Text = seleccionada.Precio.ToString();
                        ddlMarca.SelectedValue = seleccionada.Marcas.Id.ToString();
                        ddlCategoria.SelectedValue = seleccionada.Categorias.Id.ToString();
                       

                        //txtImagenUrl.Text = seleccionada.Imagenes.Url
                        txtNombre.CssClass = "form-control is-valid";
                        txtCodigoArticulo.CssClass = "form-control is-valid";
                        txtDescripcion.CssClass = "form-control is-valid";
                        txtPrecio.CssClass = "form-control is-valid";


                        modificando = true;
                        updatePanelArticulo.Update();

                    }
                  

                    else
                    {
                        //MarcaNegocio marcaNegocio = new MarcaNegocio();
                        //CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                        //List<Marca> listaMarcas = marcaNegocio.listar();
                        //List<Categoria> listaCategorias = categoriaNegocio.listar();


                        //ddlMarca.DataSource = listaMarcas;
                        //ddlMarca.DataValueField = "Id";
                        //ddlMarca.DataTextField = "NombreMarca";
                        //ddlMarca.DataBind();

                        //ddlCategoria.DataSource = listaCategorias;
                        //ddlCategoria.DataValueField = "Id";
                        //ddlCategoria.DataTextField = "NombreCategoria";
                        //ddlCategoria.DataBind();



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
            }
            else
            {
                txtPrecio.CssClass = "form-control is-valid";
            }
            updatePanelArticulo.Update();
        }
        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(txtImagenUrl.Text.Trim()) && Session["Imagenes"] == null)
            {

                txtImagenUrl.CssClass = "form-control is-invalid";
            }
            else
            {
                if (Session["Imagenes"] == null)
                {

                    //Imagen imagen = new Imagen();
                    //imagen.UrlImagen = txtImagenUrl.Text;

                    //Session.Add("Imagenes", imagen);
                    //imgArticulo.ImageUrl = imagen.UrlImagen;
                    
                    List<string> urlsImagenes= new List<string>();
                    urlsImagenes.Add(txtImagenUrl.Text);

                    Session.Add("Imagenes", urlsImagenes);

                    imgArticulo.ImageUrl = txtImagenUrl.Text;
                    //txtImagenUrl.Text = "";
                    txtImagenUrl.CssClass = "form-control is-valid";


                }
                else if (Session["Imagenes"] != null && txtImagenUrl.Text != "") {

                    //Imagen imagen = new Imagen();
                    //imagen.UrlImagen = txtImagenUrl.Text;

                    //Session.Add("Imagenes", imagen);
                    //imgArticulo.ImageUrl = imagen.UrlImagen;


                    List<string> urlsImagenes= new List<string>();
                    urlsImagenes = (List<string>)Session["Imagenes"];
                    urlsImagenes.Add(txtImagenUrl.Text);

                    imgArticulo.ImageUrl = txtImagenUrl.Text;
                    //txtImagenUrl.Text = "";
                    txtImagenUrl.CssClass = "form-control is-valid";

                    Session.Add("Imagenes", urlsImagenes);

                }


            }

            updatePanelArticulo.Update();
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {


                if (validarFormulario())
                {

                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    Articulo articulo = new Articulo();
                    articulo.Marcas = new Marca();
                    articulo.Categorias = new Categoria();



                    articulo.Imagenes = new List<Imagen>();



                    articulo.Nombre = txtNombre.Text;
                    articulo.CodigoArticulo = txtCodigoArticulo.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.Precio = decimal.Parse(txtPrecio.Text);
                    articulo.Marcas.Id = int.Parse(ddlMarca.SelectedValue);
                    articulo.Categorias.Id = int.Parse(ddlCategoria.SelectedValue);


                    List<string> urlsImagenes = new List<string>();
                    urlsImagenes = (List<string>)Session["Imagenes"];

                    foreach (string urlImagen in urlsImagenes)
                    {
                        articulo.Imagenes.Add(new Imagen { UrlImagen=urlImagen});
                    }

                    //articuloNegocio.agregar(articulo);
                    // if (Request.QueryString["id"] != null)
                    //{
                    //    nuevaMarca.Id = int.Parse(txtId.Text);
                    //    negocio.modificar(nuevaMarca);
                    //}



                    //else
                    //{
                    //   
                    //}



                }
                else
                {
                    return;
                }

                Response.Redirect("GestionArticulos.aspx", false);
                Session.Remove("Imagenes");

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }


        public void btnAgregarImagen_Click(object sender, EventArgs e)
        {



            txtImagenUrl.Text = "";
            updatePanelArticulo.Update();




        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

            if (Session["Imagenes"] != null)
            {
                updatePanelArticulo.Update();
            }
        }




    }
}