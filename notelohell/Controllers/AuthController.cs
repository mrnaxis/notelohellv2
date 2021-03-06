﻿using System;
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

        [IDRequired]
        public ActionResult LogOff()
        {
            Session["Player"] = null;
            Session["PlayerName"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValidateLogin(string login, string senha)
        {
            if(!ModelState.IsValid)
                return View("Login");

            if (login == "" || senha == "")
            {
                ViewBag.Error = true;
                ViewBag.ErrorMsg = "Campo de login e senha devem ser preenchidos.";
                return View("Login");
            }

            UsersModel us = new UsersModel
            {
                Email = login,
                Pwsin = senha
            };

            us = us.BuscarUsuario();

            if (us != null && us.Ativo)
            {
                Session["Player"] = us;
                Session["PlayerName"] = us.Email;
                return RedirectToAction("Index", "Home");
            }
            else if(us == null)
            {
                ViewBag.Error = true;
                ViewBag.ErrorMsg = "Usuário ou Senha Invalidos.";
                ViewBag.Email = login;
                return View("Login");
            }
            else
            {
                ViewBag.Error = true;
                ViewBag.ErrorMsg = "Usuário inativo.";
                ViewBag.Email = login;
                return View("Login");
            }
        }


    }
}