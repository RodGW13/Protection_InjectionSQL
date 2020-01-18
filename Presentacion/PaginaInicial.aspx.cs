using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class PaginaInicial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio.PersonaBLL personaBLL = new Negocio.PersonaBLL();
                personaBLL.ObtenerPersonaNombre(TxtNombre.Text);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}