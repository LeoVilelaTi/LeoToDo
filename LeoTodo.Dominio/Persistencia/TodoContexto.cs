using System.Data.Entity;
using LeoTodo.Dominio.Entidades;
using LeoTodo.Dominio.Persistencia.Mapping;

namespace LeoTodo.Dominio.Persistencia
{
    public class TodoContexto : DbContext
    {
        public TodoContexto()
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
