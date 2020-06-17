using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Modelos
{
    public class MArticulos
    {
        public String tipo { get; set; }
        public String nombre { get; set; }
        public Double costo { get; set; }
        public String id { get; set; }
        public String descripccion { get; set; }//aqui se agregaran todos los detalles

        public MArticulos()
        {
        }

        public MArticulos(string tipo, string nombre, double costo, string id, string descripccion)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.costo = costo;
            this.id = id;
            this.descripccion = descripccion;
        }
    }
}