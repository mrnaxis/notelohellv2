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
        [HttpPost]
        public ActionResult Registro()
        {
            //fazer validações antes
            UsersModel user = new UsersModel();
            user.gravarUsuario(user);
            return View();
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