using LeoTodo.Dominio.Entidade;
using LeoTodo.Dominio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeoTodo.Web.Proxy
{
    public class TarefaProxy
    {
        TarefaDomainService tarefaDomainService = new TarefaDomainService();

        public Tarefa ConsultarPorId(int id)
        {
            var tarefaBanco = tarefaDomainService.ConsultarPorId(id);

            return tarefaBanco;
        }

        public IEnumerable<Tarefa> ConsultarTarefas()
        {
            var listaTarefasRetorno = tarefaDomainService.ConsultarTodasTarefas();

            return listaTarefasRetorno;
        }

        public Tarefa IncluirTarefa(Tarefa tarefa)
        {
            var tarefaNova = tarefaDomainService.IncluirTarefa(tarefa);

            return tarefaNova;
        }

        public void AlterarTarefa(Tarefa tarefa)
        {
            tarefaDomainService.AlterarTarefa(tarefa);
        }

        public void DeletarTarefa(Tarefa tarefa)
        {
            tarefaDomainService.DeleteTarefa(tarefa);
        }
    }
}