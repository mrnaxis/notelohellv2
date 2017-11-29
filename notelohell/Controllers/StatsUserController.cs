using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using notelohell.Models;
using notelohell.AuthControl;

namespace notelohell.Controllers
{
    public class StatsUserController : Controller
    {
        // GET: StatsUser
        [IDRequired]
        public ActionResult StatsUser()
        {
            return View();
        }

        /// <summary>
        /// Busca dados do usuário logado
        /// </summary>
        public JsonResult BuscarDadosJogos()
        {
            UsersModel user = (UsersModel)Session["Player"];
            user = user.BuscarUsuario();
            return Json(user.DadosOverWatch.ToString());
        }
    }
}