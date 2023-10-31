using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Usuario usuario = BL.Usuario.GetAll();
            return View(usuario);
        }
        [HttpGet]
        public ActionResult Form(int? idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            if (idUsuario != null)
            {
                usuario = BL.Usuario.GetById(idUsuario.Value);
            }
            usuario.Rol.Roles = BL.Rol.GetAll();
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            bool resultado = false;
            if(usuario.IdUsuario == 0)
            {
                resultado = BL.Usuario.Add(usuario);
                if (resultado)
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
                resultado = BL.Usuario.Update(usuario);
                if(resultado)
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
        public ActionResult Delete(int idUsuario)
        {
            bool resultado = BL.Usuario.Delete(idUsuario);
            if( resultado )
            {
                ViewBag.Mensaje = "Eliminado correctamente.";
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar.";
            }
            return PartialView("Modal");
        }
    }
}