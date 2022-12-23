using System.Net;
using System.Web.Http;

namespace Servicios.Controllers
{
    public class ZonaController : ApiController
    {
        [Route("Zona/GetAllZona")]

        public IHttpActionResult GetAll()
        {
            Modelo.Result result = Negocio.Zona.GetAll();

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
