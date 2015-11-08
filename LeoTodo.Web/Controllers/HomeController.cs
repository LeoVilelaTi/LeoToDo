using System.Web.Security;
using LeoTodo.Dominio.Entidades;
using LeoTodo.Web.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeoTodo.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}