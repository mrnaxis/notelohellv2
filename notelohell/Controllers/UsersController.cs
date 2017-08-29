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
        public ActionResult Registro(UsersModel user)
        {
            //fazer validações antes
            if (!ModelState.IsValid)
                return View(user);

            user.GravarUsuario();
            Session["Player"] = Session["PlayerName"] = null;
            Session["Player"] = user;
            Session["PlayerName"] = user.Email;
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
        [IDRequired]
        public ActionResult ChangeUser(UsersModel user)
        {
            ModelState.Remove("Pwsin");
            if (!ModelState.IsValid)
                return View(user);
            UsersModel userOn = (UsersModel)Session["Player"];
            user.Id = userOn.Id;            
            Session["Player"] = user.AlterarUsuario();
            TempData["ErrorALT"] = "Alterações Salvas =D";
            return RedirectToAction("BeholderUser", "Auth");
        }

        [IDRequired]
        public ActionResult ChangePass()
        {
            return View();
        }

        [IDRequired]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePass(string pass_old, string pass_new)
        {
            if (string.IsNullOrEmpty(pass_old) || string.IsNullOrEmpty(pass_new))
            {
                return View("ChangePass");
            }
            UsersModel usuario = (UsersModel)Session["Player"];
            usuario.Pwsin = pass_new;
            usuario = usuario.AlterarSenhaUsuario();

            TempData["ErrorALT"] = "Senha Alterada com Sucesso!";

            if (usuario != null)
                Session["Player"] = usuario;
            return RedirectToAction("BeholderUser", "Auth");
        }
        [IDRequired]
        public ActionResult Desativar()
        {
            UsersModel user = (UsersModel)Session["Player"];
            user.DesativarUsuario();
            return RedirectToAction("LogOff","Auth");
        }
    }
}