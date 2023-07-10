using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Vista
{
    public partial class FinalizarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["NroPedido"]!=null)
            {
                int nroPedido = (int)Session["NroPedido"];
                string nroPedidoString = Convert.ToString(nroPedido);
                lblNroPedido.Text = "NRO. PEDIDO:" + nroPedidoString;
            }
            else
            {
                Response.Redirect("Listado.aspx");
            }

        }
    }
}