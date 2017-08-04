using notelohell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace notelohell.AuthControl
{
    public class IDRequired:ActionFilterAttribute
    {
        //Classe para autorização basica de usuários, please mind with care
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UsersModel us = (UsersModel)filterContext.HttpContext.Session["Player"];
            if (us == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Login", controller = "Auth" }));
            }
        }
    }
}