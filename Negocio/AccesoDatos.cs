﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        //CONEXION A BD
        public AccesoDatos()
        {
           //conexion = new SqlConnection("server=.\\SQLLaboratorio; database=P3_ECOMMERCE_DB; integrated security=true;");
           conexion = new SqlConnection("server=.\\SQLEXPRESS; database=P3_ECOMMERCE_DB; integrated security=true;");
            comando = new SqlCommand();

        }

        //SETEAR CONSULTA CON STORE PROCEDURE
        public void setearProcedimiento(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }


        //SETEAR CONSULTA
        public void setearConsulta(string consulta)
        {

            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        //EJECUTAR CONSULTA
        public void ejecutarConsulta()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                //EJECUTAR LECTURA
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //CERRAR CONEXION
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();

            conexion.Close();

        }

        //SETEAMOS LOS PARAMETROS PARA LA CARGA Y MODIFICACIÓN
        public void setearParametros(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        //LIMPIAMOS LOS PARAMETROS
        public void limpiarParametros()
        {
            comando.Parameters.Clear();
        }

        //EN VEZ DE EJECUTAR UNA CONSULTA, EJECUTA UNA ACCION CONTRA BASE DE DATOS(MANDA DATOS)
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conexion.Close();
            }

        }

    }
}
