using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UserNegocio
    {
        public User logIn(string user, string pass)
        {
            AccesoDatos conexion = new AccesoDatos();
            try
            {
                conexion.setearConsulta("select id, nombre, apellido, urlImagenPerfil, admin from USERS where email= @email AND pass = @pass;");
                conexion.setearParametro("@email", user);
                conexion.setearParametro("@pass", pass);
                SqlDataReader lector = conexion.lectura();
                User usuario = new User();

                if(lector.Read())
                {
                    usuario.Id = (int)lector["id"];
                    usuario.Email = user;
                    if (lector["nombre"] != DBNull.Value)
                        usuario.Nombre = (string)lector["nombre"];

                    if (lector["apellido"] != DBNull.Value)
                        usuario.Apellido = (string)lector["apellido"];

                    if (lector["urlImagenPerfil"] != DBNull.Value)
                        usuario.urlImagenPerfil = (string)lector["urlImagenPerfil"];

                    usuario.Admin = (bool)lector["admin"];

                    return usuario;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.cerrarConexion();

            }
        }

        public void modificar(int id, string nombre, string apeliido, string url)
        {
            AccesoDatos conexion = new AccesoDatos();

            try
            {
                conexion.setearConsulta("UPDATE USERS SET nombre = @nombre , apellido = @apellido, urlImagenPerfil = @url WHERE id = @id;");
                conexion.setearParametro("@nombre", nombre);
                conexion.setearParametro("@apellido", apeliido);
                conexion.setearParametro("@url", url);
                conexion.setearParametro("@id", id);
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
    }
}
