using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("maxigamingshop@hotmail.com", "Equipo26");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.office365.com";
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo) { 
            email= new MailMessage();
            email.From = new MailAddress("maxigamingshop@hotmail.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;//opcion de estilo html
            email.Body = cuerpo;

        }

        public void armarCorreoConPedido(string emailDestino, string asunto, Pedido pedido)
        {
            //string urlImagenReemplazo = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";
            int anchoColumnas = 100 / 3;
            string estiloAnchoColumnas = $"width:{anchoColumnas}%;";

            string cuerpo = "<div style=\"background-color:black; padding: 20px;\">";
            cuerpo += "<div style=\"background-color:black; border: 2px solid white;\">";
            
            
            cuerpo += "<h1 style=\"text-align:center; color:white; font-size: 40px;\">Muchas gracias por elegirnos!</h1>";
            cuerpo += "<p style=\"color:white; text-align:center;\">Hola " + pedido.Cliente.Nombre + ", te adjuntamos el detalle del pedido N#" + pedido.Id +".</ p > ";

            //detalle del pedido
            cuerpo += "<h1 style=\"text-align:center; color:white;\">Detalle del pedido</h1>";
            cuerpo += "<table style=\"width:100%; color:white;\">";

            cuerpo += "<tr>";
            cuerpo += $"<th style=\"text-align:center;{estiloAnchoColumnas}\">Producto</th>";
            cuerpo += $"<th style=\"text-align:center;{estiloAnchoColumnas}\">Cantidad</th>";
            cuerpo += $"<th style=\"text-align:center;{estiloAnchoColumnas}\">Subtotal</th>";
            cuerpo += "</tr>";

            foreach (var articulo in pedido.CarritoPedidos.ListaArticulo)
            {
                int cantidad = pedido.CarritoPedidos.ObtenerCantidadArticulo(articulo.Id);
                decimal subtotal = articulo.Precio * cantidad;

                cuerpo += "<tr>";
                cuerpo += $"<td style=\"text-align:center;{estiloAnchoColumnas}\">{articulo.Nombre}</td>";
                cuerpo += $"<td style=\"text-align:center;{estiloAnchoColumnas}\">{cantidad}</td>";
                cuerpo += $"<td style=\"text-align:center;{estiloAnchoColumnas}\">${subtotal}</td>";
                cuerpo += "</tr>";
            }

            cuerpo += "</table>";

            cuerpo += "<div style=\"text-align:center;\">";
            cuerpo += $"<div style=\"display:inline-block; width:33%; text-align:center; color:white;\">TOTAL:</div>"; 
            cuerpo += $"<div style=\"display:inline-block; width:33%; text-align:center;\"></div>"; 
            cuerpo += $"<div style=\"display:inline-block; width:33%; text-align:center;\"><p style=\"color:white;\">${pedido.CarritoPedidos.PrecioTotal}</p></div>";
            cuerpo += "</div>";

            //dire de entrega
            cuerpo += "<h1 style=\"text-align:center; color:white;\">Dirección de entrega:</h1>";
            cuerpo += $"<p style=\"color:white; text-align:center;\">Provincia: {pedido.DomicilioPedido.Provincia}</p>";
            cuerpo += $"<p style=\"color:white; text-align:center;\">Localidad: {pedido.DomicilioPedido.Localidad}</p>";
            cuerpo += $"<p style=\"color:white; text-align:center;\">Codigo postal: {pedido.DomicilioPedido.CodigoPostal}</p>";
            cuerpo += $"<p style=\"color:white; text-align:center;\">Direccion: {pedido.DomicilioPedido.Direccion}</p>";
            cuerpo += $"<p style=\"color:white; text-align:center;\">Número de departamento: {(pedido.DomicilioPedido.NumeroDepartamento != null ? pedido.DomicilioPedido.NumeroDepartamento : "-")}</p>";

            cuerpo += "<h1 style=\"text-align:center; color:white;\">¿Cómo continuamos?</h1>";
            cuerpo += "<p style=\"text-align:center;\"><span style=\"color:purple;\">★</span> <span style=\"color:white;\">En breve nos comunicaremos con usted para acordar los detalles del pago.</span> <span style=\"color:purple;\">★</span></p>";
            cuerpo += "<p style=\"text-align:center;\"><span style=\"color:purple;\">★</span> <span style=\"color:white;\">Ante cualquier duda, responda a este correo.</span> <span style=\"color:purple;\">★</span></p>";

            cuerpo += "</div>";
            cuerpo += "</div>";

            armarCorreo(emailDestino, asunto, cuerpo);
        }



        public void enviarCorreo()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
