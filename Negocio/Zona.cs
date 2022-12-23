using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Zona
    {
        public static Modelo.Result GetAll()
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Acceso_Datos.PRUEBA_UNIGISEntities conn = new Acceso_Datos.PRUEBA_UNIGISEntities())
                {
                    var query = conn.GetAllZona().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var resultado in query)
                        {
                            Modelo.Zona zona = new Modelo.Zona();

                            zona.IdZona = resultado.IdZona;
                            zona.NomZona = resultado.NomZona;


                            result.Objects.Add(zona);

                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }

                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.Ex = e;
                result.ErrorMessage = e.Message;

            }
            return result;
        }
    }
}
