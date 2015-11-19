using System;

namespace LeoTodo.Dominio.Entidades
{
    public class Tarefa : BaseEntidade
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Concluido { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.Titulo))
            {
                return false;
            }
            else if (this.DataInclusao == null)
            {
                return false;
            }

            return true; 
        }
    }
}
