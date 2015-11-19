using System;
using LeoTodo.Dominio.Entidades;
using LeoTodo.Dominio.Repositorios;
using LeoTodo.Dominio.Repositorios.Interfaces;

namespace LeoTodo.Dominio.Servicos
{
    public class UsuarioDominioServico
    {
        public Usuario Incluir(Usuario usuario)
        {
            var RepositorioUsuario = new UsuarioRepositorio();

            usuario.DataInclusao = DateTime.Now;
            usuario.GerarGuidParaUsuario();
            usuario.CriptografarSenha();

            var usuarioNova = RepositorioUsuario.Inserir(usuario);

            var notificacao = new NotificacaoUsuarioPorEmail();
            notificacao.EnviaEmailParaValidarNovoUsuario(usuario);

            return usuarioNova;
        }

        public void Alterar(Usuario usuario)
        {
            var RepositorioUsuario = new UsuarioRepositorio();

            RepositorioUsuario.Alterar(usuario);
        }

        public void Deletar(int id)
        {
            var RepositorioUsuario = new UsuarioRepositorio();

            var usuarioBanco = RepositorioUsuario.ConsultarPorId(id);
            RepositorioUsuario.Deletar(usuarioBanco);
        }


        public bool Autenticar(string identificador, string senhaDigitada)
        {
            var RepositorioUsuario = new UsuarioRepositorio();

            var retorno = false;

            var usuarioBanco = RepositorioUsuario.ConsultarUsuarioAtivoPorIdentificador(identificador);

            if (usuarioBanco != null)
            {
                retorno = usuarioBanco.SenhaEhCorreta(senhaDigitada);
            }

            return retorno;
        }

        public bool UsuarioAtivado(string identificador, string guid)
        {
            var RepositorioUsuario = new UsuarioRepositorio();

            var usuario = RepositorioUsuario.ConsultarUsuarioPorIdentificador(identificador);

            if (usuario.GuidUsuarioAtivo.Trim() == guid.Trim())
            {
                RepositorioUsuario.AutorizarUsuarioEfetuarLogin(usuario);
                return true;
            }

            return false;
        }

        public void EnviarEmailAlteracaoDeSenha(string email)
        {
            var RepositorioUsuario = new UsuarioRepositorio();

            var usuario = RepositorioUsuario.ConsultarUsuarioPorEmail(email);

            usuario.GerarGuidParaUsuario();

            RepositorioUsuario.Alterar(usuario);

            var notificacao = new NotificacaoUsuarioPorEmail();
            notificacao.EnviaEmailComLinkAlteracaoDeSenha(usuario);
        }

        public void ResetSenha(Usuario usuario)
        {
            var RepositorioUsuario = new UsuarioRepositorio();

            var usuarioAtual = RepositorioUsuario.ConsultarUsuarioPorIdentificador(usuario.Identificador);

            usuarioAtual.Senha = usuario.Senha;
            usuarioAtual.DataAlteracao = DateTime.Now;

            usuarioAtual.CriptografarSenha();

            RepositorioUsuario.Alterar(usuarioAtual);
        }
    }
}
