using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    
    public class ArticulosNegocio
    {
        private AccesoDatos conexion = new AccesoDatos();

        public List<Articulo> listar()
        {
            List<Articulo> listaArticulos = new List<Articulo>();

            try
            {
                conexion.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id AS IdMarca ,M.Descripcion AS Marca, C.Id AS IdCategoria, C.Descripcion AS Categoria, A.ImagenUrl, A.Precio FROM ARTICULOS A, MARCAS M , CATEGORIAS C WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id;");

                SqlDataReader lector = conexion.lectura();
                
                while (lector.Read()) 
                {
                    Articulo articuloAux = new Articulo();
                    articuloAux.Id = (int)lector["Id"];
                    articuloAux.Codigo = (string)lector["Codigo"];
                    articuloAux.Nombre = (string)lector["Nombre"];
                    articuloAux.Descripcion = (string)lector["Descripcion"];
                    articuloAux.Marca.Id = (int)lector["IdMarca"];
                    articuloAux.Marca.Descripcion = (string)lector["Marca"];
                    articuloAux.Categoria.Id = (int)lector["IdCategoria"];
                    articuloAux.Categoria.Descripcion = (string)lector["Categoria"];
                    articuloAux.UrlImagen = (string)lector["ImagenUrl"];
                    articuloAux.Precio = (decimal)lector["Precio"];

                    listaArticulos.Add(articuloAux);
                    
                }

                return listaArticulos;
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

        public void agregar(Articulo articulo) 
        {
            try
            {
                conexion.setearConsulta("INSERT INTO ARTICULOS VALUES(@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Url, @Precio)");
                conexion.setearParametro("@Codigo", articulo.Codigo);
                conexion.setearParametro("@Nombre", articulo.Nombre);
                conexion.setearParametro("@Descripcion", articulo.Descripcion);
                conexion.setearParametro("@IdMarca", articulo.Marca.Id);
                conexion.setearParametro("@IdCategoria", articulo.Categoria.Id);
                if (articulo.UrlImagen == null)
                    articulo.UrlImagen = "";
                conexion.setearParametro("@Url", articulo.UrlImagen);
                conexion.setearParametro("@Precio", articulo.Precio);
                conexion.ejecutarLectura();

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
        public void eliminar(int articuloId)
        {
            try
            {
                conexion.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id"); ;
                conexion.setearParametro("@Id", articuloId);
                conexion.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                conexion.cerrarConexion();  
            }
            
        }
    
        public void buscar(string propiedad, string parametro, string busqueda)
        {
            
            switch (parametro)
            {
                case "Empieza con":
                    {
                        conexion.setearConsulta("SELEC");
                        break;
                    }
                case "Termina con":
                    {
                        
                        break;
                    }
                case "Contiene":
                    {
                        
                        break;

                    }
                case "Escribe el Código:":
                    {

                        conexion.setearParametro("@Codigo", busqueda);
                        break;
                    }

            }

        }
      
        
        public void modificar(Articulo articuloModificar)
        {
            try 
            { 
            conexion.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo,Nombre = @Nombre, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @Url, Precio = @Precio  WHERE Id = @Id");
            conexion.setearParametro("@Codigo", articuloModificar.Codigo);
            conexion.setearParametro("@Nombre", articuloModificar.Nombre);
            conexion.setearParametro("@Descripcion", articuloModificar.Descripcion);
            conexion.setearParametro("@IdMarca", articuloModificar.Marca.Id);
            conexion.setearParametro("@IdCategoria", articuloModificar.Categoria.Id);
            conexion.setearParametro("@Url", articuloModificar.UrlImagen);
            conexion.setearParametro("@Precio", articuloModificar.Precio);
            conexion.setearParametro("@Id", articuloModificar.Id);
            conexion.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }

            finally
            {
                conexion.cerrarConexion();
            }
        }

        public List<Articulo> listar(string propiedad,string criterio,string filtro)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();    
            try
            {
                if (propiedad == "Marca" || propiedad == "Categoria")
                {
                    char x;
                    if (propiedad == "Marca")
                        x = 'M';
                    else
                        x = 'C';

                    conexion.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id AS IdMarca ,M.Descripcion AS Marca, C.Id AS IdCategoria, C.Descripcion AS Categoria, A.ImagenUrl, A.Precio FROM ARTICULOS A, MARCAS M , CATEGORIAS C WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id " + 
                    "AND "+x+".Descripcion = '"+ criterio + "'" );

                }

                else if (propiedad!= "Codigo")
                    conexion.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id AS IdMarca ,M.Descripcion AS Marca, C.Id AS IdCategoria, C.Descripcion AS Categoria, A.ImagenUrl, A.Precio FROM ARTICULOS A, MARCAS M , CATEGORIAS C WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id " +
                    "AND A."+ propiedad +" LIKE '" + validarFiltrado(criterio, filtro) + "'" );

                

                else
                    if(filtro != "")
                    conexion.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Id AS IdMarca ,M.Descripcion AS Marca, C.Id AS IdCategoria, C.Descripcion AS Categoria, A.ImagenUrl, A.Precio FROM ARTICULOS A, MARCAS M , CATEGORIAS C WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id " +
                    "AND A." + propiedad + " LIKE '" + filtro + "'");

                SqlDataReader lector = conexion.lectura();

                while (lector.Read())
                {
                    Articulo articuloAux = new Articulo();
                    articuloAux.Id = (int)lector["Id"];
                    articuloAux.Codigo = (string)lector["Codigo"];
                    articuloAux.Nombre = (string)lector["Nombre"];
                    articuloAux.Descripcion = (string)lector["Descripcion"];
                    articuloAux.Marca.Id = (int)lector["IdMarca"];
                    articuloAux.Marca.Descripcion = (string)lector["Marca"];
                    articuloAux.Categoria.Id = (int)lector["IdCategoria"];
                    articuloAux.Categoria.Descripcion = (string)lector["Categoria"];
                    articuloAux.UrlImagen = (string)lector["ImagenUrl"];
                    articuloAux.Precio = (decimal)lector["Precio"];

                    listaFiltrada.Add(articuloAux);

                }




                return listaFiltrada;
            }
            catch(Exception ex) 
            { 
                throw ex; 
            }
            finally
            {
                conexion.cerrarConexion() ;
            }
        }
        public string validarFiltrado(string criterio, string filtro)
        {
            string respuesta = "";

            switch (criterio)
            {
                case "Empieza con":
                    {
                        respuesta = filtro+"%";
                        break;
                    }
                case "Termina con":
                    {
                        respuesta = "%" + filtro;
                        break;
                    }
                case "Contiene":
                    {
                        respuesta = "%" + filtro + "%";
                        break;
                    }
            }

            return respuesta;

        }

        public Articulo traerArticulo(int id)
        {
            AccesoDatos conexionA = new AccesoDatos();
            try { 
            conexionA.setearConsulta("SELECT Id, Nombre, ImagenUrl FROM ARTICULOS Where Id = @id");
            conexionA.setearParametro("@id", id);
            SqlDataReader lector = conexionA.lectura();
            Articulo articulo = new Articulo();
            while (lector.Read())
            {
                articulo.Id = (int)lector["id"];
                articulo.Nombre = (string)lector["Nombre"];
                articulo.UrlImagen = (string)lector["ImagenUrl"];

            }
            return articulo;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexionA.cerrarConexion();
            }
        }
    }
}
