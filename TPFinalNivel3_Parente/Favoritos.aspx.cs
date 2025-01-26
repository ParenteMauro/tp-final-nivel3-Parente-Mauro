using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TPFinalNivel3_Parente
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionIniciada(((User)Session["user"])))
            {
                FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                ArticulosNegocio articulosNegocio = new ArticulosNegocio(); 
                List<int> listaDeIDFavoritos = new List<int>();
                int idUser = ((User)Session["user"]).Id;
                listaDeIDFavoritos = favoritoNegocio.listaFavoritos(idUser);
                List<Articulo> listaArticulosFavoritos = new List<Articulo>();
                foreach(int id in listaDeIDFavoritos)
                {
                    Articulo articulo = articulosNegocio.traerArticulo(id);
                    listaArticulosFavoritos.Add(articulo);
                }

                Session.Add("listaFavoritos", listaArticulosFavoritos);
            }
        }

    }
}
