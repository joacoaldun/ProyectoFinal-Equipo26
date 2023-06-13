using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listarConSP()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //datos.setearConsulta("SELECT a.Id, Codigo, Nombre, a.Descripcion as DescripcionArticulo, Precio,m.Id as IdMarca, m.Descripcion as NombreMarca,c.Id as IdCategoria, c.Descripcion as NombreCategoria, i.ImagenUrl as imagen from ARTICULOS a left join MARCAS m on a.IdMarca=m.Id left join CATEGORIAS c on a.IdCategoria=c.Id left join IMAGENES i on a.Id=i.IdArticulo ");
                datos.setearProcedimiento("storedListar");
                datos.ejecutarConsulta();
                List<Articulo> lista = new List<Articulo>();



                while (datos.Lector.Read())
                {
                    //Validaciones BD
                    int id = (int)datos.Lector["Id"];
                    string codigoArt = datos.Lector["Codigo"] == DBNull.Value ? "Sin codigo" : (string)datos.Lector["Codigo"];
                    string descripcion = datos.Lector["DescripcionArticulo"] == DBNull.Value ? "Sin descripcion" : (string)datos.Lector["DescripcionArticulo"];
                    decimal precio = datos.Lector["Precio"] == DBNull.Value ? 0 : (decimal)datos.Lector["Precio"];
                    string nombre = datos.Lector["Nombre"] == DBNull.Value ? "Sin nombre" : (string)datos.Lector["Nombre"];


                    int idArticuloImagen = datos.Lector["IdArticuloImagen"] == DBNull.Value ? -1 : (int)datos.Lector["IdArticuloImagen"];
                    int idImagen = datos.Lector["IdImagen"] == DBNull.Value ? -1 : (int)datos.Lector["IdImagen"];
                    string urlImagen = datos.Lector["imagen"] == DBNull.Value ? "https://t3.ftcdn.net/jpg/02/48/42/64/240_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg" : (string)datos.Lector["imagen"];
                    int idCategorias = datos.Lector["IdCategoria"] == DBNull.Value ? -1 : (int)datos.Lector["IdCategoria"];
                    string categorias = datos.Lector["NombreCategoria"] == DBNull.Value ? "Sin categoria" : (string)datos.Lector["NombreCategoria"];
                    int idMarcas = datos.Lector["IdMarca"] == DBNull.Value ? -1 : (int)datos.Lector["IdMarca"];
                    string marcas = datos.Lector["NombreMarca"] == DBNull.Value ? "Sin marca" : (string)datos.Lector["NombreMarca"];

                    precio = Math.Round(precio, 2);
                    //Verificamos si el articulo existe
                    Articulo articulo = lista.FirstOrDefault(a => a.Id == id);
                    if (articulo == null)
                    {
                        // Si no existe, creamos un nuevo artículo y lo agregamos a la lista

                        articulo = new Articulo

                        {
                            Id = id,
                            CodigoArticulo = codigoArt,
                            Nombre = nombre,
                            Descripcion = descripcion,
                            Precio = precio,

                            Categorias = new Categoria
                            {
                                Id = idCategorias,
                                NombreCategoria = categorias
                            },
                            Marcas = new Marca
                            {
                                Id = idMarcas,
                                NombreMarca = marcas
                            },


                            Imagenes = new List<Imagen>() // Inicializamos la lista de imagenes del artículo
                        };


                        lista.Add(articulo);
                    }
                    //Si existe, agregamos la URL de la imagen a la lista de imagenes del artículo
                    Imagen imagen = new Imagen
                    {
                        Id = idImagen,
                        UrlImagen = urlImagen,
                        IdArticulo = idArticuloImagen
                    };

                    articulo.Imagenes.Add(imagen);


                }
                
                return
                    lista;
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
