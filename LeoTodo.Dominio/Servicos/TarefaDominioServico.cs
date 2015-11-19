using System;
using LeoTodo.Dominio.Entidades;
using LeoTodo.Dominio.Repositorios;

namespace LeoTodo.Dominio.Servicos
{
    public class TarefaDominioService
    {
        public Tarefa Incluir(Tarefa tarefa)
        {
            var repositorioTarefa = new TarefaRepositorio();

            var tarefaNova = repositorioTarefa.Inserir(tarefa);

            return tarefaNova;
        }

        public void Alterar(Tarefa tarefa)
        {
            var repositorioTarefa = new TarefaRepositorio();

            var tarefaAtual = repositorioTarefa.ConsultarPorId(tarefa.Id);

            tarefaAtual.Titulo = tarefa.Titulo.Trim();
            tarefaAtual.Concluido = tarefa.Concluido;
            tarefaAtual.DataAlteracao = DateTime.Now;

            repositorioTarefa.Alterar(tarefaAtual);
        }

        public void Deletar(int id)
        {
            var repositorioTarefa = new TarefaRepositorio();

            var tarefaBanco = repositorioTarefa.ConsultarPorId(id);

            repositorioTarefa.Deletar(tarefaBanco);
        }
    }
}
