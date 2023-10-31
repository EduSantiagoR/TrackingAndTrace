using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class RepartidorController : Controller
    {
        // GET: Repartidor
        public ActionResult GetAll()
        {
            ML.Repartidor repartidor = new ML.Repartidor();
            RepartidorServiceReference.RepartidorClient service = new RepartidorServiceReference.RepartidorClient();
            var result = service.GetAll();
            repartidor.Repartidores = result.ToList();
            return View(repartidor);
        }
        [HttpGet]
        public ActionResult Form(int? idRepartidor)
        {
            ML.Repartidor repartidor = new ML.Repartidor();
            repartidor.UnidadAsignada = new ML.UnidadEntrega();
            if (idRepartidor != null)
            {
                RepartidorServiceReference.RepartidorClient service = new RepartidorServiceReference.RepartidorClient();
                repartidor= service.GetById(idRepartidor.Value);
            }

            repartidor.UnidadAsignada.Unidades = BL.UnidadEntrega.GetAllDisponibles();

            if(idRepartidor != null)
            {
                repartidor.UnidadAsignada.Unidades.Add(repartidor.UnidadAsignada);
            }
            return View(repartidor);
        }
        [HttpPost]
        public ActionResult Form(ML.Repartidor repartidor)
        {
            RepartidorServiceReference.RepartidorClient service = new RepartidorServiceReference.RepartidorClient();
            if (repartidor.IdRepartidor == 0)
            {
                bool result = service.Add(repartidor);
                if (result)
                {
                    ViewBag.Mensaje = "Agregado correctamente.";
                }
                else
                {
                    ViewBag.Mensaje = "Error al agregar.";
                }
            }
            else
            {
                bool result = service.Update(repartidor);
                if (result)
                {
                    ViewBag.Mensaje = "Actualizado correctamente.";
                }
                else
                {
                    ViewBag.Mensaje = "Error al actualizar.";
                }
            }
            return PartialView("Modal");
        }
        public ActionResult Delete(int idRepartidor)
        {
            RepartidorServiceReference.RepartidorClient service = new RepartidorServiceReference.RepartidorClient();
            bool correct = service.Delete(idRepartidor);
            if (correct)
            {
                ViewBag.Mensaje = "Eliminado correctamente.";
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar.";
            }
            return PartialView("Modal");
        }
        public ActionResult MyProfile(int idRepartidor)
        {
            RepartidorServiceReference.RepartidorClient service = new RepartidorServiceReference.RepartidorClient();
            ML.Repartidor repartidor = service.GetById(idRepartidor);
            return View(repartidor);
        }
    }
}