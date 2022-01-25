using LojaEsporte.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaEsporte.Metodos
{
    public class FornecedorDAO
    {
        private Banco db;
        public void Insert(Fornecedor fornecedor)
        {
            string strInserir = "";
            strInserir += "insert into tbl_Fornecedor values(null, ";  
            //strInserir += string.Format("('{0}', ", fornecedor.ID);
            strInserir += string.Format("'{0}', ", fornecedor.Nome);
            strInserir += string.Format("'{0}',", fornecedor.Email);
            strInserir += string.Format("'{0}',", fornecedor.CNPJ);
            strInserir += string.Format("'{0}',", fornecedor.Telefone);
            strInserir += string.Format("'{0}',", fornecedor.CEP);
            strInserir += string.Format("'{0}',", fornecedor.Rua);
            strInserir += string.Format("'{0}',", fornecedor.Numero);
            strInserir += string.Format("'{0}',", fornecedor.Complemento);
            strInserir += string.Format("'{0}',", fornecedor.Bairro);
            strInserir += string.Format("'{0}',", fornecedor.Cidade);
            strInserir += string.Format("'{0}' );", fornecedor.Estado);

            using (db = new Banco())
            {
                db.ExecutaComando(strInserir);
            }
        }

        public void Atualizar(Fornecedor fornecedor)
        {
            var strquery = "";
            strquery += "update tbl_Fornecedor set";
            strquery += string.Format(" nome_Forn = '{0}', ", fornecedor.Nome);  
            strquery += string.Format(" email_Forn = '{0}', ", fornecedor.Email);
            strquery += string.Format(" cnpj_Forn = '{0}', ", fornecedor.CNPJ);
            strquery += string.Format(" telefone_Forn = '{0}', ", fornecedor.Telefone);
            strquery += string.Format(" cep_Cliente = '{0}', ", fornecedor.CEP);
            strquery += string.Format(" Rua_Cliente = '{0}', ", fornecedor.Rua);
            strquery += string.Format(" Numero_Cliente = '{0}', ", fornecedor.Numero);
            strquery += string.Format(" Complemento_Cliente = '{0}', ", fornecedor.Complemento);
            strquery += string.Format(" Bairro_Cliente = '{0}', ", fornecedor.Bairro);
            strquery += string.Format(" Cidade_Cliente = '{0}', ", fornecedor.Cidade);
            strquery += string.Format(" uf_Cliente = '{0}' ", fornecedor.Estado);
            strquery += string.Format("Where cod_Forn = {0};", fornecedor.Cod_Fornecedor);

            using (db = new Banco())
            {
                db.ExecutaComando(strquery);
            }
        }

        public void Excluir(int ID)
        {
            var strquery = "";
            strquery += string.Format("delete from tbl_Fornecedor where cod_Forn={0};", ID);

            using (db = new Banco())
            {
                db.ExecutaComando(strquery);
            }
        }

        public void Salvar(Fornecedor fornecedor)
        {
            if (fornecedor.Cod_Fornecedor > 0)
            {
                Atualizar(fornecedor);
            }
            else
            {
                Insert(fornecedor);
            }
        }

        public void SalvarFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor.Cod_Fornecedor > 0)
            {
                Atualizar(fornecedor);
            }
            else
            {
                Insert(fornecedor);
            }
        }

        

        public List<Fornecedor> Listar()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_Fornecedor;";
            var retorno = db.RetornaComando(strQuery);
            return ListaDeFornecedor(retorno);
        }

        private List<Fornecedor> ListaDeFornecedor(MySqlDataReader retorno)
        {
            var fornecedores = new List<Fornecedor>();
            while (retorno.Read())
            {
                var TempFornecedor = new Fornecedor()
                {
                    Cod_Fornecedor = int.Parse(retorno["cod_Forn"].ToString()),
                    Nome = retorno["nome_Forn"].ToString(),
                    Email = retorno["email_Forn"].ToString(),
                    CNPJ = retorno["cnpj_Forn"].ToString(),
                    Telefone = (retorno["telefone_Forn"].ToString()),
                    CEP = retorno["cep_Cliente"].ToString(),
                    Rua = retorno["Rua_Cliente"].ToString(),
                    Numero = retorno["Numero_Cliente"].ToString(),
                    Complemento = retorno["Complemento_Cliente"].ToString(),
                    Bairro = retorno["Bairro_Cliente"].ToString(),
                    Cidade = retorno["Cidade_Cliente"].ToString(),
                    Estado = retorno["uf_Cliente"].ToString()
                };
                fornecedores.Add(TempFornecedor);
            }
            retorno.Close();
            return fornecedores;
        }

        public List<Fornecedor> BuscaFornecedor()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_Fornecedor;";
            var retorno = db.RetornaComando(strQuery);
            return ListaDeBuscaFornecedor(retorno);
        }

        public Fornecedor BuscarId(int ID)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_Fornecedor where cod_Forn = {0};", ID);
                var retorno = db.RetornaComando(strQuery);
                return ListaDeBuscaFornecedor(retorno).FirstOrDefault();
            }
        }

        private List<Fornecedor> ListaDeBuscaFornecedor(MySqlDataReader retorno)
        {
            var fornecedores = new List<Fornecedor>();
            while (retorno.Read())
            {
                var TempFornecedor = new Fornecedor()
                {
                    Cod_Fornecedor = int.Parse(retorno["cod_Forn"].ToString()),
                    Nome = retorno["nome_Forn"].ToString(),
                    Email = retorno["email_Forn"].ToString(),
                    CNPJ = retorno["cnpj_Forn"].ToString(),
                    Telefone = (retorno["telefone_Forn"].ToString())
                };
                fornecedores.Add(TempFornecedor);
            }
            retorno.Close();
            return fornecedores;
        }

        public Fornecedor ListarId(int ID)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_Fornecedor where cod_Forn = {0};", ID);
                var retorno = db.RetornaComando(strQuery);
                return ListaDeFornecedor(retorno).FirstOrDefault();
            }
        }
    }
}