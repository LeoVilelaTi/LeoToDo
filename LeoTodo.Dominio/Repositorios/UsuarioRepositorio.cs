using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using LeoTodo.Dominio.Entidades;
using LeoTodo.Dominio.Persistencia;
using LeoTodo.Dominio.Repositorios.Interfaces;
using System.Linq;
using System.Collections.Generic;


namespace LeoTodo.Dominio.Repositorios
{
    public class UsuarioRepositorio : IEscritaRepositorio<Usuario>, IUsuarioRepositorio
    {
        private TodoContexto contexto = new TodoContexto();

        public Usuario Inserir(Usuario usuario)
        {
 
            usuario.DataInclusao = DateTime.Now;

            contexto.Usuarios.Add(usuario);
            contexto.SaveChanges();

            return usuario;
        }

        public void Alterar(Usuario usuario)
        {
            contexto.Set<Usuario>().AddOrUpdate(usuario);
            contexto.SaveChanges();
        }

        public void Deletar(Usuario usuario)
        {
            contexto.Entry(usuario).State = EntityState.Deleted;
            contexto.SaveChanges();
        }

        public void AutorizarUsuarioEfetuarLogin(Usuario usuario)
        {
            //Identifica se o usuário ja acessou seu email para garantir sua autenticidade
            usuario.GuidUsuarioAtivo = null;

            contexto.Set<Usuario>().AddOrUpdate(usuario);
            contexto.SaveChanges();
        }

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

        public Usuario ConsultarUsuarioPorEmail(string email)
        {
            var usuarios = contexto.Usuarios;

            var usuario = usuarios.FirstOrDefault(x => email.Trim().ToLower().Equals(x.Email));

            return usuario;
        }
    }
}
