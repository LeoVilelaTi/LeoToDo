using LeoTodo.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoTodo.Dominio.Repositorios.Interfaces
{
    public interface ITarefaRepositorioLeitura
    {
        Tarefa ConsultarPorId(int id);
        IEnumerable<Tarefa> ConsultarTodas();
    }
}
