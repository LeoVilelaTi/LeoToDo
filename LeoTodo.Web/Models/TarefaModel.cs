using LeoTodo.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeoTodo.Web.Models
{
    public class TarefaModel
    {
        private int Id { get; set; }
        private string title { get; set; }

        public Tarefa ToEntidade()
        {
            return new Tarefa
            {
                Id = this.Id,
            };
        }
    }
}