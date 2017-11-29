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