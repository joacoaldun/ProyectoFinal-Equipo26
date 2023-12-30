using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Dominio;
using Negocio;

namespace E_Commerce_Vista
{
    public partial class FormularioPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("Default.aspx", false);

            }
            if (!IsPostBack)
            {

                if (Request.QueryString["id"] != null)
                {
                    string nropedido = Request.QueryString["id"].ToString();
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

                    //MEDIO DE PAGO - VIENE DE BD
                    txtMedioPago.Text = pedido.MedioDePago.NombrePago;

                    //CODIGO DE PAGO - INGRESAR SI SE QUIERE PONER COMO "PAGADO"
                    txtCodigoPago.Text = pedido.CodigoPago.ToString(); 
                    
                    //DDL MEDIO DE ENVIO - DESPLEGABLE DE BD
                    MedioEnvioNegocio envioNegocio=new MedioEnvioNegocio();
                    List<MedioEnvio> listaEnvios = envioNegocio.listarMediosEnvio();
                    ddlMedioEnvio.DataSource = listaEnvios;
                    ddlMedioEnvio.DataValueField = "Id";
                    ddlMedioEnvio.DataTextField = "NombreEnvio";
                    ddlMedioEnvio.DataBind();

                    //CODIGO ENVIO - SI SE QUIERE PONER COMO ENVIADO PONER CODIGO DE ENVIO
                    txtCodigoEnvio.Text = pedido.CodigoEnvio.ToString();

                    //DDL ESTADO PEDIDO + ENVIADO
                    string pagado = pedido.EstadoPago ? "Abonado" : "No abonado";
                    ddlPagado.SelectedValue = pagado;
                    ddlPagado.DataBind();

                    //DDL ESTADO ENVIO DEL ENUM
                    /*ddlEstadoPedido.DataSource = Enum.GetValues(typeof(EstadoEnvio));
                    
                    ddlEstadoPedido.DataBind();
                    ddlEstadoPedido.SelectedValue = pedido.EstadoEnvio.ToString();*/

                    //DDL ESTADOENVIO HABILITADO SEGUN ESTADO ENVIO
                    ddlEstadoPedido.Items.Clear();
                    EstadoEnvio estadoEnvioPedido = pedido.EstadoEnvio;

                    

                    if (!pedido.EstadoPago)
                    {
                        ddlEstadoPedido.Items.Add("RECIBIDO");
                        ddlEstadoPedido.Items.Add("CANCELADO");
                        divPago.Visible = false;

                        if (pedido.EstadoEnvio == EstadoEnvio.CANCELADO)
                        {
                            if (pedido.CodigoEnvio == 0)
                            {
                                divEnvio.Visible = false;
                                
                            }
                            if (pedido.CodigoPago == 0) {

                                divPago.Visible = false;    
                            }
                        }
                    }
                    else
                    {
                        ddlPagado.Enabled = false;
                        ddlPagado.Style["background-color"] = "grey";
                        ddlPagado.Style["color"] = "white";

                        txtCodigoPago.Enabled = false;
                        txtCodigoPago.Style["background-color"] = "grey";
                        txtCodigoPago.Style["color"] = "white";

                        if (estadoEnvioPedido == EstadoEnvio.RECIBIDO)
                        {
                            ddlEstadoPedido.Items.Add("RECIBIDO");
                            ddlEstadoPedido.Items.Add("PREPARACION");
                            ddlEstadoPedido.Items.Add("CANCELADO");
                        }
                        else if (estadoEnvioPedido == EstadoEnvio.PREPARACION)
                        {
                            ddlEstadoPedido.Items.Add("PREPARACION");
                            ddlEstadoPedido.Items.Add("ENCAMINO");
                            ddlEstadoPedido.Items.Add("CANCELADO");
                        }
                        else if (estadoEnvioPedido == EstadoEnvio.ENCAMINO)
                        {
                            ddlEstadoPedido.Items.Add("ENCAMINO");
                            ddlEstadoPedido.Items.Add("ENTREGADO");
                            ddlEstadoPedido.Items.Add("CANCELADO");

                        }
                        else
                        {
                            ddlEstadoPedido.Items.Add("ENTREGADO");
                        }
                    }

                    if (estadoEnvioPedido == EstadoEnvio.CANCELADO || estadoEnvioPedido == EstadoEnvio.ENTREGADO)
                    {
                        ddlEstadoPedido.Enabled = false;
                        ddlEstadoPedido.Style["background-color"] = "grey";
                        ddlEstadoPedido.Style["color"] = "white";

                        ddlPagado.Enabled = false;
                        ddlPagado.Style["background-color"] = "grey";
                        ddlPagado.Style["color"] = "white";

                        btnGuardarCambios.Visible = false;


                        

                    }

                    if (pedido.CodigoEnvio == 0)
                    {
                        divEnvio.Visible = false;

                    }
                    else
                    {
                        ddlMedioEnvio.SelectedValue = pedido.MedioDeEnvio.Id.ToString();
                        ddlMedioEnvio.Enabled = false;
                        ddlMedioEnvio.Style["background-color"] = "grey";
                        ddlMedioEnvio.Style["color"] = "white";
                        txtCodigoEnvio.Enabled = false;
                        txtCodigoEnvio.Style["background-color"] = "grey";
                        txtCodigoEnvio.Style["color"] = "white";
                    }

                    ddlEstadoPedido.SelectedValue = estadoEnvioPedido.ToString();


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

                    
                  
                    decimal precio = art.Precio;

                    
                    string precioFormateado = string.Format("{0:#,##0.00}", precio);

                   
                    lblPrecio.Text = "$"+precioFormateado;

                }

            }

        }

        

       


        protected void ddlEstadoPedido_TextChanged(object sender, EventArgs e)
        {
            Pedido pedido = (Pedido)Session["PedidoActual"];
            EstadoEnvio estadoActual = pedido.EstadoEnvio;
            bool estadoPago = pedido.EstadoPago;

            EstadoEnvio estadoSeleccionado = (EstadoEnvio)Enum.Parse(typeof(EstadoEnvio), ddlEstadoPedido.SelectedValue);
            if (!estadoPago)
            {
                if (ddlPagado.SelectedValue == "No abonado" && estadoActual != estadoSeleccionado)
                {
                    btnGuardarCambios.Visible = true;
                    lblMensajeError.Visible = false;
                    updatePanelMensajeError.Update();
                }
                else if (ddlPagado.SelectedValue == "Abonado" && estadoActual != estadoSeleccionado)
                {
                    btnGuardarCambios.Visible = false;
                    MostrarMensajeError("No puede cancelarse y abonarse un pedido al mismo tiempo");
                    
                }
                else
                {
                    btnGuardarCambios.Visible = true;
                    lblMensajeError.Visible = false;
                    updatePanelMensajeError.Update();
                }
                
            }
            else
            {


                switch (estadoActual)
                {
                    case EstadoEnvio.RECIBIDO:
                        if (ddlEstadoPedido.SelectedValue != "RECIBIDO")
                        {
                            btnGuardarCambios.Visible = true;
                            lblMensajeError.Visible = false;
                            updatePanelMensajeError.Update();

                        }
                        else
                        {
                            btnGuardarCambios.Visible = false;
                            MostrarMensajeError("Para guardar cambios debe modificar el estado del envio");
                        }
                        
                        break;
                    case EstadoEnvio.PREPARACION:
                        if (ddlEstadoPedido.SelectedValue != "PREPARACION" )
                        {
                            btnGuardarCambios.Visible = true;
                            lblMensajeError.Visible = false;
                            updatePanelMensajeError.Update();
                            if (ddlEstadoPedido.SelectedValue == "ENCAMINO")
                            {
                                divEnvio.Visible = true;
                            }
                            else
                            {
                                divEnvio.Visible = false;
                            }
                        }
                        else{
                            divEnvio.Visible = false;
                            btnGuardarCambios.Visible = false;
                            MostrarMensajeError("Para guardar cambios debe modificar el estado del envio");
                        }

                        break;
                    case EstadoEnvio.ENCAMINO:
                        if (ddlEstadoPedido.SelectedValue != "ENCAMINO" )
                        {
                            btnGuardarCambios.Visible = true;
                            lblMensajeError.Visible = false;
                            updatePanelMensajeError.Update();

                            

                        }
                        else{
                            btnGuardarCambios.Visible = false;
                            MostrarMensajeError("Para guardar cambios debe modificar el estado del envio");
                        }

                        break;
                    
                }

            }
           
            
            

        }

        public void MostrarMensajeError(string msg)
        {
            lblMensajeError.Text = msg;
            lblMensajeError.Visible = true;
            updatePanelMensajeError.Update();

            
        }


        /*public bool validarCambios()
        {   
            
            
               
            Pedido pedido = (Pedido)Session["PedidoActual"];
            bool estadoPago = pedido.EstadoPago;
            


            if (estadoPago == false)
            {

                if (ddlPagado.SelectedValue == "No abonado" && (ddlEstadoPedido.SelectedValue == "CANCELADO" || ddlEstadoPedido.SelectedValue == "RECIBIDO"))
                {
                    return false;
                }
                else if (ddlPagado.SelectedValue == "No abonado" && ddlEstadoPedido.SelectedValue != "CANCELADO" && ddlEstadoPedido.SelectedValue != "RECIBIDO")
                {
                    return false;
                }
                return true;
            }

            else if (estadoPago == true && pedido.EstadoEnvio == EstadoEnvio.RECIBIDO && ddlEstadoPedido.SelectedValue != "PREPARACION" && ddlEstadoPedido.SelectedValue != "CANCELADO")
            {
                return false;
            }
            else if (estadoPago == true && ddlEstadoPedido.SelectedValue == "No abonado")
            {
                return false;
            }
            else if (pedido.EstadoEnvio == EstadoEnvio.CANCELADO || pedido.EstadoEnvio == EstadoEnvio.ENTREGADO)
            {
                return false;
            }

           
            
            return true;
        }*/

        



        protected void ddlPagado_TextChanged(object sender, EventArgs e)
        {
            Pedido pedido = (Pedido)Session["PedidoActual"];
            EstadoEnvio estadoActual = pedido.EstadoEnvio;
            bool estadoPago = pedido.EstadoPago;
            
            

            if (!estadoPago)
            {
                divPago.Visible = false;
                EstadoEnvio estadoSeleccionado = (EstadoEnvio)Enum.Parse(typeof(EstadoEnvio), ddlEstadoPedido.SelectedValue);
                if (ddlPagado.SelectedValue == "No abonado" && estadoActual == estadoSeleccionado )
                {
                    btnGuardarCambios.Visible = false;
                    MostrarMensajeError ("El pedido ya se encuentra catalogado como no abonado");
                   
                    
                }
                
                

                else if (ddlPagado.SelectedValue == "No abonado" && estadoActual != estadoSeleccionado)
                {
                    btnGuardarCambios.Visible = true;

                    lblMensajeError.Visible = false;
                    updatePanelMensajeError.Update();
                }
                else
                {
                    divPago.Visible = true;
                    txtCodigoPago.Text = string.Empty;
                    btnGuardarCambios.Visible = true;

                    lblMensajeError.Visible = false;
                    updatePanelMensajeError.Update();
                }

            }
            else
            {
                btnGuardarCambios.Visible = true;

                lblMensajeError.Visible = false;
                updatePanelMensajeError.Update();
            }
            

        }

        protected void timerMensajeError_Tick(object sender, EventArgs e)
        {
            lblMensajeError.Visible = false;
           
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                //if (validarCambios())
                //{
                    
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

                //SI ESTA PAGADO
                pedido.CodigoPago = string.IsNullOrEmpty(txtCodigoPago.Text) ? 0 : int.Parse(txtCodigoPago.Text);


                //SI ESTA MODO "EN ENVIO"

                MedioEnvio medioEnvio = new MedioEnvio
                {
                    Id = int.Parse(ddlMedioEnvio.SelectedValue),
                    NombreEnvio = ddlMedioEnvio.SelectedItem.Text

                };
                pedido.MedioDeEnvio = medioEnvio;
                pedido.CodigoEnvio = string.IsNullOrEmpty(txtCodigoEnvio.Text) ? 0 : int.Parse(txtCodigoEnvio.Text);
                
               
   
                   //Hacemos el update con los cambios

                   PedidoNegocio negocio = new PedidoNegocio();
                    negocio.modificarPedido(pedido);
                   



                //}
                
                Response.Redirect("GestionPedidos.aspx",false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("error.aspx", false);
            }


        }

        
    }
}