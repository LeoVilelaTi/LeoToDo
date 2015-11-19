using LeoTodo.Dominio.Entidades;

namespace LeoTodo.Dominio.InfraEstrutura.Servicos.Interfaces
{
    public interface INotificacao
    {
        void EnviaEmailParaValidarNovoUsuario(Usuario usuario);
        void EnviaEmailComLinkAlteracaoDeSenha(Usuario usuario);
    }
}
