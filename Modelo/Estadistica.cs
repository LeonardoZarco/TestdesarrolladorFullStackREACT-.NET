using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Estadistica
    {
        public decimal TotalVenta { get; set; }
        public Modelo.PuntoVenta puntoVenta { get; set; }
        public List<object> TotalVentas { get; set; }

    }
}
