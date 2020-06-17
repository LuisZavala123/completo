using BackEnd.DAOS;
using BackEnd.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Text.RegularExpressions;


namespace proyectofinalwebII.WS
{
    /// <summary>
    /// Descripción breve de WSArticulos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    
    [System.Web.Script.Services.ScriptService]
    public class WSArticulos : System.Web.Services.WebService
    {

        private ArticuloDAO DAO = new ArticuloDAO();


        [WebMethod(EnableSession = true)]
        public void Agregar(string nom, String costo, String Descripcion, String Tipo)
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI")) {
                String ExpresionNom = @"[A-ZÁÉÍÓÚ][a-z]+";
                String ExpresionCos = @"[0-9]+[\.][0-9][0-9]?";
                if (Regex.IsMatch(nom, ExpresionNom) && Regex.IsMatch(costo, ExpresionCos))
                {
                    DAO.Agregar(new MArticulos(Tipo, nom, Double.Parse(costo), "", Descripcion));
                }
            }
        }

        [WebMethod(EnableSession = true)]
        public List<MArticulos> GetAll()
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI")) {
                return DAO.GetAll();
            }
            else
            {
                return null ;
            }
        }


        [WebMethod(EnableSession = true)]
        public MArticulos Getbyid(String id)
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI")) {
                return DAO.Getbyid(id);
            }
            else
            {
                return null;
            }
        }

        [WebMethod(EnableSession = true)]
        public MArticulos GetbyNombre(String Nombre)
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI")) {
                return DAO.GetbyNombre(Nombre);
            }
            else {
                return null; 
            }
        }

        [WebMethod(EnableSession = true)]
        public List<String> GetNombres()
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI")) {
                return DAO.GetNombres();
            }
            else
            {
                return null;
            }
        }


        [WebMethod(EnableSession = true)]
        public void Eliminar(string id)
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI")) {
                DAO.Eliminar(id);
            }
            
        }

        
    }
}
