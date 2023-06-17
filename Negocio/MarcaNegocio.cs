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


        public void agregar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("Insert into Marcas(Descripcion, ImagenUrl) values (@Descripcion, @ImagenUrl)");
                datos.setearParametros("@Descripcion", marca.NombreMarca);
                datos.setearParametros("@ImagenUrl", marca.ImagenMarca);

                datos.ejecutarAccion();


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


        public void modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("UPDATE marcas SET descripcion = @descripcion, ImagenUrl=@ImagenUrl WHERE id= @id");
                datos.setearParametros("@Id", marca.Id);
                datos.setearParametros("@descripcion", marca.NombreMarca);
                datos.setearParametros("@ImagenUrl", marca.ImagenMarca);

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

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("delete from MARCAS where Id = @Id");
                datos.setearParametros("@Id", id);

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
