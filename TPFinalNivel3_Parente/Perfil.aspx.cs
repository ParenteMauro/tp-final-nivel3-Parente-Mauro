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
            if (Seguridad.sesionIniciada(Session["user"]))
            {
                if (!IsPostBack)
                {
                    user = (User)Session["user"];
                    txtEmail.Text = user.Email;
                    txtEmail.Enabled = false;
                    txtImagen.Style["display"] = "none";
                    txtArchivo.Style["display"] = "none";
                    txtNombre.Text = user.Nombre;
                    txtApellido.Text = user.Apellido;
                    if (((User)Session["user"]).urlImagenPerfil != "" && ((User)Session["user"]).urlImagenPerfil != null)
                    {
                        string imagenPerfil = (((User)Session["user"]).urlImagenPerfil);
                        txtImagen.Text = imagenPerfil;
                        if (Seguridad.ImagenValida(imagenPerfil) || imagenPerfil.Contains(".jpg"))
                        {
                            if (imagenPerfil.Contains("jpg"))
                                pbxImagen.ImageUrl = "~/Images/" + ((User)Session["user"]).urlImagenPerfil;
                            else
                                pbxImagen.ImageUrl = imagenPerfil;
                        }
                    }

                }
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

            if (txtArchivo.PostedFile.FileName != "")
            {
                string ruta = Server.MapPath("~/Images/");
                txtArchivo.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                txtImagen.Text = "perfil-" + user.Id + ".jpg";
                pbxImagen.ImageUrl = "~/Images/" + "perfil-" + user.Id;
                user.urlImagenPerfil = txtImagen.Text;
            }


            userNegocio.modificar(user.Id, user.Nombre, user.Apellido, user.urlImagenPerfil);

        }

        protected void btnImgLocal_Click(object sender, EventArgs e)
        {
            txtImagen.Style["display"] = "none";
            txtArchivo.Style["display"] = "block";
        }

        protected void btnUrlImagen_Click(object sender, EventArgs e)
        {
            txtArchivo.Style["display"] = "none";
            txtImagen.Style["display"] = "block";
        }
    }
}