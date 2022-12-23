using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class InformacionVentaController : Controller
    {


        [HttpGet]
        public ActionResult Index()
        {
            Modelo.Result result = Negocio.PuntoVenta.GetAllTotal();
            Modelo.PuntoVenta puntoVenta = new Modelo.PuntoVenta();
            puntoVenta.Estadistica = new Modelo.Estadistica();
           

            if (result.Correct)
            {

                puntoVenta.Estadistica.TotalVentas = result.Objects;
                Modelo.Estadistica resultPorcentaje = Negocio.PuntoVenta.CalcularPorcentaje(puntoVenta);
                Modelo.Result result1 = Negocio.PuntoVenta.GetAll();
                puntoVenta.PuntoVentas = result1.Objects;
                return View(puntoVenta);
            }
            else
            {
                return View(puntoVenta);                                                                                                                                                        
            }
        }












    }
}