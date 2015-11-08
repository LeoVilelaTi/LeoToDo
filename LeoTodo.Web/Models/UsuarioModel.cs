using LeoTodo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeoTodo.Web.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Identificador { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
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