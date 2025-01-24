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
    public partial class AltaArticulo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                List<Categoria> listaCategorias = categoriaNegocio.listar();

                MarcaNegocio MarcaNegocio = new MarcaNegocio();
                List<Marca> listaMarcas = MarcaNegocio.listar();

                dwlCategoria.DataTextField = "Descripcion";
                dwlCategoria.DataValueField = "Id";
                dwlCategoria.DataSource = listaCategorias;
                dwlCategoria.DataBind();
                dwlCategoria.Items.Insert(0, new ListItem("--Seleccione una Categoría--", ""));
                dwlCategoria.Items[0].Attributes["disabled"] = "true";
                dwlCategoria.SelectedIndex = 0;

                dwlMarca.DataTextField = "Descripcion";
                dwlMarca.DataValueField = "Id";
                dwlMarca.DataSource = listaMarcas;
                dwlMarca.DataBind();
                dwlMarca.Items.Insert(0, new ListItem("--Seleccione una Marca--", ""));
                dwlMarca.Items[0].Attributes["disabled"] = "true";
                dwlMarca.SelectedIndex = 0;
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ArticulosNegocio negocioArticulo = new ArticulosNegocio();

            Articulo articulo = new Articulo();


        }
    }
}