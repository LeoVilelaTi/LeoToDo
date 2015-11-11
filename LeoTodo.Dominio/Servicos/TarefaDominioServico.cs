using LeoTodo.Dominio.Entidades;
using LeoTodo.Dominio.Repositorios;
using System;
using System.Collections.Generic;

namespace LeoTodo.Dominio.Servicos
{
    public class TarefaDominioService
    {
        TarefaRepositorioLeitura repositorioLeitura = new TarefaRepositorioLeitura();
        TarefaRepositorioEscrita repositorioEscrita = new TarefaRepositorioEscrita();


        public Tarefa ConsultarPorId(int id)
        {
            var retorno = repositorioLeitura.ConsultarPorId(id);

            return retorno;
        }

        public IEnumerable<Tarefa> ConsultarTodas()
        {
            var retorno = repositorioLeitura.ConsultarTodas();

            return retorno;
        }

        public Tarefa Incluir(Tarefa tarefa)
        {
            var tarefaNova = repositorioEscrita.Inserir(tarefa);

            return tarefaNova;
        }

        public void Alterar(Tarefa tarefa)
        {
            repositorioEscrita.Alterar(tarefa);
        }

        public void Deletar(int id)
        {
            var tarefaBanco = repositorioLeitura.ConsultarPorId(id);
            repositorioEscrita.Deletar(tarefaBanco);
        }

        public IEnumerable<Tarefa> ConsultarPorUsuario(int id)
        {
            var listaUsuarios = repositorioLeitura.ConsultarPorUsuario(id);

            return listaUsuarios;
        }
    }
}
