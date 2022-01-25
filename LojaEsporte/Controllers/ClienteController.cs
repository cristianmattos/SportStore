using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaEsporte.Models;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using System.Data;
using LojaEsporte.MetodoCliente;

namespace LojaEsporte.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CadastroCliente()
        {
            return View();
        }

        public ActionResult devmind()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var metodosCliente = new ClienteDAO();
                metodosCliente.Insert(cliente);
                return RedirectToAction("ListaCliente");
            }

            return View(cliente);
        }

        public ActionResult Resultado(Cliente cliente)
        {
            return View(cliente);
        }

        public ActionResult ListaCliente()
        {
            var metodosCliente = new ClienteDAO();
            var TodosClientes = metodosCliente.Listar();
            return View(TodosClientes);

        }

        public ActionResult Editar(int ID)
        {
            var metodosCliente = new ClienteDAO();
            var cliente = metodosCliente.ListarId(ID);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var metodosCliente = new ClienteDAO();
                metodosCliente.Salvar(cliente);
                return RedirectToAction("ListaCliente");
            }
            return View(cliente);
        }

        public ActionResult Detalhes(int ID)
        {
            var metodosCliente = new ClienteDAO();
            var cliente = metodosCliente.ListarId(ID);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        public ActionResult Excluir(int ID)
        {
            var metodosCliente = new ClienteDAO();
            var cliente = metodosCliente.ListarId(ID);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirma(int ID)
        {
            var metodosCliente = new ClienteDAO();
            metodosCliente.Excluir(ID);
            return RedirectToAction("ListaCliente");
        }
    }
}