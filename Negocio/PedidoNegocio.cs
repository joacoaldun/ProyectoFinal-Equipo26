using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class PedidoNegocio
    {


        public void GenerarPedidoConSp(Pedido pedido)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SPGenerarPedido");


                datos.setearParametros("@IdEstadoPedido", pedido.EstadoEnvio);
                datos.setearParametros("@IdCliente", pedido.Cliente.Id);
                datos.setearParametros("@IdMedioPago", pedido.MedioDePago.Id);
                datos.setearParametros("@FechaPedido", pedido.FechaPedido);
                datos.setearParametros("@ImporteTotal", pedido.ImporteTotal);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                datos.cerrarConexion();

            }


        }

        public void GenerarArticulosPedidoConSp(Pedido pedido)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {

                int id = TraerIdUltimoPedido();

                foreach (var item in pedido.CarritoPedidos.ArticulosCantidad)
                {


                    datos.setearProcedimiento("SPGenerarArticulosPedido");

                    datos.setearParametros("@IdPedido", id);
                    datos.setearParametros("@IdArticulo", item.Key);
                    datos.setearParametros("@Cantidad", item.Value);

                    datos.ejecutarAccion();

                    datos.limpiarParametros();

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally {

                datos.cerrarConexion();
            
            }







        }

        public int TraerIdUltimoPedido()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select max(Id) as MaxId from Pedido");
                datos.ejecutarConsulta();

                if (datos.Lector.Read())
                {
                    int id = (int)datos.Lector["MaxId"];
                    return id;
                }
                else
                {
                    return 0;

                }





            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                datos.cerrarConexion();

            }



        }


        public List<Pedido> listarPedidosConSP()
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("listarPedidosSP");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Pedido pedido = new Pedido();

                    pedido.Id = (int)datos.Lector["IdPedido"];
                    pedido.EstadoPago = (bool)datos.Lector["EstadoPago"];
                    pedido.ImporteTotal = Math.Round((decimal)datos.Lector["ImporteTotal"], 2);

                    Cliente cliente = new Cliente
                    {
                        Id = (int)datos.Lector["IdCliente"],
                        Apellido = (string)datos.Lector["Apellido"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Email = (string)datos.Lector["Email"],
                        Dni = (string)datos.Lector["Dni"],
                        DomicilioCliente = new Domicilio
                        {
                            CodigoPostal = (int)datos.Lector["CodigoPostal"],
                            Direccion = (string)datos.Lector["Direccion"],
                            NumeroDepartamento = datos.Lector["NumeroDepartamento"] == DBNull.Value ? "" : (string)datos.Lector["NumeroDepartamento"],
                            Localidad = (string)datos.Lector["Localidad"],
                            Provincia = (string)datos.Lector["Provincia"]
                        }
                    };
                    pedido.Cliente = cliente;

                    MedioPago medioPago = new MedioPago
                    {
                        Id = (int)datos.Lector["IdPago"],
                        NombrePago = (string)datos.Lector["MedioPago"]
                    };
                    pedido.MedioDePago = medioPago;


                    pedido.FechaPedido = (DateTime)datos.Lector["Fecha"];
                    pedido.EstadoEnvio = (EstadoEnvio)Enum.Parse(typeof(EstadoEnvio), (string)datos.Lector["EstadoPedido"]);

                    lista.Add(pedido);
                }



                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }


        public Carrito listarArticulosPedidosConSP(int idPedido)
        {
            Carrito carrito = new Carrito();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("listarArticulosPedidoSP");
                datos.setearParametros("@IdPedido", idPedido);
                datos.ejecutarConsulta();
                datos.limpiarParametros();
                List<Articulo> lista = new List<Articulo>();


                while (datos.Lector.Read())
                {
                    int id = (int)datos.Lector["Id"];
                    string nombre = datos.Lector["Nombre"] == DBNull.Value ? "Sin nombre" : (string)datos.Lector["Nombre"];
                    string urlImagen = datos.Lector["ImagenUrl"] == DBNull.Value ? "https://t3.ftcdn.net/jpg/02/48/42/64/240_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg" : (string)datos.Lector["ImagenUrl"];



                    Articulo articulo = lista.FirstOrDefault(a => a.Id == id);

                    if (articulo == null)
                    {

                        articulo = new Articulo
                        {
                            Id = (int)datos.Lector["Id"],
                            Nombre = (string)datos.Lector["Nombre"],
                            Imagenes = new List<Imagen>()


                        };
                        carrito.ArticulosCantidad[id] = datos.Lector["Cantidad"] == DBNull.Value ? 0 : (int)datos.Lector["Cantidad"];
                        //articulo.ImporteTotal = Math.Round((decimal)datos.Lector["ImporteTotal"], 2);



                        carrito.ListaArticulo.Add(articulo);

                    }
                    Imagen imagen = new Imagen
                    {
                        UrlImagen = urlImagen
                    };

                    articulo.Imagenes.Add(imagen);

                }



                return carrito;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }


        public void modificarPedido(Pedido pedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("modificarPedidoSP");
                datos.setearParametros("@IdPedido", pedido.Id);
                datos.setearParametros("@IdEstadoPedido", pedido.EstadoEnvio);
                datos.setearParametros("@EstadoPago", pedido.EstadoPago);

                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



    }
}
