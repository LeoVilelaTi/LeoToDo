using System.ComponentModel.DataAnnotations;

namespace LeoTodo.Web.Models
{
    public class LoginModel
    {
        [Required]
        public string Identificador { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}