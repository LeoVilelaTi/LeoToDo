using System.Data.Entity.Migrations;
using LeoTodo.Dominio.Entidade;
using LeoTodo.Dominio.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoTodo.Dominio.Repositorio
{
    public class TarefaRepositorio
    {
        private TaskContext contexto = new TaskContext();

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

        public Tarefa InsereTarefa(Tarefa tarefa)
        {
            contexto.Tarefas.Add(tarefa);
            contexto.SaveChanges();

            return tarefa;
        }

        public void AlteraTarefa(Tarefa tarefa)
        {
            contexto.Set<Tarefa>().AddOrUpdate(tarefa);
            contexto.SaveChanges();
        }

        public void DeletaTarefa(Tarefa tarefa)
        {
            contexto.Entry(tarefa).State = EntityState.Deleted;
            contexto.SaveChanges();
        }
    }
}
