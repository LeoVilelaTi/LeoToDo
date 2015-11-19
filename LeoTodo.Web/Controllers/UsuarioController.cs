using System.Web.Mvc;
using LeoTodo.Dominio.Entidades;
using LeoTodo.Dominio.Repositorios;
using LeoTodo.Dominio.Servicos;
using LeoTodo.Web.Models;

namespace LeoTodo.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            return View(new UsuarioModel());
        }

        [HttpPost]
        public ActionResult Inserir(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioDominio = new UsuarioDominioServico();
                usuarioDominio.Incluir(usuario.ToEntidade());
            }
            else
            {
                return View("Index", usuario);
            }

            return PartialView("~/Views/Usuario/NovoUsuarioCadastrado.cshtml");            
        }

        public ActionResult PrimeiroAcesso(string identificador, string guid)
        {
            var usuarioDominio = new UsuarioDominioServico();
            var valido = usuarioDominio.UsuarioAtivado(identificador, guid);

            if (valido)
            {
                return PartialView("~/Views/Usuario/BoasVindasNovoUsuario.cshtml");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult EsqueciMinhaSenha()
        {
            return View();
        }

        public ActionResult EnviaEmailAlteracaoDeSenha(string email)
        {
            var usuarioDominio = new UsuarioDominioServico();
            usuarioDominio.EnviarEmailAlteracaoDeSenha(email);

            return PartialView("~/Views/Usuario/EnviaEmailAlteracaoDeSenha.cshtml");
        }

        public ActionResult RedefinirSenha(string identificador, string guid)
        {
            var usuarioDominio = new UsuarioDominioServico();
            bool valido = usuarioDominio.UsuarioAtivado(identificador, guid);

            if (valido)
            {
                var usuarioModel = new UsuarioModel
                {
                    Identificador = identificador
                };

                return View(usuarioModel);
            }
            else
            {
                return PartialView("~/Views/Usuario/ResetDeSenhaNaoRealizado.cshtml");
            }
        }

        public ActionResult ResetSenha(Usuario usuario)
        {
            var usuarioDominio = new UsuarioDominioServico();
            usuarioDominio.ResetSenha(usuario);

            return RedirectToAction("Index", "Login");
        }
    }
}