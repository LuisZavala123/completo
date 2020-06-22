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
                String ExpresionNom = "^([A-Z]{1}[a-zñáéíóú]{1,30}[- ]{0,1}|[A-Z]{1}[- \']{1}[A-Z]{0,1}[a-zñáéíóú]{1,30}[- ]{0,1}|[a-z]{1,2}[ -\']{1}[A-Z]{1}[a-zñáéíóú]{1,30}){1,5}";
                String ExpresionCos = "^[1-9][0-9]?([.][0-9]{1,2})?";
                String ExpresionTip = "^([H][a][m][b][u][r][g][u][e][s][a]|[B][e][b][i][d][a]|[P][i][z][z][a]){1}";
                if (Regex.IsMatch(nom, ExpresionNom))
                {
                    if (Regex.IsMatch(costo, ExpresionCos))
                    {
                        if (Regex.IsMatch(Tipo,ExpresionTip))
                        {
                            DAO.Agregar(new MArticulos(Tipo, nom, Double.Parse(costo), "", Descripcion));
                        }
                        else
                        {
                            throw new SystemException("El tipo ingresado no es valido");
                        }
                    }
                    else
                    {
                        throw new SystemException("El precio ingresado no es valido");
                    }
                }
                else
                {
                    throw new SystemException("El nombre ingresado no es valido");
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
                string expid = "^[1-9][0-9]*";
                if (Regex.IsMatch(id, expid))
                {
                    return DAO.Getbyid(id);
                }
                throw new SystemException("El id ingresado no es valido");
                
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
                string expNombre = "^([A-Z]{1}[a-zñáéíóú]{1,30}[- ]{0,1}|[A-Z]{1}[- \']{1}[A-Z]{0,1}[a-zñáéíóú]{1,30}[- ]{0,1}|[a-z]{1,2}[ -\']{1}[A-Z]{1}[a-zñáéíóú]{1,30}){1,5}";
                if (Regex.IsMatch(Nombre, expNombre))
                {
                    return DAO.GetbyNombre(Nombre);
                }
                throw new SystemException("El Nombre ingresado no es valido");
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
                string expid = "^[1-9][0-9]*";
                if (Regex.IsMatch(id, expid))
                {
                    DAO.Eliminar(id);
                }
                else
                {
                    throw new SystemException("El id ingresado no es valido");
                }
            }
            
        }

        
    }
}
