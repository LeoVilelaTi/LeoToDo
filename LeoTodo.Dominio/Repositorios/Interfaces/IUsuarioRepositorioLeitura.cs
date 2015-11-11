using LeoTodo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoTodo.Dominio.Repositorios.Interfaces
{
    public interface IUsuarioRepositorioLeitura
    {
        Usuario ConsultarPorId(int id);
        IEnumerable<Usuario> ConsultarTodas();
        Usuario ConsultarUsuarioAtivoPorIdentificador(string identificacao);
        Usuario ConsultarUsuarioPorIdentificador(string identificador);
        Usuario ConsultarUsuarioPorEmail(string email);
    }
}
