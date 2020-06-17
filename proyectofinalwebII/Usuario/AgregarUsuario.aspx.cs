using BackEnd.DAOS;
using BackEnd.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyectofinalwebII
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.html");
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.html");
        }

    }
}