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

    }
}
