using LeoTodo.Dominio.Entidades;
using LeoTodo.Dominio.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using LeoTodo.Dominio.Repositorios.Interfaces;


namespace LeoTodo.Dominio.Repositorios
{
    public class UsuarioRepositorioEscrita : IUsuarioRepositorioEscrita, IUsuarioRepositorioLeituraEscrita
    {
        private TaskContext contexto = new TaskContext();

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
    }
}
