using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {

        public List<Marca> listar()
        {

            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select id, descripcion, ImagenUrl from MARCAS");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {

                    Marca aux = new Marca();

                    aux.Id = (int)datos.Lector["id"];
                    aux.NombreMarca = (string)datos.Lector["descripcion"];
                    aux.ImagenMarca = (string)datos.Lector["ImagenUrl"];
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
