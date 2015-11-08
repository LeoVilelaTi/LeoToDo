using LeoTodo.Dominio.Entidades;
using LeoTodo.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeoTodo.Web.Proxy
{
    public class UsuarioProxy
    {
        UsuarioDominioServico usuarioDomainService = new UsuarioDominioServico();

        public Usuario ConsultarPorId(int id)
        {
            var usuarioBanco = usuarioDomainService.ConsultarPorId(id);

            return usuarioBanco;
        }

        public IEnumerable<Usuario> ConsultarTodas()
        {
            var listausuariosRetorno = usuarioDomainService.ConsultarTodas();

            return listausuariosRetorno;
        }

        public Usuario Incluir(Usuario usuario)
        {
            var usuarioNova = usuarioDomainService.Incluir(usuario);

            return usuarioNova;
        }

        public void Alterar(Usuario usuario)
        {
            usuarioDomainService.Alterar(usuario);
        }

        public void Deletar(int id)
        {
            usuarioDomainService.Deletar(id);
        }
    }
}