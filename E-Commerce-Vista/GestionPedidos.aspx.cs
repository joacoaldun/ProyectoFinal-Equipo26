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
    public partial class GestiónPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("Default.aspx", false);

            }



            PedidoNegocio negocio = new PedidoNegocio();
            dgvPedidos.DataSource = negocio.listarPedidosConSP();
            dgvPedidos.DataBind();
        }

        protected void dgvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvPedidos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioPedido.aspx?id=" + id);
        }

        protected void dgvPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPedidos.PageIndex = e.NewPageIndex;
            dgvPedidos.DataBind();
        }
    }
}