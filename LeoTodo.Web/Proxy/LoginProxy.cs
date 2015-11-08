using LeoTodo.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeoTodo.Web.Proxy
{
    public class LoginProxy
    {
        UsuarioDominioServico usuarioDominio = new UsuarioDominioServico();

        public bool Autenticacao(string identificador, string senha)
        {
            var retorno = usuarioDominio.Autenticar(identificador, senha);
            return retorno;
        }

        public bool UsuarioAtivado(string identificador, string guid)
        {
            var retorno = usuarioDominio.UsuarioAtivado(identificador, guid);
            return retorno;
        }
    }
}