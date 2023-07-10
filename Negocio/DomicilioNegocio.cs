using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DomicilioNegocio
    {


        public List<Domicilio> listarProvincias()
        {

            List<Domicilio> lista = new List<Domicilio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select idProvincia, nombreProvincia from provincias");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {

                    Domicilio aux = new Domicilio();

                    aux.Provincia = (string)datos.Lector["nombreProvincia"];
                    aux.IdProvincia = (int)datos.Lector["idProvincia"];

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


        public List<Domicilio> listarLocalidades()
        {

            List<Domicilio> lista = new List<Domicilio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select idLocalidad, nombreLocalidad, idProvincia from localidades");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {

                    Domicilio aux = new Domicilio();

                    aux.Localidad = (string)datos.Lector["nombreLocalidad"];
                    aux.IdLocalidad = (int)datos.Lector["idLocalidad"];
                    aux.IdProvincia = (int)datos.Lector["idProvincia"];

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

        public List<Domicilio> listarLocalidadesPorProvincia(int id)
        {

            List<Domicilio> lista = new List<Domicilio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select idLocalidad, nombreLocalidad, idProvincia from localidades where idProvincia=@idProvincia");
                datos.setearParametros("@idProvincia", id);
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {

                    Domicilio aux = new Domicilio();

                    aux.Localidad = (string)datos.Lector["nombreLocalidad"];
                    aux.IdLocalidad = (int)datos.Lector["idLocalidad"];
                    aux.IdProvincia = (int)datos.Lector["idProvincia"];

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

        public void agregarDomicilio(Domicilio domicilio)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SPAgregarDomicilio");
                datos.setearParametros("@IdLocalidad", domicilio.IdLocalidad);
                datos.setearParametros("@CodigoPostal", domicilio.CodigoPostal);
                datos.setearParametros("@Direccion", domicilio.Direccion);

                if (domicilio.NumeroDepartamento != null)
                {
                    datos.setearParametros("@NumeroDepartamento", domicilio.NumeroDepartamento);
                }
                else
                {
                    datos.setearParametros("@NumeroDepartamento", DBNull.Value);
                }

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

        public void agregarDomicilioCliente(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                int idDomicilio = ultimoIdDomicilio();

                datos.setearProcedimiento("SPAgregarDomicilioCliente");
                datos.setearParametros("@IdCliente", cliente.Id);
                datos.setearParametros("@IDDomicilio", idDomicilio);
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


        public int ultimoIdDomicilio()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select MAX(id) as maxId from Domicilio");
                datos.ejecutarConsulta();

                if (datos.Lector.Read())
                {
                    int id = (int)datos.Lector["maxId"];
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
