using LeoTodo.Web.Models;
using LeoTodo.Web.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeoTodo.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConsultaTarefaPorId(TarefaModel tarefaModel)
        {
            TarefaProxy proxy = new TarefaProxy();
            var tarefa = proxy.ConsultarPorId(tarefaModel.Id);

            var listaTarefasModel = new List<TarefaModel>
                {
                    new TarefaModel
                    {
                        Id = tarefa.Id,
                        Titulo = tarefa.Titulo,
                        Concluido = tarefa.Concluido,
                        DataInclusao = tarefa.DataInclusao,
                        DataAlteracao = tarefa.DataAlteracao
                    }
                };

            return PartialView("_resultadoPesquisa", listaTarefasModel);
        }
    }
}