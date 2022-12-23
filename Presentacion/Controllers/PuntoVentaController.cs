using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class PuntoVentaController : Controller
    {
        public ActionResult GetAll()
        {
            Modelo.PuntoVenta puntoVenta = new Modelo.PuntoVenta();
            puntoVenta.Zona = new Modelo.Zona();
            Modelo.Result result1 = Negocio.Zona.GetAll();

            puntoVenta.PuntoVentas = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                var responseTask = client.GetAsync("PuntoVenta/GetAllPunto");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Modelo.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        Modelo.PuntoVenta resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<Modelo.PuntoVenta>(resultItem.ToString());
                        puntoVenta.PuntoVentas.Add(resultItemList);
                    }
                }
            }
            return View(puntoVenta);
        }






        [HttpPost]
        public ActionResult Form(Modelo.PuntoVenta puntoVenta)
        {
            Modelo.Result result = new Modelo.Result();
            //puntoVenta.Zona = new Modelo.Zona();
            //Modelo.Result result1 = Negocio.Zona.GetAll();

                if (puntoVenta.ID == 0)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                        var postTask = client.PostAsJsonAsync<Modelo.PuntoVenta>("PuntoVenta/AddPunto", puntoVenta);
                        postTask.Wait();

                        var resultProducto = postTask.Result;
                        if (resultProducto.IsSuccessStatusCode)

                        {
                            ViewBag.Message = "Se registro correctamente";
                        }
                        else
                        {
                            ViewBag.Message = "No se ha registrado" + result.ErrorMessage;
                        }
                    }
                }
                else
                {

                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);


                        var postTask = client.PostAsJsonAsync<Modelo.PuntoVenta>("PuntoVenta/UpdatePunto/" + puntoVenta.ID, puntoVenta);
                        postTask.Wait();

                        var resultUsario = postTask.Result;

                        if (resultUsario.IsSuccessStatusCode)
                        {
                            ViewBag.Message = " Se ha actualizado correctamente";
                        }
                        else
                        {
                            ViewBag.Message = "No se ha actualizado correctamente" + result.ErrorMessage;
                        }
                    }
                }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {


            Modelo.Result resultUsuario = new Modelo.Result();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                var postTask = client.GetAsync("PuntoVenta/DeletePunto/" + ID);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Haz eliminado un registro";

                }
                else
                {
                    ViewBag.Message = "No se pudo eliminar" + resultUsuario.ErrorMessage;
                }
            }

            return PartialView("Modal");


        }






        //        ////**_______________________________________________________**//
        [HttpGet]
        public ActionResult Form(int? ID)
        {
            Modelo.PuntoVenta puntoVenta = new Modelo.PuntoVenta();

            Modelo.Result result1 = Negocio.Zona.GetAll();
            puntoVenta.Zona = new Modelo.Zona();

            if (ID == null) //Add
            {
                puntoVenta.Zona.Zonas = result1.Objects;
                return View(puntoVenta);
            }
            else
            {
                Modelo.Result result = new Modelo.Result();


                using (var client = new HttpClient())
                    try
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                        var responseTask = client.GetAsync("PuntoVenta/GetByPunto/" + ID);
                        responseTask.Wait();

                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTask = resultAPI.Content.ReadAsAsync<Modelo.Result>();
                            readTask.Wait();

                            Modelo.PuntoVenta resultItemList = new Modelo.PuntoVenta();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<Modelo.PuntoVenta>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;


                            puntoVenta = ((Modelo.PuntoVenta)result.Object);
                            puntoVenta.Zona.Zonas = result1.Objects;



                            return View(puntoVenta);
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla";
                        }
                    }

                    catch (Exception ex)
                    {
                        result.Correct = false;
                        result.ErrorMessage = ex.Message;
                    }

                return View();








            }
        }

        











    }
}