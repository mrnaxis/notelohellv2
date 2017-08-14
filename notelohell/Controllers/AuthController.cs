using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using notelohell.Models;
using notelohell.DAO;

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
            user.gravarUsuario();
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

            UsersModel us = new UsersModel();
            us.Email = login;
            us.pwHash = senha;

            us = us.buscarUsuario();

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