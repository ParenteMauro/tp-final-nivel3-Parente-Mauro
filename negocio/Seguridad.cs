using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public static class Seguridad
    {
        public static List<Articulo> comprobarLista(List<Articulo> lista)
        {
            if (lista != null)
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                lista = negocio.listar();
                return lista;
            }
            else
            {
                return null;
            }

        }

        
    }
}
