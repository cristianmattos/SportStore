using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaEsporte.Models;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using LojaEsporte.Metodos;

namespace LojaEsporte.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginFuncionario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginFuncionario(Funcionario funcionario)
        {
            var metodosFuncionario = new FuncionarioDAO();
            metodosFuncionario.VerificaUsuario(funcionario);

            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);

            //var db = new Banco();

            //var strQuery = string.Format("SELECT * FROM tbl_Funcionario where email_Login = '{0}' and senha_Login='{1}';", funcionario.Email, funcionario.Senha);

            //db.RetornaComando(strQuery);

            //var retorno = db.RetornaComando(strQuery);

            //if (retorno.Read())
            //{

            //}
            //else
            //{

            //}
            //return View(funcionario);
        }

        public ActionResult CadastroFuncionario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroFuncionario(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var metodosFuncionario = new FuncionarioDAO();
                metodosFuncionario.Insert(funcionario);
                return RedirectToAction("ListaFuncionario");
            }

            return View(funcionario);
        }

        public ActionResult Resultado(Funcionario funcionario)
        {
            return View(funcionario);
        }

        public ActionResult BuscarFuncionario()
        {
            var metodosFuncionario = new FuncionarioDAO();
            var funcionario = metodosFuncionario.BuscaFuncionario();
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult BuscarFuncionario(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var metodosFuncionario = new FuncionarioDAO();
                metodosFuncionario.SalvarFuncionario(funcionario);
                return RedirectToAction("ListaProduto");
            }
            return View(funcionario);
        }

        public ActionResult ListaFuncionario()
        {
            var metodosFuncionario = new FuncionarioDAO();
            var TodosFuncionarios = metodosFuncionario.Listar();
            return View(TodosFuncionarios);

        }

        public ActionResult Editar(int ID)
        {
            var metodosFuncionario = new FuncionarioDAO();
            var funcionario = metodosFuncionario.ListarId(ID);

            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult Editar(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var metodosFuncionario = new FuncionarioDAO();
                metodosFuncionario.Salvar(funcionario);
                return RedirectToAction("ListaFuncionario");
            }
            return View(funcionario);
        }

        public ActionResult Detalhes(int ID)
        {
            var metodosFuncionario = new FuncionarioDAO();
            var funcionario = metodosFuncionario.ListarId(ID);

            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        public ActionResult Excluir(int ID)
        {
            var metodosFuncionario = new FuncionarioDAO();
            var funcionario = metodosFuncionario.ListarId(ID);

            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirma(int ID)
        {
            var metodosFuncionario = new FuncionarioDAO();
            metodosFuncionario.Excluir(ID);
            return RedirectToAction("ListaFuncionario");
        }
    }
}