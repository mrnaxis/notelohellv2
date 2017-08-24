using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using notelohell.Models;

namespace notelohell.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RegistrarUsuario(UsersModel user)
        {
            //fazer validações antes
            if (!ModelState.IsValid)
                return View();

            user.GravarUsuario();
            return RedirectToAction("Index", "Home");
        }
    }
}