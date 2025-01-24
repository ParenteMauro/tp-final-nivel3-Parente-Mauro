using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{

    public class MarcaNegocio
    {
        public AccesoDatos conexion = new AccesoDatos();
        

        public List<Marca> listar()
        {
            List<Marca> listaMarcas = new List<Marca>();
            try
            {
                conexion.setearConsulta("SELECT Id, Descripcion From Marcas;");

                SqlDataReader lector = conexion.lectura();

                while (lector.Read())
                {
                    Marca marca = new Marca();
                    marca.Id = (int)lector["Id"];
                    marca.Descripcion = (string)lector["Descripcion"];
                    listaMarcas.Add(marca);

                }

                return listaMarcas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

    }
}


