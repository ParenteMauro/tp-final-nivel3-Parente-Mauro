using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3_Parente
{
    public partial class Detalle : System.Web.UI.Page
    {
        private int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("Default.aspx", false);
                    
                }
                else
                {
                    id = int.Parse(Request.QueryString["id"]);

                    FavoritoNegocio favoritoCheck = new FavoritoNegocio();
                    
                    int idUser = ((User)Session["user"]).Id;
                    int idArt = id;
                    if (favoritoCheck.comprobarFavorito(idUser, id))
                    {
                        btnFav.Text = "★";
                        btnFav.Style["color"] = "gold";
                    }
                    

                    Articulo articulo = ((List<Articulo>)Session["listaArticulos"]).Find(x => x.Id == id);

                    txtNombre.Text = articulo.Nombre;
                    txtCategoria.Text = articulo.Categoria.Descripcion;
                    txtCodigo.Text = articulo.Codigo;
                    txtMarca.Text = articulo.Marca.Descripcion;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = (articulo.Precio).ToString();
                    try
                    {
                        pbxImagen.ImageUrl = articulo.UrlImagen;
                    }
                    catch
                    {
                        pbxImagen.ImageUrl = "https://png.pngtree.com/png-vector/20221109/ourmid/pngtree-no-image-available-icon-flatvector-illustration-graphic-available-coming-vector-png-image_40958834.jpg";

                    }
                }
            }
            catch(Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error", false);
            }


        }

        protected void btnFav_Click(object sender, EventArgs e)
        {
            if (Seguridad.sesionIniciada(Session["user"]))
            {
                FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                int idArt = id;
                int idUser = ((User)Session["user"]).Id;
                if (!favoritoNegocio.comprobarFavorito(idUser, id))
                {
                    favoritoNegocio.agregarFavorito(idUser, idArt);
                    btnFav.Text = "★";
                    btnFav.Style["color"] = "gold";
                }
                else
                {
                    favoritoNegocio.quitarFavorito(idUser, idArt);
                    btnFav.Text = "☆";
                    btnFav.Style["color"] = "snow";
                }
            }
            else
            {
                Response.Redirect("LogIn.aspx", false);
            }
            
        }

   
    }
}