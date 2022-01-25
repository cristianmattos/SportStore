using LojaEsporte.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LojaEsporte.Metodos
{
    public class FuncionarioDAO
    {


        private Banco db;

        public void Insert(Funcionario funcionario)
        {
            string strInserir = "";
            strInserir += "insert into tbl_Funcionario values(null, ";  /*strquery += "insert into tbl_Produto values(null,";*/ //strquery += "2,2);";
            //strInserir += string.Format("('{0}', ", funcionario.ID);
            strInserir += string.Format("'{0}', ", funcionario.Nome);
            strInserir += string.Format("'{0}',", funcionario.CPF);
            strInserir += string.Format("'{0}',", funcionario.Email);
            strInserir += string.Format("'{0}',", funcionario.Senha);
            strInserir += string.Format("'{0}' );", funcionario.ConfirmaSenha);

            using (db = new Banco())
            {
                db.ExecutaComando(strInserir);
            }
        }

        public void Atualizar(Funcionario funcionario)
        {
            var strquery = "";
            strquery += "update tbl_Funcionario set";
            strquery += string.Format(" nome_Func = '{0}', ", funcionario.Nome);
            strquery += string.Format(" cpf_Func = '{0}', ", funcionario.CPF);
            strquery += string.Format(" email_Login = '{0}', ", funcionario.Email);
            strquery += string.Format(" senha_Login = '{0}', ", funcionario.Senha);
            strquery += string.Format(" confirmaSenha = '{0}' ", funcionario.ConfirmaSenha);
            strquery += string.Format("Where cod_Func = {0};", funcionario.ID);

            using (db = new Banco())
            {
                db.ExecutaComando(strquery);
            }
        }

        public void Excluir(int ID)
        {
            var strquery = "";
            strquery += string.Format("delete from tbl_Funcionario where cod_Func={0};", ID);

            using (db = new Banco())
            {
                db.ExecutaComando(strquery);
            }
        }

        public void Salvar(Funcionario funcionario)
        {
            if (funcionario.ID > 0)
            {
                Atualizar(funcionario);
            }
            else
            {
                Insert(funcionario);
            }
        }

        public void SalvarFuncionario(Funcionario funcionario)
        {
            if (funcionario.ID > 0)
            {
                Atualizar(funcionario);
            }
            else
            {
                Insert(funcionario);
            }
        }

        public List<Funcionario> Listar()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_Funcionario;";
            var retorno = db.RetornaComando(strQuery);
            return ListaDeFuncionario(retorno);
        }

        private List<Funcionario> ListaDeFuncionario(MySqlDataReader retorno)
        {
            var funcionarios = new List<Funcionario>();
            while (retorno.Read())
            {
                var TempFuncionario = new Funcionario()
                {
                    ID = int.Parse(retorno["cod_Func"].ToString()),
                    Nome = retorno["nome_Func"].ToString(),
                    CPF = retorno["cpf_Func"].ToString(),
                    Email = retorno["email_Login"].ToString(),
                    Senha = retorno["senha_Login"].ToString(),
                    ConfirmaSenha = retorno["confirmaSenha"].ToString()
                };
                funcionarios.Add(TempFuncionario);
            }
            retorno.Close();
            return funcionarios;
        }

        public Funcionario ListarId(int ID)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_Funcionario where cod_Func = {0};", ID);
                var retorno = db.RetornaComando(strQuery);
                return ListaDeFuncionario(retorno).FirstOrDefault();
            }
        }

        public List<Funcionario> BuscaFuncionario()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_Funcionario;";
            var retorno = db.RetornaComando(strQuery);
            return ListaDeBuscaFuncionario(retorno);
        }

        public Funcionario BuscarId(int ID)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_Funcionario where cod_Func = {0};", ID);
                var retorno = db.RetornaComando(strQuery);
                return ListaDeBuscaFuncionario(retorno).FirstOrDefault();
            }
        }

        private List<Funcionario> ListaDeBuscaFuncionario(MySqlDataReader retorno)
        {
            var funcionarios = new List<Funcionario>();
            while (retorno.Read())
            {
                var TempFuncionario = new Funcionario()
                {
                    ID = int.Parse(retorno["cod_Func"].ToString()),
                    Nome = (retorno["nome_Func"].ToString())
                };
                funcionarios.Add(TempFuncionario);
            }
            retorno.Close();
            return funcionarios;
        }

        public Boolean VerificaUsuario(Funcionario funcionario)
        {

            using (db = new Banco())
            {
                
                var strQuery = string.Format("SELECT * FROM tbl_Funcionario where email_Login = '{0}' and senha_Login='{1}';", funcionario.Email, funcionario.Senha);
                db.ExecutaComando(strQuery);
                var retorno = db.RetornaComando(strQuery);

                if (retorno.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}