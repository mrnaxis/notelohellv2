using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using notelohell.Models;
using notelohell.DAO;
using notelohell.AuthControl;

namespace notelohell.Controllers
{
    public class TaskUserController : Controller
    {
        // GET: TaskUser
        [IDRequired]
        public ActionResult TaskUser()
        {
            TaskUserModel t = new TaskUserModel();
            List<TaskUserModel> tasks = t.BuscarTasks(Session["PlayerName"].ToString());
            ViewBag.Task = tasks;
            return View();
        }
        [IDRequired]
        public JsonResult newTask(TaskUserModel task)
        {
            task.Nome = "Nova Tarefa";
            task.gravarTask(Session["PlayerName"].ToString());
            return Json(new { });
        }
        [IDRequired]
        public JsonResult SearchTask(string nome)
        {
            TaskUserModel t = new TaskUserModel();
            List<TaskUserModel> lt = t.BuscarTasks(Session["PlayerName"].ToString(), nome);
            if (lt.Count == 1)
                return Json(new { Nome = lt[0].Nome, Desc = lt[0].Desc, Data = lt[0].Data.ToString("dd/MM/yyyy"), Complete=lt[0].Complete });
            return null;
        }
        [IDRequired]
        public JsonResult ChangeTask(TaskUserModel task, string nome_old)
        {
            task.AlterarTask(Session["PlayerName"].ToString(),nome_old);
            return Json(new { });
        }
        [IDRequired]
        public JsonResult SeekAndDestroy(string Nome)
        {
            TaskUserModel t = new TaskUserModel
            {
                Nome = Nome
            };
            bool result = t.SeekAndDestroy(Session["PlayerName"].ToString(), t);
            return Json(new { Result = result });
        }
    }
}