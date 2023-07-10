﻿using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;



namespace E_Commerce_Vista
{
    public partial class CompletarDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MedioPagoNegocio medioPagoNegocio = new MedioPagoNegocio();
                List<MedioPago> medioPagos = medioPagoNegocio.listarMediosPago();

                


                ddlMedioPago.DataSource = medioPagos;
                ddlMedioPago.DataValueField = "Id";
                ddlMedioPago.DataTextField = "NombrePago";
                ddlMedioPago.DataBind();



                cargarProvincias();
               
            }



            if (Session["Carrito"] != null)
            {


                Carrito carrito = (Carrito)Session["Carrito"];


                repCarrito.DataSource = carrito.ListaArticulo;
                repCarrito.DataBind();
                lblPrecioTotal.Text = carrito.PrecioTotal.ToString();

            }

        }

        

        public void cargarProvincias()
        {
            DomicilioNegocio negocio = new DomicilioNegocio();
            List<Domicilio> provincias = new List<Domicilio>();
            provincias=negocio.listarProvincias();

            foreach(Domicilio domicilio in provincias)
            {
                ddlProvincia.Items.Add(domicilio.Provincia);
            }

            List<Domicilio> localidades = new List<Domicilio>();
            localidades = negocio.listarLocalidades();
            ddlLocalidad.Items.Add(localidades[0].Localidad);


        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {   
            ddlLocalidad.Items.Clear();
            DomicilioNegocio negocio = new DomicilioNegocio();
            List<Domicilio> provincias = provincias = negocio.listarProvincias();

            Domicilio provinciaSeleccionada = provincias.Find(x => x.Provincia==ddlProvincia.SelectedValue);
            int idProvincia = provinciaSeleccionada.IdProvincia;
            
            List<Domicilio> localidades = negocio.listarLocalidadesPorProvincia(idProvincia);
            foreach (Domicilio domicilio in localidades)
            {   
                ddlLocalidad.Items.Add(domicilio.Localidad);
            }

        }

        protected void repCarrito_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Dominio.Articulo art = (Dominio.Articulo)e.Item.DataItem;
                System.Web.UI.WebControls.Image imgImagen = (System.Web.UI.WebControls.Image)e.Item.FindControl("ImagenCarrito");



                /* Place holder si la imagen original falla */
                string urlImagenOriginal = art.Imagenes[0].UrlImagen;
                string urlImagenReemplazo = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";

                imgImagen.ImageUrl = urlImagenOriginal;
                imgImagen.Attributes["onerror"] = "this.onerror=null;this.src='" + urlImagenReemplazo + "';";

                //ESTO SE ENCARGA DE AJUSTAR LA CANTIDAD DE ARTICULOS
                Label lblCantidad = (Label)e.Item.FindControl("lblCantidad");
                if (art != null && lblCantidad != null && Session["Carrito"] is Carrito carrito)
                {
                    // Obtener la cantidad correspondiente del diccionario utilizando el nuevo método ObtenerCantidadArticulo
                    int cantidad = carrito.ObtenerCantidadArticulo(art.Id);
                    lblCantidad.Text = cantidad.ToString();
                }
                //updatePanelCarrito.Update();




            }

          

        }

        protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlVivienda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDireccion.Text.Trim()))
            {
                txtDireccion.CssClass = "form-control is-invalid";
                errorDireccion.InnerText = "Campo obligatorio";
            }
            else
            {
                txtDireccion.CssClass = "form-control is-valid";
            }
        }

        protected void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoPostal.Text.Trim()))
            {
                txtCodigoPostal.CssClass = "form-control is-invalid";
                errorCodigoPostal.InnerText = "Campo obligatorio";
            }
            else
            {
                txtCodigoPostal.CssClass = "form-control is-valid";
            }
        }

        protected void txtDepartamento_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDepartamento.Text.Trim()))
            {
                txtDepartamento.CssClass = "form-control is-invalid";
                errorDepartamento.InnerText = "Campo obligatorio";
            }
            else
            {
                txtDepartamento.CssClass = "form-control is-valid";
            }
        }

        public bool validarFormulario()
        {   
            if (ddlVivienda.SelectedValue == "Departamento" && txtDepartamento.CssClass == "form-control is-valid" && txtCodigoPostal.CssClass == "form-control is-valid"
                && txtDireccion.CssClass == "form-control is-valid")
            {
                return true;
            }
            else if (ddlVivienda.SelectedValue == "Casa" && txtDepartamento.CssClass == "form-control is-invalid" && txtCodigoPostal.CssClass == "form-control is-valid"
                && txtDireccion.CssClass == "form-control is-valid")
                {
                    return true;
                }
            else
            {
            return false;

            }
        }
        protected void btnRealizarPedido_Click(object sender, EventArgs e)
        {

            //validar que este todo ok
            try
            {
                if (validarFormulario())
                {
                    Pedido pedido = new Pedido();
                   Cliente cliente = new Cliente();
                    PedidoNegocio negocio = new PedidoNegocio();
                    pedido.MedioDePago = new MedioPago();
                    pedido.CarritoPedidos = new Carrito();


                    cliente = (Cliente)Session["ClienteLogueado"];
                    pedido.Cliente = cliente;
                    pedido.MedioDePago.Id = int.Parse(ddlMedioPago.SelectedValue);
                    pedido.FechaPedido = DateTime.Now;
                    pedido.EstadoEnvio = EstadoEnvio.RECIBIDO;
                    pedido.CarritoPedidos = (Carrito)Session["Carrito"];
                    pedido.ImporteTotal = pedido.CarritoPedidos.PrecioTotal;


                    //HACER INSERT DEL PEDIDO CON TODOS SUS METODOS EN PEDIDONEGOCIO
                    negocio.GenerarPedidoConSp(pedido);
                    negocio.GenerarArticulosPedidoConSp(pedido);

                    Response.Redirect("PedidoRealizado.aspx",false);
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("error.aspx", false);
            }
         
        }

        protected void ddlMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}