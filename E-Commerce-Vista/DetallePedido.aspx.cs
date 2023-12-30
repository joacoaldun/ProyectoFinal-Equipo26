﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace E_Commerce_Vista
{
    public partial class DetallePedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ClienteLogueado"] == null)
            {
                Response.Redirect("Default.aspx", false);

            }
            if (!IsPostBack)
            {

                if (Request.QueryString["id"] != null)
                {
                    string nropedido = Request.QueryString["id"].ToString();
                    //lblNroPedido.Text = "Pedido NRO. #" + nropedido;
                    lblNroPedido.Text = "Detalle del Pedido NRO. #" + nropedido;

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




                    //lblPrecioTotal.Text = pedido.ImporteTotal.ToString();

                    decimal precio = pedido.ImporteTotal;


                    string precioFormateado = string.Format("{0:#,##0.00}", precio);


                    lblPrecioTotal.Text = "$" + precioFormateado;


                    /*string precio = string.Format("{0:#,##0.00}", pedido.ImporteTotal.ToString());

                    lblPrecioTotal.Text = precio;
                    lblPrecioTotal.DataBind();*/


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


                  


                    //DDL ESTADO PEDIDO + ENVIADO
                    string pagado = pedido.EstadoPago ? "Abonado" : "No abonado";
                    lblPagado.Text = pagado;
                    

                    lblEstado.Text = pedido.EstadoEnvio.ToString();
                    txtMedioPago.Text = pedido.MedioDePago.NombrePago;

                    //CODIGO DE PAGO - INGRESAR SI SE QUIERE PONER COMO "PAGADO"
                    txtCodigoPago.Text = pedido.CodigoPago.ToString();                 


                    //CODIGO ENVIO - SI SE QUIERE PONER COMO ENVIADO PONER CODIGO DE ENVIO
                    txtCodigoEnvio.Text = pedido.CodigoEnvio.ToString();

                    if (pedido.CodigoEnvio == 0)
                    {   
                        divEnvio.Visible = false;
                    }
                    else
                    {
                        
                        txtMedioEnvio.Text = pedido.MedioDeEnvio.NombreEnvio;
                    }
                    if (pedido.CodigoPago == 0)
                    {
                        divPago.Visible = false;
                    }



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
                Label lblPrecio = (Label)e.Item.FindControl("lblPrecio");
                if (art != null && lblCantidad != null && Session["CarritoPedidoABM"] is Carrito carrito)
                {
                    // Obtener la cantidad correspondiente del diccionario utilizando el nuevo método ObtenerCantidadArticulo
                    int cantidad = carrito.ObtenerCantidadArticulo(art.Id);
                    lblCantidad.Text = cantidad.ToString();

                    //lblPrecio.Text = art.Precio.ToString();
                    /*string precio = string.Format("{0:#,##0.00}", art.Precio.ToString());

                    lblPrecio.Text = precio;
                    lblPrecio.DataBind();*/
                    decimal precio = art.Precio;


                    string precioFormateado = string.Format("{0:#,##0.00}", precio);


                    lblPrecio.Text = "$" + precioFormateado;


                }

            }


        }
    }
}