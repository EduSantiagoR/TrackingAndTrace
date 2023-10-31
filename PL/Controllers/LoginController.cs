using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario = BL.Login.CheckLogin(username, password);
            if (usuario.UserName != null && usuario.Password != null)
            {
                Session["Rol"] = usuario.Rol.Tipo;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensaje = "El usuario o contraseña son incorrectos.";
                return PartialView("Modal");
            }
        }
        public ActionResult Logout()
        {
            Session["Rol"] = "Invitado";
            return RedirectToAction("Index", "Home");
        }
    }
}