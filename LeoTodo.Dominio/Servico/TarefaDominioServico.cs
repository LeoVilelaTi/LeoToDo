using LeoTodo.Dominio.Entidade;
using LeoTodo.Dominio.Repositorio;
using System;
using System.Collections.Generic;

namespace LeoTodo.Dominio.Servico
{
    public class TarefaDomainService
    {
        TarefaRepositorio repositorio = new TarefaRepositorio();

        public IEnumerable<Tarefa> ConsultarTodasTarefas()
        {
            var retorno = repositorio.ConsultarTodas();

            return retorno;
        }

        public Tarefa IncluirTarefa(Tarefa tarefa)
        {
            var tarefaNova = repositorio.InsereTarefa(tarefa);

            return tarefaNova;
        }

        public void AlterarTarefa(Tarefa tarefa)
        {
            repositorio.AlteraTarefa(tarefa);
        }

        public void DeleteTarefa(Tarefa tarefa)
        {
            var tarefaBanco = repositorio.ConsultarPorId(tarefa.Id);
            repositorio.DeletaTarefa(tarefaBanco);
        }
    }
}
