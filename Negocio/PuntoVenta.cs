using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PuntoVenta
    {
        public static Modelo.Result Add(Modelo.PuntoVenta puntoVenta)
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Acceso_Datos.PRUEBA_UNIGISEntities conn = new Acceso_Datos.PRUEBA_UNIGISEntities())

                {
                    var query = conn.AddPunto(puntoVenta.Latitud,
                        puntoVenta.Longitud,
                        puntoVenta.Descripcion,
                        puntoVenta.Venta,
                        puntoVenta.Zona.IdZona);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el insert";
                    }
                    result.Correct = true;
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


        public static Modelo.Result Update(Modelo.PuntoVenta puntoVenta)
        {

            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Acceso_Datos.PRUEBA_UNIGISEntities conn = new Acceso_Datos.PRUEBA_UNIGISEntities())
                {
                    var query = conn.UpdatePunto(puntoVenta.ID,
                        puntoVenta.Latitud,
                        puntoVenta.Longitud,
                        puntoVenta.Descripcion,
                        puntoVenta.Venta,
                        puntoVenta.Zona.IdZona);

                    if (query >= 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la actualización";
                    }
                    result.Correct = true;
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
        public static Modelo.Result Delete(int id)
        {

            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Acceso_Datos.PRUEBA_UNIGISEntities conn = new Acceso_Datos.PRUEBA_UNIGISEntities())
                {
                    var query = conn.DeletePunto(id)
;
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido eliminar el registro";
                    }
                    result.Correct = true;
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

        public static Modelo.Result GetAll()
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Acceso_Datos.PRUEBA_UNIGISEntities conn = new Acceso_Datos.PRUEBA_UNIGISEntities())
                {
                    var query = conn.GetAllPunto().ToList();
                    //var query1 = conn.GetAllZona().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var resultado in query)
                        {
                            Modelo.PuntoVenta puntoVenta = new Modelo.PuntoVenta();

                            puntoVenta.ID = resultado.ID;
                            puntoVenta.Latitud = (decimal)resultado.Latitud;
                            puntoVenta.Longitud = (decimal)resultado.Longitud;
                            puntoVenta.Descripcion = resultado.Descripcion;
                            puntoVenta.Venta = (decimal)resultado.Venta;

                            puntoVenta.Zona = new Modelo.Zona();
                            puntoVenta.Zona.IdZona = (int)resultado.IdZona;
                            puntoVenta.Zona.NomZona = resultado.NomZona;


                            result.Objects.Add(puntoVenta);

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
        public static Modelo.Result GetById(int id)
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Acceso_Datos.PRUEBA_UNIGISEntities conn = new Acceso_Datos.PRUEBA_UNIGISEntities())

                {
                    var query = conn.GetByPunto(id);



                    Acceso_Datos.GetByPunto_Result resultado = query.First();

                    if (query != null)
                    {

                        Modelo.PuntoVenta puntoVenta = new Modelo.PuntoVenta();

                        puntoVenta.ID = resultado.ID;
                        puntoVenta.Latitud = (decimal)resultado.Latitud;
                        puntoVenta.Longitud = (decimal)resultado.Longitud;
                        puntoVenta.Descripcion = resultado.Descripcion;
                        puntoVenta.Venta = (decimal)resultado.Venta;

                        puntoVenta.Zona = new Modelo.Zona();
                        puntoVenta.Zona.IdZona = (int)resultado.IdZona;
                        puntoVenta.Zona.NomZona = resultado.NomZona;



                        result.Object = puntoVenta;
                    }

                    if (result.Object != null) result.Correct = true;
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


        public static Modelo.Result GetAllTotal()
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Acceso_Datos.PRUEBA_UNIGISEntities conn = new Acceso_Datos.PRUEBA_UNIGISEntities())
                {
                    var query = conn.GetAllTotalVentas().ToList();
        
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var resultado in query)
                        {
                            Modelo.PuntoVenta puntozona = new Modelo.PuntoVenta();
                            Modelo.Zona zona = new Modelo.Zona();


                            puntozona.Zona = new Modelo.Zona();
                            puntozona.Zona.IdZona = (int)resultado.IdZona;
                            puntozona.Zona.NomZona = resultado.NomZona;
                            puntozona.Venta = (decimal)resultado.VENTA_POR_ZONA;

                            result.Objects.Add(puntozona);

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
        public static Modelo.Estadistica CalcularPorcentaje(Modelo.PuntoVenta puntoVenta)
        {
            Modelo.Result result = new Modelo.Result();
            Modelo.Estadistica estadistica = new Modelo.Estadistica();
            puntoVenta.TotalVentas = 0;
            foreach (Modelo.PuntoVenta venta in puntoVenta.Estadistica.TotalVentas)
            {
                puntoVenta.TotalVentas = puntoVenta.TotalVentas + venta.Venta;
            }
            result.Objects = new List<object>();
            foreach (Modelo.PuntoVenta procentaje in puntoVenta.Estadistica.TotalVentas)
            {
                procentaje.Venta = (procentaje.Venta / puntoVenta.TotalVentas) * 100;
                result.Objects.Add(procentaje);
            }
            return estadistica;
        }













        //public static Modelo.Result GetByUserNombre(string UserName)
        //{
        //    Modelo.Result result = new Modelo.Result();
        //    try
        //    {
        //        using (Acceso_Datos.PRUEBA_UNIGISEntities conn = new Acceso_Datos.PRUEBA_UNIGISEntities())

        //        {
        //            var query = conn.GetByUserNombre(UserName).FirstOrDefault();


        //            if (query != null)
        //            {
        //                Modelo.Usuario usuario = new Modelo.Usuario();
        //                usuario.UserName = query.Username;
        //                usuario.Password = query.Password;
        //                usuario.IdUsuario = query.IdUsuario;

        //                result.Object = usuario;

        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se ha podido realizar la consulta";
        //            }
        //            result.Correct = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //    }

        //    return result;
        //}


    }
}
