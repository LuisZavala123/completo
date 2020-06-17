using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Modelos
{
    public class MVentas
    {
        public String fecha { get; set; }
        public Double total { get; set; }
        public String id { get; set; }
        public String descripccion { get; set; }

        public List<MDetalles> Detalles = new List<MDetalles>();

        public MVentas()
        {
        }

        public MVentas(string fecha, double total, string id, string descripccion)
        {
            this.fecha = fecha;
            this.total = total;
            this.id = id;
            this.descripccion = descripccion;
        }
    }
}