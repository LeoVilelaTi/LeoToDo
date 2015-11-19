using System;
using LeoTodo.Dominio.InfraEstrutura;

namespace LeoTodo.Dominio.Entidades
{
    public class Usuario :  BaseEntidade
    {
        public int Id { get; set; }
        public string Identificador { get; set; }
        public string Nome { get; set; }
        public string Email {get;set;}
        public string Senha { get; set; }
        public string GuidUsuarioAtivo { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public void CriptografarSenha()
        {
            this.Senha = Criptografia.CriptografaSenha(this.Senha);
        }

        public bool SenhaEhCorreta(string senhaDigitada)
        {
            var senhaDigitadaCriptografada = Criptografia.CriptografaSenha(senhaDigitada);

            if (Senha.Trim() == senhaDigitadaCriptografada)
            {
                return true;
            }

            return false;
        }

        public void GerarGuidParaUsuario()
        {
            var guid = Guid.NewGuid();
            this.GuidUsuarioAtivo = guid.ToString();
        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.Identificador))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(this.Nome))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(Email))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(Senha))
            {
                return false;
            }
            else if (DataInclusao == null)
            {
                return false;
            }

            return true;
        }
    }
}
