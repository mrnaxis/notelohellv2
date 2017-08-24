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
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registro()
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

        public void BuscarUsuario(string login, string senha = null)
        {
            UsersModel user = new UsersModel();
            user.Email = login;
            user.Pwsin = senha;
            user.BuscarUsuario();
        }
        [IDRequired]
        public ActionResult ChangeUser()
        {
            UsersModel us = (UsersModel)Session["Player"];
            return View(us);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangeUserSend(UsersModel user)
        {
            //if (!ModelState.IsValid)
            //    return View();

            user.AlterarUsuario();
            return RedirectToAction("BeholderUser", "Auth");
        }

        [IDRequired]
        public ActionResult ChangePass()
        {
            return View();
        }

        public ActionResult ChangePassSend(string pass_old, string pass_new)
        {
            if (!string.IsNullOrEmpty(pass_old) || !string.IsNullOrEmpty(pass_new))
            {
                return View("ChangePass");
            }
            return RedirectToAction("BeholderUser", "Auth");
        }
    }
}