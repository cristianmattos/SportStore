using LojaEsporte.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaEsporte.MetodoProduto;


namespace LojaEsporte.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastroProduto(int id)
        {
            ViewData["cod"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult CadastroProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var metodosProduto = new ProdutoDAO();
                metodosProduto.Insert(produto);
                return RedirectToAction("ListaProduto");

            }

            return View(produto);
        }

        public ActionResult Resultado(Produto produto)
        {
            return View(produto);
        }

        public ActionResult BuscarProduto()
        {
            var metodosProduto = new ProdutoDAO();
            var produto = metodosProduto.BuscaProduto();
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        [HttpPost]
        public ActionResult BuscarProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var metodosProduto = new ProdutoDAO();
                metodosProduto.SalvarProduto(produto);
                return RedirectToAction("ListaProduto");
            }
            return View(produto);
        }

        public ActionResult ListaProduto()
        {
            var metodosProduto = new ProdutoDAO();
            var TodosProdutos = metodosProduto.Listar();
            return View(TodosProdutos);

        }

        public ActionResult Editar (int ID)
        {
            var metodosProduto = new ProdutoDAO();
            var produto = metodosProduto.ListarId(ID);

            if(produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        [HttpPost]
        public ActionResult Editar(Produto produto)
        {
            if(ModelState.IsValid)
            {
                var metodosProduto = new ProdutoDAO();
                metodosProduto.Salvar(produto);
                return RedirectToAction("ListaProduto");
            }
            return View(produto);
        }

        public ActionResult Detalhes (int ID)
        {
            var metodosProduto = new ProdutoDAO();
            var produto = metodosProduto.ListarId(ID);

            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        public ActionResult Excluir (int ID)
        {
            var metodosProduto = new ProdutoDAO();
            var produto = metodosProduto.ListarId(ID);

            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        [HttpPost, ActionName ("Excluir")]
        public ActionResult ExcluirConfirma (int ID)
        {
            var metodosProduto = new ProdutoDAO();
            metodosProduto.Excluir(ID);
            return RedirectToAction("ListaProduto");
        }
    }
}