using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace E_Commerce_Vista
{
    public partial class MisCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ClienteLogueado"] == null)
            {
                Response.Redirect("Default.aspx", false);

            }
            else
            {
                PedidoNegocio negocio = new PedidoNegocio();
                List<Pedido> lista= negocio.listarPedidosConSP();
                Cliente cliente = (Cliente)Session["ClienteLogueado"];
                //List<Pedido> listaCliente = lista.FindAll(x => x.Cliente.Id == cliente.Id);
                dgvPedidos.DataSource = lista.FindAll(x => x.Cliente.Id == cliente.Id);
                dgvPedidos.DataBind();
            }

        }

        protected void dgvPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void dgvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvPedidos.SelectedDataKey.Value.ToString();
            Response.Redirect("DetallePedido.aspx?id=" + id);
        }
    }
}