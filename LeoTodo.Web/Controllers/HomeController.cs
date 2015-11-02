using System.Web.Security;
using LeoTodo.Dominio.Entidade;
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
            // Login
            //FormsAuthentication.SetAuthCookie("email", false);
            //Session["UsuarioLogado"] = null; // A entidade do usuario que esta logado

            // Logout
            //FormsAuthentication.SignOut();
            //Session.Abandon();

            return View();
        }

        public JsonResult ConsultaTodasTarefas()
        {
            var mensagem = "OK";
            IEnumerable<Tarefa> listaRetornoTarefas = null;

            try
            {
                var proxy = new TarefaProxy();

                listaRetornoTarefas = proxy.ConsultarTodas();

                if (listaRetornoTarefas == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                mensagem = "Erro";
            }

            return Json(new { status = mensagem, data = listaRetornoTarefas }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IncluirTarefa(bool status, string titulo)
        {
            var mensagem = "OK";
            Tarefa tarefaNova = null;

            try
            {
                var proxy = new TarefaProxy();

                tarefaNova = new Tarefa()
                {
                    Concluido = status,
                    Titulo = titulo,
                    DataInclusao = DateTime.Now
                };

                if (!tarefaNova.Validar())
                {
                    throw new Exception();
                }

                tarefaNova = proxy.Incluir(tarefaNova);
            }
            catch (Exception ex)
            {
                mensagem = "Erro";
            }

            return Json(new { status = mensagem, data = tarefaNova }, JsonRequestBehavior.AllowGet);
        }

        public void AlterarTarefa(int id, bool status, string titulo)
        {
            Tarefa tarefaNova = null;
            Tarefa tarefaBanco = null;

            try
            {
                var proxy = new TarefaProxy();

                tarefaBanco = proxy.ConsultarPorId(id);
                tarefaNova = tarefaBanco;

                tarefaNova = new Tarefa()
                {
                    Id = id,
                    Concluido = status,
                    Titulo = titulo,
                    DataInclusao = tarefaBanco.DataInclusao,
                    DataAlteracao = DateTime.Now
                };

                if (!tarefaNova.Validar())
                {
                    throw new Exception();
                }

                proxy.Alterar(tarefaNova);
            }
            catch (Exception ex)
            {
            }
        }

        public void DeletarTarefa(int id)
        {
            try
            {
                var proxy = new TarefaProxy();

                proxy.Deletar(id);
            }
            catch (Exception ex)
            {
            }
        }
    }

    public class AutenticacaoController : Controller
    {
        [HttpPost]
        public ActionResult Post()
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return View();
        }
    }
}