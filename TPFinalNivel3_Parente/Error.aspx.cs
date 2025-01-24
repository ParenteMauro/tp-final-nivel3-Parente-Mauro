using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3_Parente
{
	public partial class Error : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["error"] != null)
			{
                txtError.Text = Session["error"].ToString();
            }
			else
			{
				Response.Redirect("Default.aspx", false);
			}
				
			
			
		}
	}
}