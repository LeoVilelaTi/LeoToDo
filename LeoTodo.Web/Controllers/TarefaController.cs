using LeoTodo.Dominio.Entidades;
using LeoTodo.Web.Fabrica;
using LeoTodo.Web.Models;
using LeoTodo.Web.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeoTodo.Web.Controllers
{
    public class TarefaController : Controller
    {
        public ActionResult Index()
        {
            listaTarefas();
            return View();
        }

        /// <summary>
        /// Insere uma nova tarefa
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post(TarefaModel tarefa)
        {
            TarefaProxy proxy = new TarefaProxy();

            tarefa.IdUsuario = ((Usuario)Session["UsuarioLogado"]).Id;
            proxy.Incluir(tarefa.ToEntidade());
            
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Consulta todas tarefas
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get(TarefaModel tarefa)
        {
            return View("Index");
        }

        /// <summary>
        /// Edita uma tarefa
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Put(TarefaModel tarefa) 
        {
            TarefaProxy proxy = new TarefaProxy();

            var tarefaAtual = proxy.ConsultarPorId(tarefa.Id);

            tarefaAtual.Titulo = tarefa.Titulo.Trim();
            tarefaAtual.Concluido = tarefa.Concluido;
            tarefaAtual.DataAlteracao = DateTime.Now;

            proxy.Alterar(tarefaAtual);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Delete uma tarefa
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            TarefaProxy proxy = new TarefaProxy();
            proxy.Deletar(id);

            return RedirectToAction("Index");
        }

        private void listaTarefas()
        {
            TarefaProxy proxy = new TarefaProxy();

            var usuario = Session["UsuarioLogado"];

            var listaTarefas = proxy.ConsultarPorUsuario(((Usuario)usuario).Id).ToList();

            var listaTarefasModel = listaTarefas.Select(TarefaFabrica.Criar).ToList();

            ViewBag.ListaTarefas = listaTarefasModel;
        }
    }
}