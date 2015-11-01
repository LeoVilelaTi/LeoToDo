using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoTodo.Dominio.Entidade
{
    public abstract class BaseEntidade
    {
        public StringCollection Erros { get; private set; }

        public BaseEntidade()
        {
            this.Erros = new StringCollection();
        }

        public bool EstaValido
        {
            get
            {
                return this.Erros.Count == 0;
            }
        }

        public void AdicionarErro(string mensagem)
        {
            this.Erros.Add(mensagem);
        }

        //public virtual bool Validar()
        //{

        //}
    }
}
