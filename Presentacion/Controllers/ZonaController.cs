using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class ZonaController : Controller
    {
        public ActionResult GetAll()
        {
            Modelo.Zona zona = new Modelo.Zona();
            zona.Zonas = new List<Object>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                var responseTask = client.GetAsync("Zona/GetAllZona");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Modelo.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        Modelo.Zona resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<Modelo.Zona>(resultItem.ToString());
                        zona.Zonas.Add(resultItemList);
                    }
                }
            }
            return View(zona);
        }
    }
}