using LeoTodo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoTodo.Dominio.Repositorios.Interfaces
{
    public interface IUsuarioRepositorioEscrita
    {
        Usuario Inserir(Usuario usuario);
        void Alterar(Usuario usuario);
        void Deletar(Usuario usuario);
    }
}
