using LeoTodo.Dominio.Entidades;

namespace LeoTodo.Dominio.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        void AutorizarUsuarioEfetuarLogin(Usuario usuario);

        Usuario ConsultarUsuarioAtivoPorIdentificador(string identificacao);
        Usuario ConsultarUsuarioPorIdentificador(string identificador);
        Usuario ConsultarUsuarioPorEmail(string email);
    }
}
