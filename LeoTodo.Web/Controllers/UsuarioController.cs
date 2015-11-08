using LeoTodo.Web.Fabrica;
using LeoTodo.Web.Models;
using LeoTodo.Web.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeoTodo.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            listaUsuarios();
            return View(new UsuarioModel());
        }

        /// <summary>
        /// Insere uma novo usuário
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(UsuarioModel usuario)
        {
            UsuarioProxy proxy = new UsuarioProxy();
            proxy.Incluir(usuario.ToEntidade());

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Consulta todas os usuários
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get(UsuarioModel usuario)
        {
            return View("Index");
        }

        /// <summary>
        /// Edita um usuário
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Put(UsuarioModel usuario)
        {
            UsuarioProxy proxy = new UsuarioProxy();

            var usuarioAtual = proxy.ConsultarPorId(usuario.Id);

            usuarioAtual.Identificador = usuario.Identificador;
            usuarioAtual.Nome = usuario.Nome;
            usuarioAtual.Email = usuario.Email;
            usuarioAtual.DataAlteracao = DateTime.Now;


            proxy.Alterar(usuarioAtual);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Delete um usuário
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            UsuarioProxy proxy = new UsuarioProxy();
            proxy.Deletar(id);

            return RedirectToAction("Index");
        }

        public ActionResult PrimeiroAcesso(string identificador, string guid)
        {
            LoginProxy proxy = new LoginProxy();
            proxy.UsuarioAtivado(identificador, guid);

            return PartialView("~/Views/Usuario/_boasVindasNovoUsuario.cshtml");
        }

        public ActionResult ResetSenha(int id, string senha)
        {
            return View();
        }

        private void listaUsuarios()
        {
            UsuarioProxy proxy = new UsuarioProxy();
            var listaUsuarios = proxy.ConsultarTodas();

            var listaUsuariosModel = listaUsuarios.Select(UsuarioFabrica.Criar).ToList();

            ViewBag.ListaUsuarios = listaUsuariosModel;
        }
    }
}