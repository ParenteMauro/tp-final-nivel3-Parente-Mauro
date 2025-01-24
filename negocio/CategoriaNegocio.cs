using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CategoriaNegocio
    {
        public AccesoDatos conexion = new AccesoDatos();


        public List<Categoria> listar()
        {
            List<Categoria> listaCategoria = new List<Categoria>();
            try
            {
                conexion.setearConsulta("SELECT Id, Descripcion From Categorias;");

                SqlDataReader lector = conexion.lectura();

                while (lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)lector["Id"];
                    categoria.Descripcion = (string)lector["Descripcion"];
                    listaCategoria.Add(categoria);

                }

                return listaCategoria;
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
