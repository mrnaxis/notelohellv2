using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using notelohell.Models;
using notelohell.DAO;

namespace notelohell.Controllers
{
    public class TaskUserController : Controller
    {
        // GET: TaskUser
        public ActionResult TaskUser()
        {
            TaskUserModel t = new TaskUserModel();
            List<TaskUserModel> tasks = t.BuscarTasks(Session["PlayerName"].ToString());
            ViewBag.Task = tasks;
            return View();
        }

        public JsonResult newTask(TaskUserModel task)
        {
            //TaskUserModel task = (TaskUserModel)json;
            // Session["PlayerName"].ToString()??"";
            task.gravarTask(Session["PlayerName"].ToString());
            task.Nome = "asdf";
            ChangeTask(task);
            return Json(new { });
        }

        public JsonResult SearchTask(string nome)
        {
            TaskUserModel t = new TaskUserModel();
            List<TaskUserModel> lt = t.BuscarTasks(Session["PlayerName"].ToString(), nome);
            if (lt.Count == 1)
                return Json(new { Nome = lt[0].Nome, Desc = lt[0].Desc, Data = lt[0].Data.ToString("dd/MM/yyyy"), Complete=lt[0].Complete });
            return null;
        }

        public JsonResult ChangeTask(TaskUserModel task)
        {

            task.AlterarTask(Session["PlayerName"].ToString());
            return Json(new { });
        }
    }
}