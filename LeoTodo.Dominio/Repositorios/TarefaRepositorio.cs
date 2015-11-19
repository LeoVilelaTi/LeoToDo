using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using LeoTodo.Dominio.Entidades;
using LeoTodo.Dominio.Persistencia;
using LeoTodo.Dominio.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LeoTodo.Dominio.Repositorios
{
    public class TarefaRepositorio : RepositorioGenerico<Tarefa>, ITarefaRepositorio
    {
        private TodoContexto contexto = new TodoContexto();

        public Tarefa Inserir(Tarefa tarefa)
        {
            tarefa.DataInclusao = DateTime.Now;

            contexto.Tarefas.Add(tarefa);
            contexto.SaveChanges();

            return tarefa;
        }

        public void Alterar(Tarefa tarefa)
        {
            contexto.Set<Tarefa>().AddOrUpdate(tarefa);
            contexto.SaveChanges();
        }

        public void Deletar(Tarefa tarefa)
        {
            contexto.Entry(tarefa).State = EntityState.Deleted;
            contexto.SaveChanges();
        }

        public Tarefa ConsultarPorId(int id)
        {
            var tarefas = contexto.Tarefas;

            return tarefas.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Tarefa> ConsultarTodas()
        {
            var tarefas = contexto.Tarefas;

            return tarefas.ToList();
        }

        public IEnumerable<Tarefa> ConsultarPorUsuario(int idUsuario)
        {
            var tarefas = contexto.Tarefas;

            return tarefas.Where(x => x.IdUsuario == idUsuario).ToList();
        }

        public IEnumerable<Tarefa> Consultar(Expression<Func<Tarefa, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
