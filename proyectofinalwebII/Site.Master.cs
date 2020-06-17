using BackEnd.DAOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyectofinalwebII
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    if (Session["Usuario"].ToString().Equals("SI"))
                    {
                        btnAgUsuario.Visible = true;
                        btnReporte.Visible = true;
                        btnAgProducto.Visible = true;
                        exit.Visible = true;
                        btnOrden.Visible = true;
                        btnLogin.Visible = false;
                    }
                    else {
                        btnAgUsuario.Visible = false;
                        btnReporte.Visible = false;
                        btnAgProducto.Visible = false;
                        exit.Visible = false;
                        btnOrden.Visible = false;
                        btnLogin.Visible = true;
                    }
                }
                else
                {
                    btnAgUsuario.Visible = false;
                    btnReporte.Visible = false;
                    btnAgProducto.Visible = false;
                    exit.Visible = false;
                    btnOrden.Visible = false;
                    btnLogin.Visible = true;
                }
            }
        }
      

    }
}