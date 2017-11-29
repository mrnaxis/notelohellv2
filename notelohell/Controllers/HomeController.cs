using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using notelohell.Services;
using notelohell.Models;
using MongoDB.Bson;
using notelohell.Utils;
namespace notelohell.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            OwStats stats = new OwStats();
            var teste = stats.DadosOverWatch();//gambipt2

            //Gambi();
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
        /// <summary>
        /// Aquela gambi que não pode faltar.
        /// </summary>
        public void Gambi()
        {
            OwAPI api = new OwAPI();
            string datinha = "01/01/1999";
            IFormatProvider culture = new System.Globalization.CultureInfo("pt-BR", true);
            DateTime dt = DateTime.Parse(datinha, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            UsersModel user = new UsersModel();
            user.Nome = "Nick Nicosa";
            user.Email = "nick@nick.com";
            user.Pwsin = "12345";
            user.GameTag = "Nick#11382";
            user.BirthDate = dt;
            user.Ativo = true;
            user.GravarUsuario();

            //user.Nome = "Bia Biosa";
            //user.Email = "bia@bia.com";
            //user.Pwsin = "12345";
            //user.GameTag = "Meshiru#1326";
            //user.BirthDate = dt;
            //user.Ativo = true;
            //user.GravarUsuario();

            user.Nome = "Sujeito Sujeitoso";
            user.Email = "sujeito@sujeito.com";
            user.Pwsin = "12345";
            user.GameTag = "SujeitoX#1832";
            user.BirthDate = dt;
            user.Ativo = true;
            user.GravarUsuario();

            user.Nome = "Heally Heloso";
            user.Email = "nathan@nathan.com";
            user.Pwsin = "12345";
            user.GameTag = "Heally#11934";
            user.BirthDate = dt;
            user.Ativo = true;
            user.GravarUsuario();

            user.Nome = "Sixio";
            user.Email = "sixio@sixio.com";
            user.Pwsin = "12345";
            user.GameTag = "Sixio#1521";
            user.BirthDate = dt;
            user.Ativo = true;
            user.GravarUsuario();

            user.Nome = "Andre Andresoso";
            user.Email = "andre@andre.com";
            user.Pwsin = "12345";
            user.GameTag = "ArcticWind#1221";
            user.BirthDate = dt;
            user.Ativo = true;
            user.GravarUsuario();

        }
    }
}