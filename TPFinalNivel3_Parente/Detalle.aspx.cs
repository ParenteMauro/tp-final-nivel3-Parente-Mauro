using dominio;
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

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }


    }
}