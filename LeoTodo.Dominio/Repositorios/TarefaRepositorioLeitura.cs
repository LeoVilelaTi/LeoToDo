using System.Data.Entity.Migrations;
using LeoTodo.Dominio.Entidade;
using LeoTodo.Dominio.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeoTodo.Dominio.Repositorios.Interfaces;

namespace LeoTodo.Dominio.Repositorios
{
    public class TarefaRepositorioLeitura : ITarefaRepositorioLeitura, ITarefaRepositorioLeituraEscrita
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
    }
}
