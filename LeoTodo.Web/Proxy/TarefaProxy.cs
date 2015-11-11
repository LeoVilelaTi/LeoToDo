using LeoTodo.Dominio.Entidades;
using LeoTodo.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeoTodo.Web.Proxy
{
    public class TarefaProxy
    {
        TarefaDominioService tarefaDomainService = new TarefaDominioService();

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
        public IEnumerable<Tarefa> ConsultarPorUsuario(int id)
        {
            var listaUsuarios = tarefaDomainService.ConsultarPorUsuario(id);

            return listaUsuarios;
        }
    }
}