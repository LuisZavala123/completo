using BackEnd.DAOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyectofinalwebII
{
    public partial class AgregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.html");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
           Response.Redirect("index.html");
        }
    }
}