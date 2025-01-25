using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TPFinalNivel3_Parente
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                UserNegocio negocio = new UserNegocio();
                User usuarioIngresado = negocio.logIn(txtEmail.Text, txtPass.Text);
                if (usuarioIngresado != null)
                {
                    Session.Add("user", usuarioIngresado);
                    Response.Redirect("Default.aspx", false);
                }
                else
                    txtIngresoFallido.Text = "No se encontró un Usuario con ese email y contraseña";


            }
            catch (Exception ex)
            {
                Session.Add("error", "No se encontró usuario");
            }
        }
    }
}