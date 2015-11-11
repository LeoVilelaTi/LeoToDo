using LeoTodo.Web.Models;
using LeoTodo.Web.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LeoTodo.Web.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View(new LoginModel());
        }

        public ActionResult LogIn(LoginModel login)
        {
            LoginProxy LoginProxy = new LoginProxy();
            UsuarioProxy UsuarioProxy = new UsuarioProxy();


            if (LoginProxy.Autenticacao(login.Identificador, login.Senha))
            {
                var usuario = UsuarioProxy.ConsultarUsuarioPorIdentificador(login.Identificador);

                FormsAuthentication.SetAuthCookie(login.Identificador, false);
                Session["UsuarioLogado"] = usuario;

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index");
        }
    }
}