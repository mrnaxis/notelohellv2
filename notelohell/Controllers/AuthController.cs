using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using notelohell.Models;

namespace notelohell.Controllers
{
    public class AuthController : Controller
    {
        /*Não temos certeza se utilizaremos isso, mas deixarei aqui caso contrário...*/
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(UsersModel user)
        {
            //fazer validações antes
            user.gravarUsuario(user);
            return RedirectToAction("Index", "Home");
        }

        [ValidateAntiForgeryToken]
        public ActionResult ValidateLogin()
        {
            if(!ModelState.IsValid)
                return View();

            return null;
        }
    }
}