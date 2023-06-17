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
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcaNegocio negocio= new MarcaNegocio();
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
    }
}