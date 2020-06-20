using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyectofinalwebII
{
    public partial class DeUsuario : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"]!=null)
                {
                    if (!Session["Usuario"].ToString().Equals("SI"))
                    {
                        Response.Redirect("../index.html");
                    }
                }
                else
                {
                    Response.Redirect("../index.html");
                }
            }
        }
    }
}