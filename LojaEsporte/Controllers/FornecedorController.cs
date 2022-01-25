using LojaEsporte.Metodos;
using LojaEsporte.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaEsporte.Controllers
{
    public class FornecedorController : Controller
    {
        // GET: Fornecedor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastroFornecedor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroFornecedor(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                var metodosFornecedor = new FornecedorDAO();
                metodosFornecedor.Insert(fornecedor);
                return RedirectToAction("ListaFornecedor");
            }

            return View(fornecedor);
        }

        public ActionResult Resultado(Fornecedor fornecedor)
        {
            return View(fornecedor);
        }

        public ActionResult BuscarFornecedor()
        {
            var metodosFornecedor = new FornecedorDAO();
            var fornecedor = metodosFornecedor.BuscaFornecedor();
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        [HttpPost]
        public ActionResult BuscarFornecedor(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                var metodosProduto = new FornecedorDAO();
                metodosProduto.SalvarFornecedor(fornecedor);
                return RedirectToAction("ListaProduto");
            }
            return View(fornecedor);
        }

        public ActionResult ListaFornecedor()
        {
            var metodosFornecedor = new FornecedorDAO();
            var TodosFornecedor = metodosFornecedor.Listar();
            return View(TodosFornecedor);
        }

        public ActionResult Editar(int ID)
        {
            var metodosFornecedor = new FornecedorDAO();
            var fornecedor = metodosFornecedor.ListarId(ID);

            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        [HttpPost]
        public ActionResult Editar(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                var metodosFornecedor = new FornecedorDAO();
                metodosFornecedor.Salvar(fornecedor);
                return RedirectToAction("ListaFornecedor");
            }
            return View(fornecedor);
        }

        public ActionResult Detalhes(int ID)
        {
            var metodosFornecedor = new FornecedorDAO();
            var fornecedor = metodosFornecedor.ListarId(ID);

            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        public ActionResult Excluir(int ID)
        {
            var metodosFornecedor = new FornecedorDAO();
            var fornecedor = metodosFornecedor.ListarId(ID);

            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirma(int ID)
        {
            var metodosFornecedor = new FornecedorDAO();
            metodosFornecedor.Excluir(ID);
            return RedirectToAction("ListaFornecedor");
        }

    }
}