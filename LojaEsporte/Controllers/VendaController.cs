using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaEsporte.Models;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using System.Data;
using LojaEsporte.Metodos;

namespace LojaEsporte.Controllers
{
    public class VendaController : Controller
    {
        // GET: Venda
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastroVenda(/*int id,*/ int idProduto, int idFornecedor, string idNome, decimal idPreço)
        {
            //ViewData["idFunc"] = id;
            ViewData["idProduto"] = idProduto;
            ViewData["idFornecedor"] = idFornecedor;
            ViewData["idNome"] = idNome;
            ViewData["idPreço"] = idPreço;
            return View();
        }

        [HttpPost]
        public ActionResult CadastroVenda(Venda venda)
        {
            if (ModelState.IsValid)
            {
                var metodosVenda = new VendaDAO();
                metodosVenda.Insert(venda);
                return RedirectToAction("ListaVenda");
            }

            return View(venda);
        }

        public ActionResult Resultado(Venda venda)
        {
            return View(venda);
        }

        public ActionResult ListaVenda()
        {
            var metodosVenda = new VendaDAO();
            var TodosVendas = metodosVenda.Listar();
            return View(TodosVendas);

        }

        public ActionResult Editar(int ID)
        {
            var metodosVenda = new VendaDAO();
            var venda = metodosVenda.ListarId(ID);

            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        [HttpPost]
        public ActionResult Editar(Venda venda)
        {
            if (ModelState.IsValid)
            {
                var metodosVenda = new VendaDAO();
                metodosVenda.Salvar(venda);
                return RedirectToAction("ListaVenda");
            }
            return View(venda);
        }

        public ActionResult Detalhes(int ID)
        {
            var metodosVenda = new VendaDAO();
            var venda = metodosVenda.ListarId(ID);

            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        public ActionResult Excluir(int ID)
        {
            var metodosVenda = new VendaDAO();
            var venda = metodosVenda.ListarId(ID);

            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirma(int ID)
        {
            var metodosVenda = new VendaDAO();
            metodosVenda.Excluir(ID);
            return RedirectToAction("ListaVenda");
        }
    }
}