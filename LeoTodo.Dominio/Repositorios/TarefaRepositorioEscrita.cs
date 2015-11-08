using LeoTodo.Dominio.Entidades;
using LeoTodo.Dominio.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using LeoTodo.Dominio.Repositorios.Interfaces;

namespace LeoTodo.Dominio.Repositorios
{
    public class TarefaRepositorioEscrita : ITarefaRepositorioEscrita, ITarefaRepositorioLeituraEscrita
    {
        private TaskContext contexto = new TaskContext();

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
    }
}
