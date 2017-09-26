using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using notelohell.Models;

namespace notelohell.Controllers
{
    public class TaskUserController : Controller
    {
        // GET: TaskUser
        public ActionResult TaskUser()
        {
            return View();
        }

        public JsonResult newTask(object json)
        {
            TaskUserModel task = (TaskUserModel)json;
            task.EmailTask = Session["PlayerName"].ToString();
            task.gravarTask();
            return Json(new { });
        }
        public JsonResult ChangeTask()
        {
            return Json(new { });
        }
    }
}