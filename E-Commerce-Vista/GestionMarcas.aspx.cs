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
    public partial class GestiónMarcas : System.Web.UI.Page
    {
        public List<Marca> ListaMarca{ get; set; }
        public List<Marca> ListaFiltradaAdmin { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcaNegocio negocio= new MarcaNegocio();
            Session["ListaMarcaAdmin"] = negocio.listar();
            dgvMarcas.DataSource = negocio.listar();
            dgvMarcas.DataBind();
        }

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id=dgvMarcas.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioMarca.aspx?id=" + id);
        }

        protected void dgvMarcas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMarcas.PageIndex = e.NewPageIndex;
            dgvMarcas.DataBind();
        }

        protected void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            dgvMarcas.DataSource = Session["ListaMarcaAdmin"];
            dgvMarcas.DataBind();
            Session["ListaFiltradaMarcaAdmin"] = null;
            txtNombre.Text = string.Empty;
        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ListaMarca = (List<Marca>)Session["ListaMarcaAdmin"];
            ListaFiltradaAdmin = ListaMarca.FindAll(x => x.NombreMarca.ToUpper().Contains(txtNombre.Text.ToUpper()));

            Session["ListaFiltradaMarcaAdmin"] = ListaFiltradaAdmin;
            dgvMarcas.DataSource = ListaFiltradaAdmin;
            dgvMarcas.DataBind();
        }


        protected void Option1_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "A-Z"
            if (Session["ListaFiltradaMarcaAdmin"] != null)
            {
                ListaMarca = (List<Marca>)Session["ListaFiltradaMarcaAdmin"];
            }
            else
            {
                ListaMarca = (List<Marca>)Session["ListaMarcaAdmin"];
            }
            ListaFiltradaAdmin = ListaMarca.OrderBy(x => x.NombreMarca).ToList();
            dgvMarcas.DataSource = ListaFiltradaAdmin;
            dgvMarcas.DataBind();
            Session.Add("ListaFiltradaMarcaAdmin", ListaFiltradaAdmin);
        }

        protected void Option2_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "Z-A"
            if (Session["ListaFiltradaMarcaAdmin"] != null)
            {
                ListaMarca = (List<Marca>)Session["ListaFiltradaMarcaAdmin"];
            }
            else
            {
                ListaMarca = (List<Marca>)Session["ListaMarcaAdmin"];
            }
            ListaFiltradaAdmin = ListaMarca.OrderByDescending(x => x.NombreMarca).ToList();
            dgvMarcas.DataSource = ListaFiltradaAdmin;
            dgvMarcas.DataBind();
            Session.Add("ListaFiltradaMarcaAdmin", ListaFiltradaAdmin);

        }

    }
}