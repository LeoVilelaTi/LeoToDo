using LeoTodo.Dominio.Entidades;
using LeoTodo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeoTodo.Web.Fabrica
{
    public static class TarefaFabrica
    {
        public static TarefaModel Criar(Tarefa tarefa) {

            return new TarefaModel()
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Concluido = tarefa.Concluido,
                DataInclusao = tarefa.DataInclusao,
                DataAlteracao = tarefa.DataAlteracao
            };
        }
    }
}