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
    public partial class ventas : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void cargarproductos()
        {

            
        }

        protected void tabladetalles()
        {

            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            
           
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            

        }

        protected void grvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
             if (e.CommandName == "Eliminar")
            {
                Response.Write("<script>$('#mdlConfirmar').modal('show');</script>");
                
            }
        }
    }
}