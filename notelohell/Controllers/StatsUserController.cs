﻿using System;
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
        public JsonResult BuscarTasksGeral()
        {
            TaskUserModel t = new TaskUserModel();
            List<TaskUserModel> tasks = t.BuscarTasks(Session["PlayerName"].ToString());

            if (tasks != null)
            {
                return Json(new
                {
                    TasksTotal = tasks.Count.ToString(),
                    TasksDone = tasks.Count(x => x.Complete == true).ToString(),
                    TaskUnDone = tasks.Count(x => x.Complete == false).ToString()
                });
            }
            else
                return Json(new { });
        }
    }
}