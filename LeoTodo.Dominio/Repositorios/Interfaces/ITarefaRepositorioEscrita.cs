using LeoTodo.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoTodo.Dominio.Repositorios.Interfaces
{
    public interface ITarefaRepositorioEscrita
    {
        Tarefa Inserir(Tarefa tarefa);
        void Alterar(Tarefa tarefa);
        void Deletar(Tarefa tarefa);
    }
}
