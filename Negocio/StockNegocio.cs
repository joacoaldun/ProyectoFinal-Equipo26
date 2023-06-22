using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class StockNegocio
    {


        public void agregarStockConSP(Articulo nuevo)
        {
            int id = devolverUltimoIdArticulo();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SPagregarStock");
                datos.setearParametros("@Cantidad", nuevo.StockArticulo.Cantidad);
                datos.setearParametros("@IdArticulo", id);
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


        public void modificarStockConSP(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SPmodificarStock");
                datos.setearParametros("@Cantidad", articulo.StockArticulo.Cantidad);
                datos.setearParametros("@IdArticulo", articulo.Id);
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



        public int devolverUltimoIdArticulo()
        {

            AccesoDatos datos = new AccesoDatos();
            //Obtengo el id de este ultimo articulo para guardarlo en stock.
            try
            {
                datos.setearConsulta("select max(id) as MaxId from Articulos");
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

        public bool descontarStock(Articulo articulo)
        {
            if (articulo.StockArticulo.Cantidad  > 0)
            {
                articulo.StockArticulo.Cantidad--;
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
