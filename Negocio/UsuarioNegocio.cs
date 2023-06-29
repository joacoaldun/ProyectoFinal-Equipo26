using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {

        public List<Cliente> listarClientesConSp() { 
        
          AccesoDatos datos = new AccesoDatos();

            try
            {
                
                datos.setearProcedimiento("SPListarClientes");
                datos.ejecutarConsulta();
                List<Cliente> lista = new List<Cliente>();



                while (datos.Lector.Read())
                {
                    //Validaciones BD
                    int id = (int)datos.Lector["Id"];
                    string nombre = datos.Lector["Nombre"] == DBNull.Value ? "Sin Nombre" : (string)datos.Lector["Nombre"];
                    string apellido = datos.Lector["Apellido"] == DBNull.Value ? "Sin Apellido" : (string)datos.Lector["Apellido"];
                    string username = datos.Lector["Username"] == DBNull.Value ? "Sin Username" : (string)datos.Lector["Username"];
                    int tipoAcceso  = datos.Lector["TipoAcceso"] == DBNull.Value ? 2 : (int)datos.Lector["TipoAcceso"];

                    string email = datos.Lector["Email"] == DBNull.Value ? "Sin Email" : (string)datos.Lector["Email"];
                    string dni = datos.Lector["Dni"] == DBNull.Value ? "Sin Dni" : (string)datos.Lector["Dni"];

                    DateTime fechaNacimiento = datos.Lector["FechaNacimiento"] == DBNull.Value ? DateTime.Today : (DateTime)datos.Lector["FechaNacimiento"];
                    bool estado = datos.Lector["EstadoActivo"] == DBNull.Value ? true : (bool)datos.Lector["EstadoActivo"];
                  

                  
                    //Verificamos si el articulo existe
                   
                        // Si no existe, creamos un nuevo artículo y lo agregamos a la lista

                       Cliente cliente = new Cliente

                        {
                            Id = id,
                           Nombre = nombre,
                            Apellido = apellido,
                            UserName = username,
                            TipoAcceso = (TipoAcceso)tipoAcceso,
                           Email = email,
                           Dni = dni,
                           FechaNacimiento = fechaNacimiento,
                            EstadoActivo = estado
                        };


                        lista.Add(cliente);
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
        public List<Admin> listarAdminsConSp()
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearProcedimiento("SPListarAdmins");
                datos.ejecutarConsulta();
                List<Admin> lista = new List<Admin>();



                while (datos.Lector.Read())
                {
                    //Validaciones BD
                    int id = (int)datos.Lector["Id"];
                    string nombre = datos.Lector["Nombre"] == DBNull.Value ? "Sin Nombre" : (string)datos.Lector["Nombre"];
                    string apellido = datos.Lector["Apellido"] == DBNull.Value ? "Sin Apellido" : (string)datos.Lector["Apellido"];
                    string username = datos.Lector["Username"] == DBNull.Value ? "Sin Username" : (string)datos.Lector["Username"];
                    int tipoAcceso = datos.Lector["TipoAcceso"] == DBNull.Value ? 1 : (int)datos.Lector["TipoAcceso"];

                    string email = datos.Lector["Email"] == DBNull.Value ? "Sin Email" : (string)datos.Lector["Email"];
                    bool estado = datos.Lector["EstadoActivo"] == DBNull.Value ? true : (bool)datos.Lector["EstadoActivo"];



                    //Verificamos si el articulo existe

                    // Si no existe, creamos un nuevo artículo y lo agregamos a la lista

                    Admin admin = new Admin

                    {
                        Id = id,
                        Nombre = nombre,
                        Apellido = apellido,
                        UserName = username,
                        TipoAcceso = (TipoAcceso)tipoAcceso,
                        Email = email,
                        EstadoActivo= estado
                        
                    };


                    lista.Add(admin);
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



    }
}
