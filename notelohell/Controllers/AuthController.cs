using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        [ValidateAntiForgeryToken]
        public ActionResult ValidateLogin()
        {
            if(!ModelState.IsValid)
                return View();

            return null;
        }
    }
}