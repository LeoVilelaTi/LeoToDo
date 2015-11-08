using LeoTodo.Dominio.Entidades;
using LeoTodo.Dominio.Persistencia;
using LeoTodo.Dominio.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoTodo.Dominio.Repositorios
{
    public class UsuarioRepositorioLeitura : IUsuarioRepositorioLeitura, IUsuarioRepositorioLeituraEscrita
    {
        private TaskContext contexto = new TaskContext();

        public Usuario ConsultarPorId(int id)
        {
            var usuarios = contexto.Usuarios;

            return usuarios.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Usuario> ConsultarTodas()
        {
            var usuarios = contexto.Usuarios;

            return usuarios.ToList();
        }

        public Usuario ConsultarUsuarioPorIdentificador(string identificador)
        {
            var usuarios = contexto.Usuarios;

            var usuario = usuarios.FirstOrDefault(x => identificador.Trim().ToLower().Equals(x.Identificador.Trim().ToLower()));

            return usuario;
        }

        public Usuario ConsultarUsuarioAtivoPorIdentificador(string identificador)
        {
            var usuarios = contexto.Usuarios;

            var usuario = usuarios.FirstOrDefault(x => identificador.Trim().ToLower().Equals(x.Identificador.Trim().ToLower()) && x.GuidUsuarioAtivo == null);

            return usuario;
        }
    }
}
