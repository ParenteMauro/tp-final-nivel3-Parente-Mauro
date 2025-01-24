using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database= CATALOGO_WEB_DB; integrated security=true; ");
            comando = new SqlCommand();
        }
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta; 
            comando.Connection = conexion;  

        }
        public void setearParametro(string parametro, object valor)
        {
            comando.Parameters.AddWithValue(parametro, valor);
        }

        public SqlDataReader lectura()
        {
            try
            {
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();
                return lector;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public void ejecutarLectura()
        {
            conexion.Open();
            comando.ExecuteReader();
        }

        public void ejecutarAccion()
        {
            conexion.Open();
            comando.ExecuteNonQuery();
        }

        public void cerrarConexion()
        {
            conexion.Close();
        }

    }
}
