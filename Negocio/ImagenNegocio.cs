using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        public void guardarListaImagenes(Articulo nuevo)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            //Obtengo el id de este ultimo articulo para guardarlo en imagenes.

            int id = negocio.devolverUltimoIdArticulo();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                foreach (var item in nuevo.Imagenes)
                {
                    datos.setearConsulta("insert into imagenes(idArticulo, ImagenUrl) values (" + id + ", '" + item.UrlImagen.ToString() + "' )");





                    datos.ejecutarAccion();
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


        public List<Imagen> listarImagenes()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Imagen> lista = new List<Imagen>();


            try
            {
                datos.setearConsulta("select Id, IdArticulo, ImagenUrl from Imagenes");

                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {

                    Imagen imagen = new Imagen();

                    imagen.Id = (int)datos.Lector["Id"];
                    imagen.IdArticulo = (int)datos.Lector["IdArticulo"];
                    imagen.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    lista.Add(imagen);

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


        public void AgregarModificarImagenes(List<Imagen> imagenes)
        {
            AccesoDatos datos = new AccesoDatos();

            List<Imagen> imagenesBD = listarImagenes();

            foreach (var item in imagenes)
            {
                if (item.Id == 0)
                {
                    agregarImagenBD(item);

                }
                else
                {


                    modificarImagenBD(item);


                }

            }





        }

        public void agregarImagenBD(Imagen imagen)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into Imagenes(IdArticulo, ImagenUrl) values(@IdArticulo, @ImagenUrl)");
                datos.setearParametros("@IdArticulo", imagen.IdArticulo);
                datos.setearParametros("@ImagenUrl", imagen.UrlImagen);

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

        public void modificarImagenBD(Imagen imagen)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update Imagenes set ImagenUrl = @ImagenUrl where Id = @Id");
                datos.setearParametros("@ImagenUrl", imagen.UrlImagen);
                datos.setearParametros("@Id", imagen.Id);

                datos.ejecutarConsulta();

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


        public void eliminarImagenes(List<int> ids)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                foreach (int id in ids)
                {

                    if (id != 0)
                    {
                        datos.setearConsulta("delete from Imagenes where Id = @Id ");
                        datos.setearParametros("@Id", id);

                        datos.ejecutarAccion();

                        datos.limpiarParametros();
                    }

                 }

            }
            catch (Exception)
            {

                throw;
            }
            finally {
                datos.cerrarConexion();
            
            
            }

        }


    }
}
