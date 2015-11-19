
namespace LeoTodo.Dominio.Repositorios.Interfaces
{
    public interface IEscritaRepositorio<T> where T : class
    {
        T Inserir(T item);
        void Alterar(T item);
        void Deletar(T item);
    }
}
