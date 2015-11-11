using LeoTodo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoTodo.Dominio.Persistencia.Mapping
{
    public class TarefaMap : EntityTypeConfiguration<Tarefa>
    {
        public TarefaMap()
        {
            //Primay Key
            HasKey(t => t.Id);

            ToTable("Tarefas");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Titulo).HasColumnName("Titulo");
            Property(t => t.IdUsuario).HasColumnName("IdUsuario");
            Property(t => t.Concluido).HasColumnName("Concluido");
            Property(t => t.DataInclusao).HasColumnName("DataInclusao");
            Property(t => t.DataAlteracao).HasColumnName("DataAlteracao");
        }
    }
}
