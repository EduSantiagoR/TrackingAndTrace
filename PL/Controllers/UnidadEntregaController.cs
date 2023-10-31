using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UnidadEntregaController : Controller
    {
        // GET: UnidadEntrega
        public ActionResult GetAll()
        {
            ML.UnidadEntrega unidadEntrega = new ML.UnidadEntrega();
            unidadEntrega.Unidades = new List<object>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53696/api/");
                var responseTask = client.GetAsync("unidadEntrega");
                responseTask.Wait();
                
                var resultService = responseTask.Result;
                if (resultService.IsSuccessStatusCode)
                {
                    var readTask = resultService.Content.ReadAsAsync<ML.UnidadEntrega>();
                    readTask.Wait();
                    
                    foreach (var resultItem in readTask.Result.Unidades)
                    {
                        ML.UnidadEntrega unidadItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.UnidadEntrega>(resultItem.ToString());
                        unidadEntrega.Unidades.Add(unidadItem);
                    }
                }
            }
            return View(unidadEntrega);
        }
        [HttpGet]
        public ActionResult Form(int? idUnidadEntrega)
        {
            ML.UnidadEntrega unidadEntrega = new ML.UnidadEntrega();
            unidadEntrega.Estatus = new ML.EstatusUnidad();
            if(idUnidadEntrega != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:53696/api/");
                    var responseTask = client.GetAsync($"unidadEntrega/{idUnidadEntrega}");
                    responseTask.Wait();

                    var resultService = responseTask.Result;
                    if (resultService.IsSuccessStatusCode)
                    {
                        var readTask = resultService.Content.ReadAsAsync<ML.UnidadEntrega>();
                        readTask.Wait();
                        
                        unidadEntrega = readTask.Result;
                    }
                }
            }
            unidadEntrega.Estatus.EstatusList = BL.EstatusUnidad.GetAll();
            return View(unidadEntrega);
        }
        [HttpPost]
        public ActionResult Form(ML.UnidadEntrega unidadEntrega)
        {
            if(unidadEntrega.IdUnidad == 0)
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:53696/api/");
                    var responseTask = client.PostAsJsonAsync("unidadEntrega", unidadEntrega);
                    responseTask.Wait();
                    var resultService = responseTask.Result;
                    if (resultService.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Agregado correctamente.";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error al agregar.";
                    }
                }
                
            }
            else
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:53696/api/");
                    var responseTask = client.PutAsJsonAsync($"unidadEntrega/{unidadEntrega.IdUnidad}", unidadEntrega);
                    responseTask.Wait();
                    var resultService = responseTask.Result;
                    if (resultService.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Actualizado correctamente.";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error al actualizar.";
                    }
                }
            }
            return PartialView("Modal");
        }
        public ActionResult Delete(int idUnidadEntrega)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53696/api/");
                var responseTask = client.DeleteAsync($"unidadEntrega/{idUnidadEntrega}");
                responseTask.Wait();
                var resultService = responseTask.Result;
                if (resultService.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Eliminado correctamente.";
                }
                else
                {
                    ViewBag.Mensaje = "Error al eliminar";
                }
            }
            return PartialView("Modal");
        }
    }
}
