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
    public partial class ListaArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                List<Articulo> articulos = new List<Articulo>();

                articulos = negocio.listar();
                Session.Add("listaArticulos", articulos);

                dgvArticulos.DataSource = articulos;
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSeleccion = dgvArticulos.SelectedIndex;

            Articulo articuloSeleccionado = new Articulo();

            articuloSeleccionado = ((List<Articulo>)Session["listaArticulos"])[idSeleccion];

            Session.Add("articuloSeleccionado", articuloSeleccionado);

            Response.Redirect("AltaArticulo.aspx?id=" + articuloSeleccionado.Id);
            
        }
    }
}