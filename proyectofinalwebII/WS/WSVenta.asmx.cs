using BackEnd.DAOS;
using BackEnd.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace proyectofinalwebII.WS
{
    /// <summary>
    /// Descripción breve de WSVenta
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    
    [System.Web.Script.Services.ScriptService]
    public class WSVenta : System.Web.Services.WebService
    {


        private VentaDAO DAO = new VentaDAO();
        

        [WebMethod(EnableSession = true)]
        public void Agregar(String Total, String Descripcion)
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI") && Session["detalles"] != null ) {
                DateTime fecha = DateTime.Today;
                String fech = fecha.Year + "-";
                if (fecha.Month.ToString().Length < 2)
                {
                    fech = fech + "0" + fecha.Month + "-";
                }
                else {
                    fech = fech + fecha.Month + "-";
                }
                if (fecha.Day.ToString().Length < 2)
                {
                    fech = fech + "0" + fecha.Day;
                }
                else
                {
                    fech = fech + fecha.Day + "";
                }
                String Expresion = @"[0-9]+[\.][0-9][0-9]?";

                if (Regex.IsMatch(Total, Expresion)) { }
                DAO.Agregar(new MVentas(fech, double.Parse(Total), "", Descripcion));
                int id = DAO.lastid();
                
                foreach (var item in Session["detalles"] as List<MDetalles>)
                {
                    DAO.Agregar_Detalles(new MDetalles(id + "", item.producto, item.Tipo, item.cantidad, item.total));
                }
            }
            }
            
        
        [WebMethod(EnableSession = true)]
        public string detalle(String producto, String Cantidad)
        {
            try
            {
                if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI"))
                {
                    ArticuloDAO artdao = new ArticuloDAO();
                    MArticulos art = artdao.GetbyNombre(producto);
                    bool si = true;
                    List<MDetalles> detalles = Session["detalles"] as List<MDetalles>;
                    if (detalles == null)
                    {
                        detalles = new List<MDetalles>();
                    }
                    if (detalles.Count < 1)
                    {
                        detalles.Add(new MDetalles("", art.id, art.tipo, int.Parse(Cantidad), int.Parse(Cantidad) * art.costo));
                    }
                    else
                    {
                        foreach (var item in detalles)
                        {
                            if (item.producto.Equals(art.id))
                            {
                                item.cantidad += int.Parse(Cantidad);
                                item.total += int.Parse(Cantidad) * art.costo;

                            }
                            else
                            {
                                si = false;
                            }
                        }
                        if (!si)
                        {
                            detalles.Add(new MDetalles("", art.id, art.tipo, int.Parse(Cantidad), int.Parse(Cantidad) * art.costo));
                        }
                    }
                    Session["detalles"] = detalles;
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    return jss.Serialize(detalles);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        [WebMethod(EnableSession = true)]
        public List<MVentas> GetAll()
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI"))
            {
                return DAO.GetAll();
            }
            else {
                return null;
            }
        }

        [WebMethod(EnableSession = true)]
        public List<MDetalles> GetDetalles(String id)
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI"))
            {
                return DAO.GetDetalles(id);
            }
            else {
                return null;
            }
        }
        [WebMethod(EnableSession = true)]
        public string GetallDetalles(String fecha)
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI"))
            {
                List<MReporte> lista2 = new List<MReporte>();
                List<MDetalles> lista1 = DAO.GetallDetalles();
                MReporte rep = new MReporte();

                foreach (var item in DAO.GetAll())
                {
                    foreach (var item2 in lista1)
                    {
                        if (item.fecha.Equals(fecha) && item.id.Equals(item2.idVenta))
                        {
                            rep = new MReporte();
                            rep.Tipo = item2.Tipo;
                            rep.Cantidad = item2.cantidad;
                            rep.Total = item2.total;
                            rep.Nombre = new ArticuloDAO().Getbyid(item2.producto).nombre;
                            if (lista2.Contains(rep))
                            {
                                lista2.ElementAt(lista2.IndexOf(rep)).Total += rep.Total;
                                lista2.ElementAt(lista2.IndexOf(rep)).Cantidad += rep.Cantidad;
                            }
                            else
                            {
                                lista2.Add(rep);
                            }

                        }
                    }
                }
                JavaScriptSerializer jss = new JavaScriptSerializer();
                return jss.Serialize(lista2);
            }
            else {
                return null;
            }
        }

        [WebMethod(EnableSession = true)]
        public MVentas Getbyid(String id)
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
        public void Eliminar(string id)
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI"))
            {
                DAO.Eliminar(id);
            }
        }

        [WebMethod(EnableSession = true)]
        public void EliminarDetalles(string id)
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI")) {
                DAO.EliminarDetalles(id);
            }
        }

        [WebMethod(EnableSession = true)]
        public string quitarDetalle(string id)
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI"))
            {
                MDetalles temp = new MDetalles(); ;
                List<MDetalles> detalles = Session["detalles"] as List<MDetalles>;
                foreach (var item in detalles)
                {
                    if (item.producto.Equals(id))
                    {
                        temp=item;
                    }
                }
                detalles.Remove(temp);
                Session["detalles"] = detalles;
                JavaScriptSerializer jss = new JavaScriptSerializer();
                return jss.Serialize(detalles);
            }
            else {
                return null;
            }
        }
    }
}
