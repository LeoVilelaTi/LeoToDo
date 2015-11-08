using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
