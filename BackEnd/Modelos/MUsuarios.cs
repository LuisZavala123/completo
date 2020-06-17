using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Modelos
{
    public class MUsuarios
    {
        public String IdUsuario { get; set; }
        public String Nombre { get; set; }
        public String Primer_Apellido { get; set; }
        public String Segundo_Apellido { get; set; }
        public String Contraseña { get; set; }
        public String Correo { get; set; }
        public String Tipo { get; set; }

        public MUsuarios()
        {
        }

        public MUsuarios(string idUsuario, string nombre, string primer_Apellido, string segundo_Apellido, string contraseña, string correo, string tipo)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Primer_Apellido = primer_Apellido;
            Segundo_Apellido = segundo_Apellido;
            Contraseña = contraseña;
            Correo = correo;
            Tipo = tipo;
        }
    }
}