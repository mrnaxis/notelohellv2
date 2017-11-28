using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using notelohell.Services;
using notelohell.Models;


namespace notelohell.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult Teste(string tag)
        {
            if (string.IsNullOrEmpty(tag))
                return Json(new object { });

            UsersModel user = (UsersModel)Session["Player"];//necessário reformular, tem que ver se o usuário é cadastrado primeiro
            string data = string.Empty;
            OwAPI api = new OwAPI();
            try
            {
                data = api.Buscar(tag,user);
            }
            catch
            {
                //erro custom aqui
            }
            

            return Json(data);
        }
    }
}