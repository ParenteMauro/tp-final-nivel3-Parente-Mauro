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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is LogIn || Page is Registro || Page is Default || Page is Detalle))
            {
                if (!(Seguridad.sesionIniciada(Session["user"])))
                {
                    Response.Redirect("LogIn.aspx", false);

                }
            }

            if (Seguridad.sesionIniciada((User)Session["user"]))
            {
                if (((User)Session["user"]).urlImagenPerfil != "" && ((User)Session["user"]).urlImagenPerfil != null)
                {
                    string imagenPerfil = (((User)Session["user"]).urlImagenPerfil);
                    if (Seguridad.ImagenValida(imagenPerfil) || imagenPerfil.Contains(".jpg"))
                    {
                        if (imagenPerfil.Contains("jpg"))
                            imgUser.ImageUrl = "~/Images/" + ((User)Session["user"]).urlImagenPerfil;
                        else
                            imgUser.ImageUrl = imagenPerfil;
                    }
                }
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("Default.aspx", false);
        }
    }
}