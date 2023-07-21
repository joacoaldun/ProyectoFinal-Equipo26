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
        List<Pedido> ListaPedidos= new List<Pedido>();   
        List<Pedido> ListaFiltrada= new List<Pedido>();   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("Default.aspx", false);

            }

            if (!IsPostBack)
            {
                 PedidoNegocio negocio = new PedidoNegocio();
                 Session.Add("ListaPedidos", negocio.listarPedidosConSP());
                 dgvPedidos.DataSource = negocio.listarPedidosConSP();
                 dgvPedidos.DataBind();

                //MEDIO DE PAGO
                MedioPagoNegocio pagoNegocio = new MedioPagoNegocio();
                List<MedioPago> mediosPago = pagoNegocio.listarMediosPago();
                foreach(MedioPago medioPago in mediosPago)
                {
                    ddlMedioPago.Items.Add(medioPago.NombrePago);
                }


                //ESTADO
                ddlEstado.DataSource=Enum.GetValues(typeof(EstadoEnvio));
                ddlEstado.DataBind();
                


            }

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

        protected void txtNumero_TextChanged(object sender, EventArgs e)
        {
            ListaPedidos = (List<Pedido>)Session["ListaPedidos"];
            ListaFiltrada = ListaPedidos.FindAll(x => x.Id.ToString().Contains(txtNumero.Text));
            dgvPedidos.DataSource = ListaFiltrada;
            dgvPedidos.DataBind();
            Session.Add("ListaPedidosFiltrada", ListaFiltrada);
        
        }

        protected void txtApellido_TextChanged(object sender, EventArgs e)
        {
            ListaPedidos = (List<Pedido>)Session["ListaPedidos"];
            ListaFiltrada = ListaPedidos.FindAll(x => x.Cliente.Apellido.Contains(txtApellido.Text));
            dgvPedidos.DataSource = ListaFiltrada;
            dgvPedidos.DataBind();
            Session.Add("ListaPedidosFiltrada", ListaFiltrada);
        }

        protected void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            dgvPedidos.DataSource = Session["ListaPedidos"];
            dgvPedidos.DataBind();
            Session["ListaPedidosFiltrada"] = null;
            txtNumero.Text = string.Empty;
            txtApellido.Text=string.Empty;
            txtPrecio.Text=string.Empty;
        }

        protected void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            string criterio = ddlCriterio.SelectedValue;
            string precio = txtPrecio.Text;

            if (Session["ListaPedidosFiltrada"] != null)
            {
                ListaPedidos = (List<Pedido>) Session["ListaPedidosFiltrada"];
            }
            else
            {
                ListaPedidos = (List<Pedido>)Session["ListaPedidos"];

            }

            if (!string.IsNullOrEmpty(precio))
            {
                if(criterio=="Igual a")
                {
                    ListaFiltrada = ListaPedidos.FindAll(x => x.ImporteTotal == decimal.Parse(precio));
                }
                else if (criterio=="Mayor a")
                {
                    ListaFiltrada = ListaPedidos.FindAll(x => x.ImporteTotal > decimal.Parse(precio));
                }
                else if(criterio=="Menor a")
                {
                    ListaFiltrada = ListaPedidos.FindAll(x => x.ImporteTotal < decimal.Parse(precio));
                }
            }
            else
            {
                ListaFiltrada = (List<Pedido>)Session["ListaPedidos"];
            }

            Session["ListaPedidosFiltrada"] = ListaFiltrada;
            dgvPedidos.DataSource = ListaFiltrada;
            dgvPedidos.DataBind();


        }



        protected void Option1_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "A-Z"

            if (Session["ListaPedidosFiltrada"] != null)
            {
                ListaPedidos = (List<Pedido>)Session["ListaPedidosFiltrada"];
            }
            else
            {
                ListaPedidos = (List<Pedido>)Session["ListaPedidos"];
            }
            ListaFiltrada = ListaPedidos.OrderBy(x => x.Cliente.Apellido).ToList();
            dgvPedidos.DataSource = ListaFiltrada;
            dgvPedidos.DataBind();
            Session.Add("ListaPedidosFiltrada", ListaFiltrada);

        }

        protected void Option2_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "Z-A"

            if (Session["ListaPedidosFiltrada"] != null)
            {
                ListaPedidos = (List<Pedido>)Session["ListaPedidosFiltrada"];
            }
            else
            {
                ListaPedidos = (List<Pedido>)Session["ListaPedidos"];
            }
            ListaFiltrada = ListaPedidos.OrderByDescending(x => x.Cliente.Apellido).ToList();
            dgvPedidos.DataSource = ListaFiltrada;
            dgvPedidos.DataBind();
            Session.Add("ListaPedidosFiltrada", ListaFiltrada);

        }

        protected void Option3_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "Mayor a menor"

            if (Session["ListaPedidosFiltrada"] != null)
            {
                ListaPedidos = (List<Pedido>)Session["ListaPedidosFiltrada"];
            }
            else
            {
                ListaPedidos = (List<Pedido>)Session["ListaPedidos"];
            }


            ListaFiltrada = ListaPedidos.OrderByDescending(x => x.ImporteTotal).ToList();
            dgvPedidos.DataSource = ListaFiltrada;
            dgvPedidos.DataBind();
            Session.Add("ListaPedidosFiltrada", ListaFiltrada);

        }

        protected void Option4_Click(object sender, EventArgs e)
        {
            // Lógica para la opción "Menor a mayor"


            if (Session["ListaPedidosFiltrada"] != null)
            {
                ListaPedidos = (List<Pedido>)Session["ListaPedidosFiltrada"];
            }
            else
            {
                ListaPedidos = (List<Pedido>)Session["ListaPedidos"];
            }


            ListaFiltrada = ListaPedidos.OrderBy(x => x.ImporteTotal).ToList();
            dgvPedidos.DataSource = ListaFiltrada;
            dgvPedidos.DataBind();
            Session.Add("ListaPedidosFiltrada", ListaFiltrada);

        }

        protected void ddlMedioPago_TextChanged(object sender, EventArgs e)
        {
            if (Session["ListaPedidosFiltrada"] != null)
            {
                ListaPedidos = (List<Pedido>)Session["ListaPedidosFiltrada"];
                ListaFiltrada = ListaPedidos.FindAll(x => x.MedioDePago.NombrePago == ddlMedioPago.SelectedValue);
            }
            else
            {
                ListaPedidos = (List<Pedido>)Session["ListaPedidos"];
                ListaFiltrada = ListaPedidos.FindAll(x => x.MedioDePago.NombrePago == ddlMedioPago.SelectedValue);

            }
            //Session["ListaPedidosFiltrada"] = ListaFiltrada;
            dgvPedidos.DataSource = ListaFiltrada;
            dgvPedidos.DataBind();
        }

        protected void ddlPagado_TextChanged(object sender, EventArgs e)
        {

            if (Session["ListaPedidosFiltrada"] != null)
            {
                ListaPedidos = (List<Pedido>)Session["ListaPedidosFiltrada"];
            }
            else
            {
                ListaPedidos = (List<Pedido>)Session["ListaPedidos"];

            }

            if (ddlPagado.SelectedValue == "Si")
            {
                ListaFiltrada = ListaPedidos.FindAll(x => x.EstadoPago == true);
            }
            else
            {
                ListaFiltrada = ListaPedidos.FindAll(x => x.EstadoPago == false);
            }

            //Session["ListaPedidosFiltrada"] = ListaFiltrada;
            dgvPedidos.DataSource = ListaFiltrada;
            dgvPedidos.DataBind();

        }

        protected void ddlEstado_TextChanged(object sender, EventArgs e)
        {
            if (Session["ListaPedidosFiltrada"] != null)
            {
                ListaPedidos = (List<Pedido>)Session["ListaPedidosFiltrada"];
            }
            else
            {
                ListaPedidos = (List<Pedido>)Session["ListaPedidos"];

            }

            ListaFiltrada = ListaPedidos.FindAll(x => x.EstadoEnvio == (EstadoEnvio)Enum.Parse(typeof(EstadoEnvio),ddlEstado.SelectedItem.ToString()));
            //Session["ListaPedidosFiltrada"] = ListaFiltrada;
            dgvPedidos.DataSource = ListaFiltrada;
            dgvPedidos.DataBind();
        }
    }
}