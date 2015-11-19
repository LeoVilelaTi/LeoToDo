using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LeoTodo.Dominio.Repositorios.Interfaces
{
    public interface ILeituraRepositorio<T> where T : class
    {
        T ConsultarPorId(int id);
        IEnumerable<T> ConsultarTodas();
        IEnumerable<T> Consultar(Expression<Func<T, bool>> predicate);
    }
}