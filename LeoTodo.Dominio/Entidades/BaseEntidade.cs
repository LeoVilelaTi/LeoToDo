using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeoTodo.Dominio.Entidades
{
    public abstract class BaseEntidade
    {
        [NotMapped]
        public StringCollection Erros { get; private set; }


        public BaseEntidade()
        {
            this.Erros = new StringCollection();
        }

        public void AdicionarErro(string mensagem)
        {
            this.Erros.Add(mensagem);
        }

        [NotMapped]
        public bool EstaValido
        {
            get
            {
                return this.Erros.Count == 0;
            }
        }

        public virtual bool Validar()
        {
            return new bool();
        }
    }
}
