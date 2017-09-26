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
            //TaskUserDAO dao = new TaskUserDAO();
            //List<TaskUserModel> tasks = dao.BuscarTasks(Session["PlayerName"].ToString() ?? "null");
            //ViewBag.Task = tasks;
            return View();
        }

        public JsonResult newTask(TaskUserModel task)
        {
            //TaskUserModel task = (TaskUserModel)json;
            // Session["PlayerName"].ToString()??"";
            task.gravarTask("hojs@hojs.com");
            return Json(new { });
        }
        public JsonResult ChangeTask()
        {
            return Json(new { });
        }
    }
}