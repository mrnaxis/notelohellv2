using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;


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

            if (tag.IndexOf("#") > 0)
                tag = tag.Replace("#","-");

            string data = string.Empty;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("Accept-Language", " en-US");
                    wc.Headers.Add("Accept", " text/html, application/xhtml+xml, */*");
                    wc.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)");
                    string url = "http://owapi.net/api/v3/u/" + tag + "/heroes";
                    data = wc.DownloadString(url);
                }
            }
            catch
            {
                //erro custom aqui
            }
            

            return Json(data);
        }
    }
}