using LeoTodo.Dominio.Entidades;
using LeoTodo.Dominio.Persistencia.Mapping;
using System.Data.Entity;

namespace LeoTodo.Dominio.Persistencia
{
    public class TaskContext : DbContext
    {
        public TaskContext()
            : base("Conexao_Com_Db_Local")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TarefaMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }
    }
}
