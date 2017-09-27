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
            return Json(new { });
        }

        public JsonResult SearchTask(string nome)
        {
            TaskUserModel t = new TaskUserModel();
            List<TaskUserModel> lt = t.BuscarTasks(Session["PlayerName"].ToString(), nome);
            if (lt.Count == 1)
                return Json(lt[0]);
            return null;
        }

        public JsonResult ChangeTask()
        {
            return Json(new { });
        }
    }
}