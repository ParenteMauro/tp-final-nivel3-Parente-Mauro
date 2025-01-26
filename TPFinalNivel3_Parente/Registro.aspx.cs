using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3_Parente
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            UserNegocio negocio = new UserNegocio();
            if (!(negocio.comprobarRegistro(txtEmail.Text))) { 
            negocio.registrarse(txtEmail.Text,txtPass.Text, txtNombre.Text, txtApellido.Text);
            Response.Redirect("LogIn.aspx", false);
            }
            else
            {
                txtRegistroFallido.Text = "El email ingresado ya se encuentra en uso";
               
            }
        }
    }
}