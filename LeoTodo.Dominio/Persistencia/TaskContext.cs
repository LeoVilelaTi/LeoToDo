using LeoTodo.Dominio.Entidade;
using System.Data.Entity;

namespace LeoTodo.Dominio.Persistencia
{
    public class TaskContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
