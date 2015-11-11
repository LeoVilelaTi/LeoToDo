using LeoTodo.Dominio.Entidades;
using LeoTodo.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeoTodo.Dominio.Servicos
{
    public class UsuarioDominioServico
    {
        UsuarioRepositorioLeitura repositorioLeitura = new UsuarioRepositorioLeitura();
        UsuarioRepositorioEscrita repositorioEscrita = new UsuarioRepositorioEscrita();


        public Usuario ConsultarPorId(int id)
        {
            var retorno = repositorioLeitura.ConsultarPorId(id);

            return retorno;
        }

        public IEnumerable<Usuario> ConsultarTodas()
        {
            var retorno = repositorioLeitura.ConsultarTodas();

            return retorno;
        }

        public Usuario ConsultarPorIdentificador(string identificador)
        {
            var usuario = repositorioLeitura.ConsultarUsuarioPorIdentificador(identificador);

            return usuario;
        }

        public Usuario Incluir(Usuario usuario)
        {
            GerarGuidParaUsuario(usuario);
            CriptografaSenha(usuario);

            var usuarioNova = repositorioEscrita.Inserir(usuario);

            EnviaEmailParaValidarNovoUsuario(usuario);

            return usuarioNova;
        }

        public void Alterar(Usuario usuario)
        {
            repositorioEscrita.Alterar(usuario);
        }

        public void Deletar(int id)
        {
            var usuarioBanco = repositorioLeitura.ConsultarPorId(id);
            repositorioEscrita.Deletar(usuarioBanco);
        }

        public bool Autenticar(string identificador, string senha)
        {
            bool retorno = false;

            var usuario = repositorioLeitura.ConsultarUsuarioAtivoPorIdentificador(identificador);

            if (usuario != null)
            {
                retorno = SenhaCorreta(usuario.Senha, senha);
            }

            return retorno;
        }

        public bool UsuarioAtivado(string identificador, string guid)
        {
            var usuario = repositorioLeitura.ConsultarUsuarioPorIdentificador(identificador);

            if (usuario.GuidUsuarioAtivo.Trim() == guid.Trim())
            {
                repositorioEscrita.AutorizarUsuarioEfetuarLogin(usuario);
                return true;
            }

            return false;
        }


        public void EnviaEmailParaRecuperacaoSenha(string email)
        {
            var usuario = repositorioLeitura.ConsultarUsuarioPorEmail(email);
            GerarGuidParaUsuario(usuario);
            repositorioEscrita.Alterar(usuario);

            EnviaEmailParaRecuperarSenha(usuario);
        }

        public void ResetSenha(Usuario usuario)
        {
            var usuarioAtual = repositorioLeitura.ConsultarUsuarioPorIdentificador(usuario.Identificador);

            CriptografaSenha(usuario);

            repositorioEscrita.Alterar(usuario);
        }

        private bool SenhaCorreta(string senhaBanco, string senhaDigitada)
        {
            var senhaDigitadaCriptografada = GerarHashSha1ComSalt(senhaDigitada.Trim());

            if (senhaBanco.Trim() == senhaDigitadaCriptografada)
            {
                return true;
            }

            return false;
        }

        private void CriptografaSenha(Usuario usuario)
        {
            usuario.Senha = GerarHashSha1ComSalt(usuario.Senha);
        }

        private string GerarHashSha1ComSalt(string senha)
        {
            String salt = @"984(743HFjyt25OtrDH5A32HdsNBA~_FFXDF=+0425/-*'";

            senha = senha.Trim();

            SHA512Managed HashTool = new SHA512Managed();
            Byte[] PhraseAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(senha + salt));
            Byte[] EncryptedBytes = HashTool.ComputeHash(PhraseAsByte);
            HashTool.Clear();
            return Convert.ToBase64String(EncryptedBytes);
        }

        private void EnviaEmailParaValidarNovoUsuario(Usuario usuario)
        {
            string destinatario = usuario.Email.Trim();
            string assunto = "Ative sua conta para começar a acessar o sistema To Do.";
            string mensagem = string.Format("Acesse o link: {0}/{1}/{2}?identificador={3}&guid={4}", "http://localhost:9597", "Usuario", "PrimeiroAcesso", usuario.Identificador.Trim(), usuario.GuidUsuarioAtivo.Trim());

            Email.EnviarEmail(destinatario, assunto, mensagem);
        }

        private void EnviaEmailParaRecuperarSenha(Usuario usuario)
        {
            string destinatario = usuario.Email.Trim();
            string assunto = "Redefina sua senha para voltar a utilizar nosso sistema To Do.";
            string mensagem = string.Format("Acesse o link: {0}/{1}/{2}?identificador={3}&guid={4}", "http://localhost:9597", "Usuario", "RedefinirSenha", usuario.Identificador.Trim(), usuario.GuidUsuarioAtivo.Trim());

            Email.EnviarEmail(destinatario, assunto, mensagem);
        }

        private void GerarGuidParaUsuario(Usuario usuario)
        {
            var guid = Guid.NewGuid();
            usuario.GuidUsuarioAtivo = guid.ToString();
        }
    }
}
