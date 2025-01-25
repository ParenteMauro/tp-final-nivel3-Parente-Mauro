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
            if (Session["user"] == null || ((User)Session["user"]).Admin == false)
            {
                Response.Redirect("Default.aspx", false);
            }
            if (!IsPostBack)
            {
                try
                {
                    ArticulosNegocio negocio = new ArticulosNegocio();
                    List<Articulo> articulos = new List<Articulo>();

                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    List<Marca> marcas = marcaNegocio.listar();
                    Session.Add("listaMarcas", marcas);
                    
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    List<Categoria> categorias = categoriaNegocio.listar();
                    Session.Add("listaCategorias", categorias);
                    

                    articulos = negocio.listar();
                    Session.Add("listaArticulos", articulos);

                    dgvArticulos.DataSource = articulos;
                    dgvArticulos.DataBind();

                    valorizarDWL(dwlPropiedad);
                    valorizarDWL(dwlParametro);
                    cargarDWL(dwlPropiedad, "Nombre", "Descripcion", "Marca", "Categoria");
                    dwlPropiedad.Items.Insert(0, new ListItem("...", ""));
                    dwlPropiedad.Items[0].Attributes["disabled"] = "true";
                    dwlPropiedad.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.ToString());

                }
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

        protected void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaArticulos = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscarNombre.Text.ToUpper()));

            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
            btnResetear.Enabled = true;
            
        }



        protected void btnResetear_Click(object sender, EventArgs e)
        {
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();
            txtBuscarNombre.Text = "";
            dwlPropiedad.SelectedIndex = 0;
            dwlParametro.Items.Clear();
            btnBusquedaAvanzada.Enabled = false;
            btnResetear.Enabled = false;
        }
        protected void valorizarDWL(DropDownList dwl)
        {
            dwl.DataTextField = "Descripcion";
            dwl.DataValueField = "Id";
        }
        protected void cargarDWL(DropDownList dwl, string op1, string op2, string op3, string op4)
        {
            dwl.Items.Clear();
            dwl.Items.Add(op1);
            dwl.Items.Add(op2);
            dwl.Items.Add(op3);
            dwl.Items.Add(op4);
        }
        protected void cargarDWL(DropDownList dwl, string op1, string op2, string op3)
        {
            dwl.Items.Clear();
            dwl.Items.Add(op1);
            dwl.Items.Add(op2);
            dwl.Items.Add(op3);

        }

        protected void dwlPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnResetear.Enabled = true;
            switch (dwlPropiedad.SelectedIndex)
            {
                case 1: case 2:
                    txtBusquedaAvanzada.Enabled = true;
                    dwlParametro.Items.Clear();
                    cargarDWL(dwlParametro, "Empieza con", "Termina con", "Contiene");
                    btnBusquedaAvanzada.Enabled = true;

                    break;
                case 3:
                    dwlParametro.Items.Clear();
                    dwlParametro.DataSource = Session["listaMarcas"];
                    txtBusquedaAvanzada.Enabled = false;
                    dwlParametro.DataBind();
                    btnBusquedaAvanzada.Enabled = true;
                    break;
                case 4:
                    dwlParametro.Items.Clear();
                    dwlParametro.DataSource = Session["listaCategorias"];
                    dwlParametro.DataBind();

                    txtBusquedaAvanzada.Enabled = false;
                    btnBusquedaAvanzada.Enabled = true;
                    break;

            }
        }

        protected void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            dgvArticulos.DataSource = negocio.listar(dwlPropiedad.SelectedValue, dwlParametro.SelectedItem.ToString(), txtBusquedaAvanzada.Text);
            dgvArticulos.DataBind();
        }


    }

}
