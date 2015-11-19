using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LeoTodo.Dominio.Persistencia;
using LeoTodo.Dominio.Repositorios.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace LeoTodo.Dominio.Repositorios
{
    public class RepositorioGenerico<T> : ILeituraEscritaRepositorio<T> where T : class
    {
        private TodoContexto contexto = new TodoContexto();

        public T Inserir(T item)
        {
            contexto.Set<T>().Add(item);
            contexto.SaveChanges();

            return item;
        }

        public void Alterar(T item)
        {
            contexto.Set<T>().AddOrUpdate(item);
            contexto.SaveChanges();
        }

        public void Deletar(T item)
        {
            contexto.Entry(item).State = EntityState.Deleted;
            contexto.SaveChanges();
        }

        public T ConsultarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ConsultarTodas()
        {
            return contexto.Set<T>().Where(x=> true).ToList();
        }

        public IEnumerable<T> Consultar(Expression<Func<T, bool>> predicate)
        {
            return contexto.Set<T>().Where(predicate).ToList();
        }
    }
}
