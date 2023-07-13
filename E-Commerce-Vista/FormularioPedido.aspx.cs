using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace E_Commerce_Vista
{
    public partial class FormularioPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["id"] != null)
                {
                    string nropedido = Request.QueryString["id"].ToString();
                    lblNroPedido.Text = "Pedido NRO. #" + nropedido;

                    //CARGAMOS LISTADO DE ARTICULOS DE PEDIDO
                    PedidoNegocio negocio = new PedidoNegocio();
                    List<Pedido> lista = new List<Pedido>();
                    lista = negocio.listarPedidosConSP();

                    Pedido pedido = new Pedido();
                    pedido = lista.Find(x => x.Id == int.Parse(nropedido));
                    Session["PedidoActual"] = pedido;


                    Carrito carrito = negocio.listarArticulosPedidosConSP(int.Parse(nropedido));
                    Session["CarritoPedidoABM"] = carrito;
                    repListadoArticulos.DataSource = carrito.ListaArticulo;
                    repListadoArticulos.DataBind();


                    lblPrecioTotal.Text = pedido.ImporteTotal.ToString();
                    //DATOS DEL CLIENTE
                    lblApellido.Text = pedido.Cliente.Apellido;
                    lblNombre.Text = pedido.Cliente.Nombre;
                    lblDni.Text = pedido.Cliente.Dni;
                    lblEmail.Text = pedido.Cliente.Email;


                    //DOMICILIO
                    //pedido.DomicilioPedido = new Domicilio();
                    lblProvincia.Text = pedido.DomicilioPedido.Provincia;
                    lblLocalidad.Text = pedido.DomicilioPedido.Localidad;
                    lblCodigoPostal.Text = pedido.DomicilioPedido.CodigoPostal.ToString();
                    lblDireccion.Text = pedido.DomicilioPedido.Direccion;
                    if (!string.IsNullOrEmpty(pedido.DomicilioPedido.NumeroDepartamento))
                    {
                        lblNumeroDepartamento.Text = pedido.DomicilioPedido.NumeroDepartamento;
                    }
                    else
                    {
                        lblNumeroDepartamento.Text = "-";
                    }


                    //lblProvincia.Text = pedido.Cliente.DomicilioCliente.Provincia;
                    //lblLocalidad.Text = pedido.Cliente.DomicilioCliente.Localidad;
                    //lblCodigoPostal.Text = pedido.Cliente.DomicilioCliente.CodigoPostal.ToString();
                    //lblDireccion.Text = pedido.Cliente.DomicilioCliente.Direccion;
                    //if (!string.IsNullOrEmpty(pedido.Cliente.DomicilioCliente.NumeroDepartamento))
                    //{
                    //    lblNumeroDepartamento.Text = pedido.Cliente.DomicilioCliente.NumeroDepartamento;
                    //}
                    //else
                    //{
                    //    lblNumeroDepartamento.Text = "-";
                    //}

                   

                    //DDL ESTADO PEDIDO + ENVIADO
                    string pagado = pedido.EstadoPago ? "Abonado" : "No abonado";
                    ddlPagado.SelectedValue = pagado;
                    ddlPagado.DataBind();

                    ddlEstadoPedido.DataSource = Enum.GetValues(typeof(EstadoEnvio));
                    ddlEstadoPedido.DataBind();
                    ddlEstadoPedido.SelectedValue = pedido.EstadoEnvio.ToString();
                    

                }
                else
                {
                    lblNroPedido.Text = "No se seleccionó ningun pedido";
                }


            }



        }

        protected void repListadoArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Dominio.Articulo art = (Dominio.Articulo)e.Item.DataItem;
                System.Web.UI.WebControls.Image imgImagen = (System.Web.UI.WebControls.Image)e.Item.FindControl("ImagenArticulo");


                /* Place holder si la imagen original falla */
                string urlImagenOriginal = art.Imagenes[0].UrlImagen;
                string urlImagenReemplazo = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";

                imgImagen.ImageUrl = urlImagenOriginal;
                imgImagen.Attributes["onerror"] = "this.onerror=null;this.src='" + urlImagenReemplazo + "';";



                //ESTO SE ENCARGA DE AJUSTAR LA CANTIDAD DE ARTICULOS
                Label lblCantidad = (Label)e.Item.FindControl("lblCantidad");
                if (art != null && lblCantidad != null && Session["CarritoPedidoABM"] is Carrito carrito)
                {
                    // Obtener la cantidad correspondiente del diccionario utilizando el nuevo método ObtenerCantidadArticulo
                    int cantidad = carrito.ObtenerCantidadArticulo(art.Id);
                    lblCantidad.Text = cantidad.ToString();
                }

            }

        }

        protected void ddlEstadoPedido_TextChanged(object sender, EventArgs e)
        {
            if(ddlPagado.SelectedValue=="No abonado" && ddlEstadoPedido.SelectedValue != "CANCELADO")
            {
                lblMensajeError.Text = "Para poder cambiar el estado del pedido primero debe ser abonado";
                lblMensajeError.Visible = true;
                updatePanelMensajeError.Update();

            }
            else
            {
                lblMensajeError.Visible = false;
                updatePanelMensajeError.Update();
            }


        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarCambios())
                {
                    Pedido pedido = new Pedido();
                    pedido = (Pedido)Session["PedidoActual"];

                    if (ddlPagado.Text == "Abonado")
                    {
                        pedido.EstadoPago = true;

                    }
                    else
                    {
                        pedido.EstadoPago = false;
                    }

                    pedido.EstadoEnvio = (EstadoEnvio)Enum.Parse(typeof(EstadoEnvio), ddlEstadoPedido.SelectedItem.ToString());
                    
                    //Hacemos el update con los cambios

                    PedidoNegocio negocio= new PedidoNegocio();
                    negocio.modificarPedido(pedido);

                  

                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("error.aspx", false);
            }
           

        }

        public bool validarCambios()
        {           
          if (ddlPagado.SelectedValue == "No abonado" && ddlEstadoPedido.SelectedValue != "CANCELADO" )
          {
              return false;
          }
          else
          {
              return true;
          }
        }

        protected void timerMensajeError_Tick(object sender, EventArgs e)
        {
            lblMensajeError.Visible = false;

            updatePanelMensajeError.Update();
        }

        protected void ddlPagado_TextChanged(object sender, EventArgs e)
        {
            if (ddlPagado.SelectedValue == "Abonado")
            {
                lblMensajeError.Visible = false;
                updatePanelMensajeError.Update();
            }
        }
    }
}