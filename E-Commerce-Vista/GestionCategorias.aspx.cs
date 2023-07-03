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
    public partial class GestiónCategorias : System.Web.UI.Page
    {
        public List<Categoria> ListaCategoria{ get; set; }
        public List<Categoria> ListaFiltradaAdmin { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Session["ListaCategoriaAdmin"] = negocio.listar();
            dgvCategorias.DataSource = negocio.listar();
            dgvCategorias.DataBind();
        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvCategorias.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioCategoria.aspx?id=" + id);
        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ListaCategoria = (List<Categoria>)Session["ListaCategoriaAdmin"];
            ListaFiltradaAdmin = ListaCategoria.FindAll(x => x.NombreCategoria.ToUpper().Contains(txtNombre.Text.ToUpper()));

            Session["ListaFiltradaCategoriaAdmin"] = ListaFiltradaAdmin;
            dgvCategorias.DataSource = ListaFiltradaAdmin;
            dgvCategorias.DataBind();

          
        }

        protected void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            dgvCategorias.DataSource = Session["ListaCategoriaAdmin"];
            dgvCategorias.DataBind();
            Session["ListaFiltradaCategoriaAdmin"] = null;
            txtNombre.Text = string.Empty;
           
        }

        protected void Option1_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "A-Z"
            ListaFiltradaAdmin = new List<Categoria>();
            CategoriaNegocio negocio = new CategoriaNegocio();

            ListaCategoria = negocio.listar();
            ListaFiltradaAdmin = ListaCategoria.OrderBy(x => x.NombreCategoria).ToList();

            dgvCategorias.DataSource = ListaFiltradaAdmin;
            dgvCategorias.DataBind();


        }

        protected void Option2_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "Z-A"
            ListaFiltradaAdmin = new List<Categoria>();
            CategoriaNegocio negocio = new CategoriaNegocio();

            ListaCategoria = negocio.listar();
            ListaFiltradaAdmin = ListaCategoria.OrderByDescending(x => x.NombreCategoria).ToList();

            dgvCategorias.DataSource = ListaFiltradaAdmin;
            dgvCategorias.DataBind();


        }

        

    }
}