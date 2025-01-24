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
                btnEliminar.Visible = false;
                preguntaEliminar.Visible = false;


                if (Request.QueryString["id"] != null)
                {
                    Articulo articuloSeleccionado = (Articulo)Session["articuloSeleccionado"];

                    txtNombre.Text= articuloSeleccionado.Nombre;
                    txtCodigo.Text= articuloSeleccionado.Codigo;
                    txtDescripcion.Text = articuloSeleccionado.Descripcion;
                    txtImagen.Text = articuloSeleccionado.UrlImagen;
                    dwlCategoria.SelectedIndex = articuloSeleccionado.Categoria.Id;
                    dwlMarca.SelectedIndex = articuloSeleccionado.Marca.Id;
                    pbxImagen.ImageUrl = txtImagen.Text;
                    txtPrecio.Text = articuloSeleccionado.Precio.ToString();
                    btnAgregar.Text = "Modificar";
                    btnEliminar.Visible = true;
                }

            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ArticulosNegocio negocioArticulo = new ArticulosNegocio();



            if (Seguridad.comprobarTexto(txtCodigo) && Seguridad.comprobarTexto(txtNombre) &&
                Seguridad.comprobarDWL(dwlMarca) && Seguridad.comprobarDWL(dwlCategoria))
            {
                Articulo articulo = new Articulo();
                articulo.Nombre = txtNombre.Text;
                articulo.Codigo = txtCodigo.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.Marca = new Marca();
                articulo.Marca.Id = dwlMarca.SelectedIndex;
                articulo.Marca.Descripcion = dwlMarca.SelectedItem.ToString();

                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = dwlCategoria.SelectedIndex;
                articulo.Categoria.Descripcion = dwlCategoria.SelectedItem.ToString();

                if (Seguridad.comprobarTexto(txtImagen))
                {
                    articulo.UrlImagen = txtImagen.Text;
                }

                if(Request.QueryString["id"] != null) 
                { 
                negocioArticulo.modificar(articulo);
                Response.Redirect("Default.aspx", false);
                }
                else
                {
                    negocioArticulo.agregar(articulo);
                    Response.Redirect("Default.aspx", false);
                }
            }
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {

            string urlImagen = txtImagen.Text;
            if (string.IsNullOrEmpty(urlImagen) || Seguridad.ImagenValida(urlImagen))
                pbxImagen.ImageUrl = txtImagen.Text;

            else
                pbxImagen.ImageUrl = "https://png.pngtree.com/png-vector/20221109/ourmid/pngtree-no-image-available-icon-flatvector-illustration-graphic-available-coming-vector-png-image_40958834.jpg";

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            preguntaEliminar.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            preguntaEliminar.Visible = false;

        }

        protected void btnSeguroEliminar_Click(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            negocio.eliminar(int.Parse(Request.QueryString["id"]));
            Response.Redirect("Default.aspx", false);
        }
    }
}