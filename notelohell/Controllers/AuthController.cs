using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using notelohell.Models;
using notelohell.DAO;
using notelohell.AuthControl;

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
        [IDRequired]
        public ActionResult BeholderUser()
        {
            UsersModel us = (UsersModel) Session["Player"];
            return View(us);
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(UsersModel user)
        {
            //fazer validações antes
            if (!ModelState.IsValid)
                return View();

            user.GravarUsuario();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValidateLogin(string login, string senha)
        {
            if(!ModelState.IsValid)
                return View();

            if (login == "" || senha == "")
                return RedirectToAction("Login", "Auth");

            UsersModel us = new UsersModel
            {
                Email = login,
                Pwsin = senha
            };

            us = us.BuscarUsuario();

            if (us != null)
            {
                Session["Player"] = us;
                Session["PlayerName"] = us.Email;
                return RedirectToAction("Index", "Home");
            }
            else
                return null;
        }
    }
}