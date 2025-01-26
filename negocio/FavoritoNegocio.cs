using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class FavoritoNegocio
    {
        public void agregarFavorito(int idUser, int idArticulo)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.setearConsulta("INSERT INTO FAVORITOS Values(@idUser,@idArticulo)");
                conexion.setearParametro("@idUser", idUser);
                conexion.setearParametro("@idArticulo", idArticulo);
                conexion.ejecutarAccion();
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

        public bool comprobarFavorito(int idUser, int idArticulo)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.setearConsulta("SELECT id FROM FAVORITOS WHERE idUser=@idUser AND idArticulo=@idArticulo");
                conexion.setearParametro("@idUser", idUser);
                conexion.setearParametro("@idArticulo", idArticulo);

                SqlDataReader lector = conexion.lectura();
                if (lector.Read())
                {
                    if ((int)lector["id"] != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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

        public void quitarFavorito(int idUser, int idArticulo)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.setearConsulta("DELETE FROM FAVORITOS WHERE IdUser = @idUser AND IdArticulo = @idArticulo");
                conexion.setearParametro("@idUser", idUser);
                conexion.setearParametro("@idArticulo", idArticulo);

                conexion.ejecutarLectura();

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

        public List<int> listaFavoritos(int IdUser)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.setearConsulta("SELECT IdArticulo FROM FAVORITOS WHERE IdUser = @IdUser;");
                conexion.setearParametro("@IdUser", IdUser);
                SqlDataReader lector = conexion.lectura();
                List<int> listaFav = new List<int>();
                while (lector.Read())
                {
                    int idArt = int.Parse(lector["idArticulo"].ToString());
                    listaFav.Add(idArt);
                }
                return listaFav;
            }
            catch(Exception ex)
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
