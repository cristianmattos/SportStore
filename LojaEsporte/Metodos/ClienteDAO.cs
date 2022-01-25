using LojaEsporte.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaEsporte.MetodoCliente
{
    public class ClienteDAO
    {
        private Banco db;

        public void Insert(Cliente cliente)
        {
            string strInserir = "";
            strInserir += "insert into tbl_Cliente values ";  /*strquery += "insert into tbl_Produto values(null,";*/ //strquery += "2,2);";
            strInserir += string.Format("('{0}', ", cliente.ID);
            strInserir += string.Format("'{0}', ", cliente.Nome);
            strInserir += string.Format("'{0}',", cliente.Email);
            strInserir += string.Format("'{0}',", cliente.CPF);
            strInserir += string.Format("STR_TO_DATE('{0}', '%d/%m/%Y %H:%i:%s'),", cliente.Nasc);
            strInserir += string.Format("'{0}',", cliente.Telefone);
            strInserir += string.Format("'{0}',", cliente.CEP);
            strInserir += string.Format("'{0}',", cliente.Rua);
            strInserir += string.Format("'{0}',", cliente.Numero);
            strInserir += string.Format("'{0}',", cliente.Complemento);
            strInserir += string.Format("'{0}',", cliente.Bairro);
            strInserir += string.Format("'{0}',", cliente.Cidade);
            strInserir += string.Format("'{0}' );", cliente.Estado);

            using (db = new Banco())
            {
                db.ExecutaComando(strInserir);
            }
        }

        public void Atualizar(Cliente cliente)
        {
            var strquery = "";
            strquery += "update tbl_Cliente set";
            strquery += string.Format(" Nome = '{0}', ", cliente.Nome);  
            strquery += string.Format(" Email = '{0}', ", cliente.Email);
            strquery += string.Format(" Cpf = '{0}', ", cliente.CPF);
            strquery += string.Format(" Nasc = STR_TO_DATE('{0}', '%d/%m/%Y %H:%i:%s'), ", cliente.Nasc);
            strquery += string.Format(" Telefone = '{0}', ", cliente.Telefone);
            strquery += string.Format(" Cep = '{0}', ", cliente.CEP);
            strquery += string.Format(" Rua = '{0}', ", cliente.Rua);
            strquery += string.Format(" Numero = '{0}', ", cliente.Numero);
            strquery += string.Format(" Complemento = '{0}', ", cliente.Complemento);
            strquery += string.Format(" Bairro = '{0}', ", cliente.Bairro);
            strquery += string.Format(" Cidade = '{0}', ", cliente.Cidade);
            strquery += string.Format(" Estado = '{0}' ", cliente.Estado);
            strquery += string.Format("Where Id = {0};", cliente.ID);

            using (db = new Banco())
            {
                db.ExecutaComando(strquery);
            }
        }

        public void Excluir(int ID)
        {
            var strquery = "";
            strquery += string.Format("delete from tbl_Cliente where Id={0};", ID);

            using (db = new Banco())
            {
                db.ExecutaComando(strquery);
            }
        }

        public void Salvar(Cliente cliente)
        {
            if (cliente.ID > 0)
            {
                Atualizar(cliente);
            }
            else
            {
                Insert(cliente);
            }
        }

        public List<Cliente> Listar()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_Cliente;";
            var retorno = db.RetornaComando(strQuery);
            return ListaDeCliente(retorno);
        }

        private List<Cliente> ListaDeCliente(MySqlDataReader retorno)
        {
            var clientes = new List<Cliente>();
            while (retorno.Read())
            {
                var TempCliente = new Cliente()
                {
                    ID = int.Parse(retorno["Id"].ToString()),
                    Nome = retorno["Nome"].ToString(),
                    Email = retorno["Email"].ToString(),
                    CPF = retorno["Cpf"].ToString(),
                    Nasc = DateTime.Parse(retorno["Nasc"].ToString()),
                    Telefone = (retorno["Telefone"].ToString()),
                    CEP = retorno["Cep"].ToString(),
                    Rua = retorno["Rua"].ToString(),
                    Numero = retorno["Numero"].ToString(),
                    Complemento = retorno["Complemento"].ToString(),
                    Bairro = retorno["Bairro"].ToString(),
                    Cidade = retorno["Cidade"].ToString(),
                    Estado = retorno["Estado"].ToString()
                };
                clientes.Add(TempCliente);
            }
            retorno.Close();
            return clientes;
        }

        public Cliente ListarId(int ID)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_Cliente where Id = {0};", ID);
                var retorno = db.RetornaComando(strQuery);
                return ListaDeCliente(retorno).FirstOrDefault();
            }
        }
    }
}