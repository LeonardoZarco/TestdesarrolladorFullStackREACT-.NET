using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class PuntoVenta
    {
        public int ID { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string Descripcion { get; set; }
        public decimal Venta { get; set; }
        public decimal TotalVentas { get; set; }
        public Modelo.Zona Zona { get; set; }
        public Modelo.Estadistica Estadistica { get; set; }
        public List<object> PuntoVentas { get; set; }

    }
}
