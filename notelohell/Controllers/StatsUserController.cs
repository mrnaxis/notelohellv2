using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using notelohell.Models;
using notelohell.AuthControl;
using notelohell.Utils;

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

        public double MediaGeral()
        {
            OwStats stats = new OwStats();
            return stats.CalcularVitoriasGeral();
        }
        public double Media()
        {
            OwStats stats = new OwStats();
            UsersModel user = (UsersModel)Session["Player"];
            return stats.CalcularVitorias(user.DadosOverWatch);
        }
    }
}