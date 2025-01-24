using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace negocio
{
    public static class Seguridad
    {
        public static bool comprobarTexto(TextBox textBox)
        {
            if(textBox.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool comprobarDWL(DropDownList dwl)
        {
            if (dwl.SelectedIndex > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ImagenValida(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.AllowAutoRedirect = true;

                request.Method = "HEAD";

                request.Timeout = 5000; 
                using (HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse())
                {
                    return respuesta.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
