using BackEnd.DAOS;
using BackEnd.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Text.RegularExpressions;

namespace proyectofinalwebII.WS
{
    /// <summary>
    /// Descripción breve de WSUsuario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    
     [System.Web.Script.Services.ScriptService]
    public class WSUsuario : System.Web.Services.WebService
    {
        private UsuarioDAO DAO = new UsuarioDAO();

        [WebMethod(EnableSession = true)]
        public void Agregar( string nom, string primer_apellido, string segundo_apellido, string contraseña, string Correo, string Tipo)
        {
            if (Session["Usuario"]!=null&& Session["Usuario"].ToString().Equals("SI")) {
                String ExpresionNom = "^([A-Z]{1}[a-zñáéíóú]{1,30}[- ]{0,1}|[A-Z]{1}[- \']{1}[A-Z]{0,1}[a-zñáéíóú]{1,30}[- ]{0,1}|[a-z]{1,2}[ -\']{1}[A-Z]{1}[a-zñáéíóú]{1,30}){1,5}";
                String ExpresionCor = @"^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+";
                if (Regex.IsMatch(nom, ExpresionNom))
                {
                    if (Regex.IsMatch(primer_apellido, ExpresionNom))
                    {
                        if (Regex.IsMatch(Correo, ExpresionCor))
                        {
                            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                            DAO.Agregar(new MUsuarios("", nom, primer_apellido, segundo_apellido, BitConverter.ToString(hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(contraseña))), Correo, Tipo));
                        }
                        else
                        {
                            throw new SystemException("El correo ingresado no es valido");
                        }
                    }
                    else
                    {
                        throw new SystemException("El apellido no es valido");
                    }
                }
                else
                {
                    throw new SystemException("El nombre no es valido");
                }
            }
        }

        [WebMethod(EnableSession = true)]
        public List<MUsuarios> GetAll()
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI")) {
                return DAO.GetAll();
            }
            else
            {
                return null;
            }
        }

        [WebMethod(EnableSession = true)]
        public MUsuarios Getbyid(String id)
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI"))
            {
                string expid = "^[1-9][0-9]*";
                if (Regex.IsMatch(id, expid))
                {
                    return DAO.Getbyid(id);
                }
                throw new SystemException("El id ingresado no es valido");
            }
            else {
                return null;
            }
        }

        [WebMethod(EnableSession = true)]
        public Boolean IsUsuario(String Nombre)
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI"))
            {
                string expNombre = "^([A-Z]{1}[a-zñáéíóú]{1,30}[- ]{0,1}|[A-Z]{1}[- \']{1}[A-Z]{0,1}[a-zñáéíóú]{1,30}[- ]{0,1}|[a-z]{1,2}[ -\']{1}[A-Z]{1}[a-zñáéíóú]{1,30}){1,5}";
                if (Regex.IsMatch(Nombre, expNombre))
                {
                    return DAO.IsUsuario(Nombre);
                }
                throw new SystemException("El nombre ingresado no es valido");
            }
            else {
                return false;
            }
        }

        [WebMethod(EnableSession = true)]
        public MUsuarios Getbycorreo(String correo)
        {
            if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI"))
            {
                string expCorreo = @"^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+";
                if (Regex.IsMatch(correo, expCorreo))
                {
                    return DAO.GetbyCorreo(correo);
                }
                throw new SystemException("El correo ingresado no es valido");
            }
            else {
                return null;
            }
        }

        [WebMethod(EnableSession = true)]
        public Boolean Confirmar(String correo, String pw)
        {
            string expCorreo = @"^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9\-]+\.[a-zA-Z0-9\-\.]+";
            if (Regex.IsMatch(correo, expCorreo)) {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                if (DAO.GetbyCorreo(correo).Contraseña.Equals(BitConverter.ToString(hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(pw)))))
                {

                    Session["Usuario"] = "SI";
                    String c = Session["Usuario"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            throw new SystemException("El correo ingresado no es valido");

        }

        [WebMethod(EnableSession = true)]
        public void Eliminar(string id)
        {
            string expid = "^[1-9][0-9]*";
            if (Regex.IsMatch(id, expid))
            {
                if (Session["Usuario"] != null && Session["Usuario"].ToString().Equals("SI"))
                {
                    DAO.Eliminar(id);
                }
                else
                {
                    throw new SystemException("El id ingresado no es valido");
                }
            }
        }

        [WebMethod(EnableSession = true)]
        public void Salir()
        {
            Session["Usuario"] = null;
        }

    }
}
