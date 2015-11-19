using System.Web.Mvc;
using System.Web.Security;
using LeoTodo.Dominio.Repositorios;
using LeoTodo.Dominio.Servicos;
using LeoTodo.Web.Models;

namespace LeoTodo.Web.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View(new LoginModel());
        }

        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var usuarioDominio = new UsuarioDominioServico();
                var RepositorioUsuario = new UsuarioRepositorio();

                if (usuarioDominio.Autenticar(login.Identificador, login.Senha))
                {
                    var usuario = RepositorioUsuario.ConsultarUsuarioPorIdentificador(login.Identificador);

                    FormsAuthentication.SetAuthCookie(login.Identificador, false);
                    Session["UsuarioLogado"] = usuario;

                    return RedirectToAction("Index", "Home");
                }
            }
            
            return View("Index", login);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index");
        }
    }
}