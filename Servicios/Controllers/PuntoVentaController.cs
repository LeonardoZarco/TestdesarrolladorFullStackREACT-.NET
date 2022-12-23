using System.Net;
using System.Web.Http;

namespace Servicios.Controllers
{
    public class PuntoVentaController : ApiController
    {
        [HttpGet]
        [Route("PuntoVenta/GetAllPunto")]

        public IHttpActionResult GetAll()
        {
            Modelo.Result result = Negocio.PuntoVenta.GetAll();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [HttpGet]
        [Route("PuntoVenta/GetByPunto/{ID}")]
        public IHttpActionResult GetById(int ID)
        {
            Modelo.Result result = Negocio.PuntoVenta.GetById(ID);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }


        }

        [HttpPost]
        [Route("PuntoVenta/AddPunto")]
        public IHttpActionResult Add([FromBody] Modelo.PuntoVenta puntoVenta)
        {
            Modelo.Result result = Negocio.PuntoVenta.Add(puntoVenta);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }


        }

        [HttpPost]
        [Route("PuntoVenta/UpdatePunto/{ID}")]
        public IHttpActionResult Put(int ID, [FromBody] Modelo.PuntoVenta puntoVenta)
        {
            Modelo.Result result = Negocio.PuntoVenta.Update(puntoVenta);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpGet]
        [Route("PuntoVenta/DeletePunto/{ID}")]
        public IHttpActionResult Delete(int ID)
        {

            Modelo.Result result = Negocio.PuntoVenta.Delete(ID);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }


    }
}