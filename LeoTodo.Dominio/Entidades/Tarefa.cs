using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoTodo.Dominio.Entidade
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool StatusDone { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
