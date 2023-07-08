using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MedioPagoNegocio
    {

        public List<MedioPago> listarMediosPago()
        {

            List<MedioPago> lista = new List<MedioPago>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id, nombre from MediosPago");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    MedioPago aux = new MedioPago();

                    aux.Id = (int)datos.Lector["id"];
                    aux.NombrePago = (string)datos.Lector["nombre"];

                    lista.Add(aux);

                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                datos.cerrarConexion();
            }

        }



    }
}
