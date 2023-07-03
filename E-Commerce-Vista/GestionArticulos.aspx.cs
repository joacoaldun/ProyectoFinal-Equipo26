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
    public partial class GestiónArticulos : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        public List<Articulo> ListaFiltradaAdmin { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulos.DataSource = negocio.listarConSP();
                dgvArticulos.DataBind();
                Session.Add("ListaArticulosAdmin", negocio.listarConSP());


                //CARGAMOS DDL
                //ddlCategorias.Items.Clear();
                //ddlMarcas.Items.Clear();
                CategoriaNegocio catNegocio = new CategoriaNegocio();
                List<Categoria> categorias = new List<Categoria>();
                categorias = catNegocio.listar();

                foreach (Categoria categoria in categorias)
                {
                    ddlCategorias.Items.Add(categoria.NombreCategoria);
                }

                MarcaNegocio marcaNegocio = new MarcaNegocio();
                List<Marca> marcas = new List<Marca>();
                marcas = marcaNegocio.listar();

                foreach (Marca marca in marcas)
                {
                    ddlMarcas.Items.Add(marca.NombreMarca);
                }

                

            }
            


        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

       

        //opciones de ordenamiento
        protected void Option1_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "A-Z"
            ListaFiltradaAdmin = new List<Articulo>();
            ArticuloNegocio negocio= new ArticuloNegocio();
           
                ListaArticulo = negocio.listarConSP();
                ListaFiltradaAdmin = ListaArticulo.OrderBy(x => x.Nombre).ToList();
           
            dgvArticulos.DataSource = ListaFiltradaAdmin;
            dgvArticulos.DataBind();

        }

        protected void Option2_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "Z-A"
            ListaFiltradaAdmin = new List<Articulo>();
            ArticuloNegocio negocio = new ArticuloNegocio();
            
                ListaArticulo = negocio.listarConSP();
                ListaFiltradaAdmin = ListaArticulo.OrderByDescending(x => x.Nombre).ToList();

            dgvArticulos.DataSource = ListaFiltradaAdmin;
            dgvArticulos.DataBind();


        }

        protected void Option3_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "Mayor a menor"
            ListaFiltradaAdmin = new List<Articulo>();
            ArticuloNegocio negocio = new ArticuloNegocio();
           
            ListaArticulo = negocio.listarConSP();
            ListaFiltradaAdmin = ListaArticulo.OrderByDescending(x => x.Precio).ToList();

            dgvArticulos.DataSource = ListaFiltradaAdmin;
            dgvArticulos.DataBind();
        }

        protected void Option4_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "Menor a mayor"
            ListaFiltradaAdmin = new List<Articulo>();
            ArticuloNegocio negocio = new ArticuloNegocio();

            ListaArticulo = negocio.listarConSP();
            ListaFiltradaAdmin = ListaArticulo.OrderBy(x => x.Precio).ToList();


            dgvArticulos.DataSource = ListaFiltradaAdmin;
            dgvArticulos.DataBind();
        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {

            ListaArticulo = (List<Articulo>)Session["ListaArticulosAdmin"];
            ListaFiltradaAdmin = ListaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(txtNombre.Text.ToUpper()));

            dgvArticulos.DataSource = ListaFiltradaAdmin;
            dgvArticulos.DataBind();

            Session.Add("ListaFiltradaAdmin", ListaFiltradaAdmin);

        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            ListaArticulo = (List<Articulo>)Session["ListaArticulosAdmin"];
            ListaFiltradaAdmin = ListaArticulo.FindAll(x => x.CodigoArticulo.ToUpper().Contains(txtCodigo.Text.ToUpper()));

            dgvArticulos.DataSource = ListaFiltradaAdmin;
            dgvArticulos.DataBind();

            Session.Add("ListaFiltradaAdmin", ListaFiltradaAdmin);
        }

        protected void ddlCategorias_TextChanged(object sender, EventArgs e)
        {
           
            if (Session["ListaFiltradaAdmin"]!= null){
                ListaArticulo = (List<Articulo>)Session["ListaFiltradaAdmin"];
                ListaFiltradaAdmin = ListaArticulo.FindAll(x => x.Categorias.NombreCategoria == ddlCategorias.SelectedValue );
            }
            else
            {
                ListaArticulo = (List<Articulo>)Session["ListaArticulosAdmin"];
                ListaFiltradaAdmin = ListaArticulo.FindAll(x => x.Categorias.NombreCategoria == ddlCategorias.SelectedValue);
            }

            //Session["ListaFiltradaAdmin"] = ListaFiltradaAdmin;
            dgvArticulos.DataSource = ListaFiltradaAdmin;
            dgvArticulos.DataBind();
        }

        protected void ddlMarcas_TextChanged(object sender, EventArgs e)
        {
            if (Session["ListaFiltradaAdmin"] != null)
            {
                ListaArticulo = (List<Articulo>)Session["ListaFiltradaAdmin"];
                ListaFiltradaAdmin = ListaArticulo.FindAll(x => x.Marcas.NombreMarca == ddlMarcas.SelectedValue);
            }
            else
            {
                ListaArticulo = (List<Articulo>)Session["ListaArticulosAdmin"];
                ListaFiltradaAdmin = ListaArticulo.FindAll(x => x.Marcas.NombreMarca == ddlMarcas.SelectedValue);
            }

            Session["ListaFiltradaAdmin"] = ListaFiltradaAdmin;
            dgvArticulos.DataSource = ListaFiltradaAdmin;
            dgvArticulos.DataBind();
        }

        protected void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            dgvArticulos.DataSource = Session["ListaArticulosAdmin"];
            dgvArticulos.DataBind();
            Session["ListaFiltradaAdmin"] = null;
            txtNombre.Text= string.Empty;
            txtCodigo.Text = string.Empty;
            txtPrecio.Text= string.Empty;
        }

        protected void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            string criterio = ddlCriterio.SelectedValue;
            string precio = txtPrecio.Text;

            if (Session["ListaFiltradaAdmin"] != null)
            {
                ListaArticulo = (List<Articulo>)Session["ListaFiltradaAdmin"];
                //ListaFiltradaAdmin = ListaArticulo.FindAll(x => x.Marcas.NombreMarca == ddlMarcas.SelectedValue);
            }
            else
            {
                ListaArticulo = (List<Articulo>)Session["ListaArticulosAdmin"];
                //ListaFiltradaAdmin = ListaArticulo.FindAll(x => x.Marcas.NombreMarca == ddlMarcas.SelectedValue);
            }



            if (!String.IsNullOrEmpty(precio))
            {
                if (criterio == "Igual a")
                {

                    ListaFiltradaAdmin = ListaArticulo.FindAll(x => x.Precio == decimal.Parse(precio));
                }
                else if (criterio == "Mayor a")
                {
                    ListaFiltradaAdmin = ListaArticulo.FindAll(x => x.Precio > decimal.Parse(precio));
                }
                else if (criterio == "Menor a")
                {
                    ListaFiltradaAdmin = ListaArticulo.FindAll(x => x.Precio < decimal.Parse(precio));
                }
            }
            else
            {
                ListaFiltradaAdmin = (List<Articulo>)Session["ListaArticulosAdmin"];
            }
            

            Session["ListaFiltradaAdmin"] = ListaFiltradaAdmin;
            dgvArticulos.DataSource = ListaFiltradaAdmin;
            dgvArticulos.DataBind();

        }
    }

}
