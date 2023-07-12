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

                    lblProvincia.Text = pedido.Cliente.DomicilioCliente.Provincia;
                    lblLocalidad.Text = pedido.Cliente.DomicilioCliente.Localidad;
                    lblCodigoPostal.Text = pedido.Cliente.DomicilioCliente.CodigoPostal.ToString();
                    lblDireccion.Text = pedido.Cliente.DomicilioCliente.Direccion;
                    if (!string.IsNullOrEmpty(pedido.Cliente.DomicilioCliente.NumeroDepartamento))
                    {
                        lblNumeroDepartamento.Text = pedido.Cliente.DomicilioCliente.NumeroDepartamento;
                    }
                    else
                    {
                        lblNumeroDepartamento.Text = "-";
                    }

                    //ESTADO DEL PEDIDO PAGADO / ENVIADO
                    lblPagado.Text = pedido.EstadoPago.ToString();
                    lblEstadoPedido.Text = pedido.EstadoEnvio.ToString();
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
    }
}