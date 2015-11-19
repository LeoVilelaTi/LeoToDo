using LeoTodo.Dominio.Entidades;
using LeoTodo.Web.Models;

namespace LeoTodo.Web.Fabrica
{
    public static class UsuarioFabrica
    {
        public static UsuarioModel Criar(Usuario usuario) {

            return new UsuarioModel()
            {
                Id = usuario.Id,
                Identificador = usuario.Identificador,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                DataInclusao = usuario.DataInclusao,
                DataAlteracao = usuario.DataAlteracao
            };
        }
    }
}