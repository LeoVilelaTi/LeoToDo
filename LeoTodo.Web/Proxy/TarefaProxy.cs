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

        public IEnumerable<Tarefa> ConsultarTodas()
        {
            var listaTarefasRetorno = tarefaDomainService.ConsultarTodas();

            return listaTarefasRetorno;
        }

        public Tarefa Incluir(Tarefa tarefa)
        {
            var tarefaNova = tarefaDomainService.Incluir(tarefa);

            return tarefaNova;
        }

        public void Alterar(Tarefa tarefa)
        {
            tarefaDomainService.Alterar(tarefa);
        }

        public void Deletar(int id)
        {
            tarefaDomainService.Deletar(id);
        }
    }
}