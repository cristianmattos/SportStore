using LojaEsporte.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaEsporte.MetodoProduto
{
    public class ProdutoDAO
    {
        private Banco db;
        public void Insert(Produto produto)
        {
            string strInserir = "";
            strInserir += "insert into tbl_Produto values(null, ";
            strInserir += string.Format("'{0}', ", produto.Cod_Fornecedor);
            strInserir += string.Format("'{0}', ", produto.Nome);
            strInserir += string.Format("'{0}',", produto.Descriçao);
            strInserir += string.Format("REPLACE( REPLACE( '{0}', '.' ,'' ), ',', '.' ),", produto.Preço);
            strInserir += string.Format("'{0}' );", produto.Unidade);

            using (db = new Banco())
            {
                db.ExecutaComando(strInserir);
            }
        }

        public void Atualizar(Produto produto)
        {
            var strquery = "";
            strquery += "update tbl_Produto set";
            strquery += string.Format(" cod_Forn = '{0}', ", produto.Cod_Fornecedor);
            strquery += string.Format(" nome_Prod = '{0}', ", produto.Nome); // if(usuario.NomeUsu != "") 
            strquery += string.Format(" descricao_Prod = '{0}', ", produto.Descriçao);
            strquery += string.Format(" preco_Prod = REPLACE( REPLACE( '{0}', '.' ,'' ), ',', '.' ), ", produto.Preço); 
            strquery += string.Format(" unidade_Prod = '{0}' ", produto.Unidade);
            strquery += string.Format("Where cod_Prod = {0};", produto.ID);

            using (db = new Banco())
            {
                db.ExecutaComando(strquery);
            }
        }

        public void Excluir(int ID)
        {
            var strquery = "";
            strquery += string.Format("delete from tbl_Produto where cod_Prod={0};", ID);

            using (db = new Banco())
            {
                db.ExecutaComando(strquery);
            }
        }

        public void Salvar(Produto produto)
        {
            if (produto.ID > 0)
            {
                Atualizar(produto);
            }
            else
            {
                Insert(produto);
            }
        }

        public void SalvarProduto(Produto produto)
        {
            if (produto.ID > 0)
            {
                Atualizar(produto);
            }
            else
            {
                Insert(produto);
            }
        }

        public List<Produto> Listar()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_Produto;";
            var retorno = db.RetornaComando(strQuery);
            return ListaDeProduto(retorno);
        }

        private List<Produto> ListaDeProduto(MySqlDataReader retorno)
        {
            var produtos = new List<Produto>();
            while (retorno.Read())
            {
                var TempProduto = new Produto()
                {
                    ID = int.Parse(retorno["cod_Prod"].ToString()),
                    Cod_Fornecedor = int.Parse(retorno["Cod_Forn"].ToString()),
                    Nome = retorno["nome_Prod"].ToString(),
                    Descriçao = retorno["descricao_Prod"].ToString(),
                    Preço = decimal.Parse(retorno["preco_Prod"].ToString()),
                    Unidade = retorno["unidade_Prod"].ToString(),
                };
                produtos.Add(TempProduto);
            }
            retorno.Close();
            return produtos;
        }

        public Produto ListarId(int ID)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_Produto where cod_Prod = {0};", ID);
                var retorno = db.RetornaComando(strQuery);
                return ListaDeProduto(retorno).FirstOrDefault();
            }
        }

        public List<Produto> BuscaProduto()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_Produto;";
            var retorno = db.RetornaComando(strQuery);
            return ListaDeBuscaProduto(retorno);
        }

        public Produto BuscarId(int ID)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_Produto where cod_Func = {0};", ID);
                var retorno = db.RetornaComando(strQuery);
                return ListaDeBuscaProduto(retorno).FirstOrDefault();
            }
        }

        private List<Produto> ListaDeBuscaProduto(MySqlDataReader retorno)
        {
            var produtos = new List<Produto>();
            while (retorno.Read())
            {
                var TempProduto = new Produto()
                {
                    ID = int.Parse(retorno["cod_Prod"].ToString()),
                    Cod_Fornecedor = int.Parse(retorno["Cod_Forn"].ToString()),
                    Nome = retorno["nome_Prod"].ToString(),
                    Preço = decimal.Parse(retorno["preco_Prod"].ToString()),
                };
                produtos.Add(TempProduto);
            }
            retorno.Close();
            return produtos;
        }
    }
}
