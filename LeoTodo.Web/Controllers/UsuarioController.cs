using LeoTodo.Dominio.Entidades;
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

            return PartialView("~/Views/Usuario/NovoUsuarioCadastrado.cshtml");            
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
            bool valido = proxy.UsuarioAtivado(identificador, guid);

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

        public ActionResult EnviaEmailParaRecuperacaoSenha(string email)
        {
            UsuarioProxy proxy = new UsuarioProxy();
            proxy.EnviaEmailParaRecuperacaoSenha(email);

            return PartialView("~/Views/Usuario/EnvioDeEmailParaRedefinicaoSenha.cshtml");
        }

        public ActionResult RedefinirSenha(string identificador, string guid)
        {
            LoginProxy proxyLogin = new LoginProxy();
            bool valido = proxyLogin.UsuarioAtivado(identificador, guid);

            if (valido)
            {
                UsuarioProxy proxyUsuario = new UsuarioProxy();
                var usuario = proxyUsuario.ConsultarUsuarioPorIdentificador(identificador);

                var usuarioModel = new UsuarioModel
                {
                    Id = usuario.Id,
                    Identificador = usuario.Identificador,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    GuidUsuarioAtivo = usuario.GuidUsuarioAtivo,
                    DataInclusao = usuario.DataInclusao,
                    DataAlteracao = usuario.DataAlteracao
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
            UsuarioProxy proxy = new UsuarioProxy();

            var usuarioAtual = proxy.ConsultarUsuarioPorIdentificador(usuario.Identificador);

            usuarioAtual.Senha = usuario.Senha;
            usuarioAtual.DataAlteracao = DateTime.Now;

            proxy.ResetSenha(usuarioAtual);

            return RedirectToAction("Index", "Login");
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