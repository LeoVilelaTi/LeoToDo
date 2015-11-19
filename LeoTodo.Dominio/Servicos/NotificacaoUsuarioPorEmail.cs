using LeoTodo.Dominio.InfraEstrutura;
using LeoTodo.Dominio.InfraEstrutura.Servicos.Interfaces;

namespace LeoTodo.Dominio.Servicos
{
    public class NotificacaoUsuarioPorEmail : INotificacao
    {
        public void EnviaEmailParaValidarNovoUsuario(Entidades.Usuario usuario)
        {
            string destinatario = usuario.Email.Trim();
            string assunto = "Ative sua conta para começar a acessar o sistema To Do.";
            string mensagem = string.Format("Acesse o link: {0}/{1}/{2}?identificador={3}&guid={4}", "http://localhost:9597", "Usuario", "PrimeiroAcesso", usuario.Identificador.Trim(), usuario.GuidUsuarioAtivo.Trim());

            Email.EnviarEmail(destinatario, assunto, mensagem);
        }

        public void EnviaEmailComLinkAlteracaoDeSenha(Entidades.Usuario usuario)
        {
            string destinatario = usuario.Email.Trim();
            string assunto = "Redefina sua senha para voltar a utilizar nosso sistema To Do.";
            string mensagem = string.Format("Acesse o link: {0}/{1}/{2}?identificador={3}&guid={4}", "http://localhost:9597", "Usuario", "RedefinirSenha", usuario.Identificador.Trim(), usuario.GuidUsuarioAtivo.Trim());

            Email.EnviarEmail(destinatario, assunto, mensagem);
        }
    }
}
