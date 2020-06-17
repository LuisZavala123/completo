using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Modelos
{
    public class MDetalles
    {
        public String idVenta { get; set; }
        public String producto { get; set; }
        public String Tipo { get; set; }
        public int cantidad { get; set; }
        public Double total { get; set; }

        public MDetalles()
        {
        }

        public MDetalles(string idVenta, string producto, string Tipo, int cantidad, double total)
        {
            this.idVenta = idVenta;
            this.producto = producto;
            this.Tipo = Tipo;
            this.cantidad = cantidad;
            this.total = total;
        }
    }
}