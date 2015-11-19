using System;
using System.ComponentModel.DataAnnotations;
using LeoTodo.Dominio.Entidades;

namespace LeoTodo.Web.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Identificador { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Senha { get; set; }
        public string GuidUsuarioAtivo { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public Usuario ToEntidade()
        {
            return new Usuario
            {
                Id = this.Id,
                Identificador = this.Identificador,
                Nome = this.Nome,
                Email = this.Email,
                Senha = this.Senha,
                GuidUsuarioAtivo = this.GuidUsuarioAtivo,
                DataInclusao = this.DataInclusao,
                DataAlteracao = this.DataAlteracao
            };
        }
    }
}