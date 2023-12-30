using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MedioEnvioNegocio
    {

        public List<MedioEnvio> listarMediosEnvio()
        {

            List<MedioEnvio> lista = new List<MedioEnvio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select IdMedioEnvio, Descripcion from MediosEnvio");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    MedioEnvio aux = new MedioEnvio();

                    aux.Id = (int)datos.Lector["IdMedioEnvio"];
                    aux.NombreEnvio = (string)datos.Lector["Descripcion"];

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
