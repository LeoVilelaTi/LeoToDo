using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LeoTodo.Dominio.Repositorios;
using LeoTodo.Dominio.Servicos;
using LeoTodo.Web.Fabrica;
using LeoTodo.Web.Models;

namespace LeoTodo.Web.Controllers
{
    public class TarefaController : AutenticadoController
    {
        public ActionResult Index()
        {
            var tarefa = new TarefaModel
            {
                TarefasConsultadas = ListaTarefasModel()
            };
            return View(tarefa);
        }

        [HttpPost]
        public ActionResult Inserir(TarefaModel tarefa)
        {
            var usuario = this.UsuarioLogado;

            if (usuario == null)
            {
                return View();
            }

            tarefa.IdUsuario = usuario.Id;

            var tarefaDomainService = new TarefaDominioService();
            tarefaDomainService.Incluir(tarefa.ToEntidade());

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Alterar(TarefaModel viewModel)
        {
            var entidade = viewModel.ToEntidade();

            var tarefaDomainService = new TarefaDominioService();
            tarefaDomainService.Alterar(entidade);

            return RedirectToAction("Index");
        }

        public ActionResult Deletar(int id)
        {
            var tarefaDomainService = new TarefaDominioService();
            tarefaDomainService.Deletar(id);

            return RedirectToAction("Index");
        }

        private List<TarefaModel> ListaTarefasModel()
        {
            if (this.UsuarioLogado != null)
            {
                var repositorioTarefa = new TarefaRepositorio();

                var listaTarefas = repositorioTarefa.ConsultarPorUsuario(this.UsuarioLogado.Id).ToList();

                var listaTarefasModel = listaTarefas.Select(TarefaFabrica.Criar).ToList();

                return listaTarefasModel;
            }

            return null;
        }
    }
}