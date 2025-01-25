using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
namespace TPFinalNivel3_Parente
{
    public partial class Perfil : System.Web.UI.Page
    {
        private User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null && !IsPostBack)
            {
                user = (User)Session["user"];
                txtEmail.Text = user.Email;
                txtEmail.Enabled = false;
                txtNombre.Text = user.Nombre;
                txtApellido.Text = user.Apellido;
                txtImagen.Text = user.urlImagenPerfil;
            }
            else
            {
                Response.Redirect("Default.aspx", false);
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

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            UserNegocio userNegocio = new UserNegocio();
            user = (User)Session["user"];
            user.Nombre = txtNombre.Text;
            user.Apellido = txtApellido.Text;
            user.urlImagenPerfil = txtImagen.Text;

            userNegocio.modificar(user.Id, user.Nombre, user.Apellido, user.urlImagenPerfil);

        }
    }
}