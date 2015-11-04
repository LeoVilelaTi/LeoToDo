using LeoTodo.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeoTodo.Web.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Concluido { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public Tarefa ToEntidade()
        {
            return new Tarefa
            {
                Id = this.Id,
                Titulo = this.Titulo,
                Concluido = this.Concluido,
                DataInclusao = this.DataInclusao,
                DataAlteracao = this.DataAlteracao
            };
        }
    }
}