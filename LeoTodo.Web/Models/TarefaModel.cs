using LeoTodo.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace LeoTodo.Web.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int IdUsuario {get;set;}
        public bool Concluido { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public List<TarefaModel> TarefasConsultadas { get; set; }

        public Tarefa ToEntidade()
        {
            return new Tarefa
            {
                Id = this.Id,
                Titulo = this.Titulo,
                IdUsuario = this.IdUsuario,
                Concluido = this.Concluido,
                DataInclusao = this.DataInclusao,
                DataAlteracao = this.DataAlteracao
            };
        }
    }
}