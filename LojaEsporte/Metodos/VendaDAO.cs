using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaEsporte.Models;
using MySql.Data.MySqlClient;

namespace LojaEsporte.Metodos
{
    public class VendaDAO
    {
        private Banco db;

        public void Insert(Venda venda)
        {
            string strInserir = "";
            strInserir += "insert into tbl_Venda values(null, ";  
            strInserir += string.Format("'{0}', ", venda.Cod_Pagamento);
            strInserir += string.Format("'{0}', ", venda.Cod_Funcionario);
            strInserir += string.Format("'{0}',", venda.NomeCliente);
            strInserir += string.Format("'{0}',", venda.CPF);
            strInserir += string.Format("'{0}',", venda.Telefone);
            strInserir += string.Format("STR_TO_DATE('{0}', '%d/%m/%Y %H:%i:%s'),", venda.dataVenda);
            strInserir += string.Format("'{0}',", venda.Cod_Produto);
            strInserir += string.Format("'{0}',", venda.Cod_Fornecedor);
            strInserir += string.Format("'{0}',", venda.Nome_Produto);
            strInserir += string.Format("REPLACE( '{0}', ',', '.' ),", venda.Preco_Produto);
            strInserir += string.Format("'{0}',", venda.Quantidade);
            strInserir += string.Format("REPLACE('{0}', ',', '.' ),", venda.Total_Produto);
            strInserir += string.Format("REPLACE( '{0}', ',', '.' ));", venda.TotalVenda);

            using (db = new Banco())
            {
                db.ExecutaComando(strInserir);
            }
        }

        public void Atualizar(Venda venda)
        {
            var strquery = "";
            strquery += "update tbl_Venda set";
            strquery += string.Format(" cod_Pagamento = '{0}', ", venda.Cod_Pagamento);
            strquery += string.Format(" cod_Func = '{0}', ", venda.Cod_Funcionario);
            strquery += string.Format(" nome_Cliente = '{0}', ", venda.NomeCliente);
            strquery += string.Format(" cpf_Cliente = '{0}', ", venda.CPF);
            strquery += string.Format(" telefone_Cliente = '{0}', ", venda.Telefone);
            strquery += string.Format(" data_Venda = STR_TO_DATE('{0}', '%d/%m/%Y %H:%i:%s'), ", venda.dataVenda);
            strquery += string.Format(" cod_Prod = '{0}', ", venda.Cod_Produto);
            strquery += string.Format(" cod_Forn = '{0}', ", venda.Cod_Fornecedor);
            strquery += string.Format(" nome_produto = '{0}', ", venda.Nome_Produto);
            strquery += string.Format(" preco_produto = REPLACE( '{0}', ',', '.' ), ", venda.Preco_Produto);
            strquery += string.Format(" quantidade_item = '{0}', ", venda.Quantidade);
            strquery += string.Format(" total_Produto = REPLACE( '{0}', ',', '.' ), ", venda.Total_Produto);
            strquery += string.Format(" total_Venda = REPLACE( '{0}', ',', '.' ) ", venda.TotalVenda);
            strquery += string.Format("Where cod_Venda = {0};", venda.ID);

            using (db = new Banco())
            {
                db.ExecutaComando(strquery);
            }
        }

        public void Excluir(int ID)
        {
            var strquery = "";
            strquery += string.Format("delete from tbl_Venda where cod_Venda={0};", ID);

            using (db = new Banco())
            {
                db.ExecutaComando(strquery);
            }
        }

        public void Salvar(Venda venda)
        {
            if (venda.ID > 0)
            {
                Atualizar(venda);
            }
            else
            {
                Insert(venda);
            }
        }

        public List<Venda> Listar()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_Venda;";
            var retorno = db.RetornaComando(strQuery);
            return ListaDeVenda(retorno);
        }

        private List<Venda> ListaDeVenda(MySqlDataReader retorno)
        {
            var vendas = new List<Venda>();
            while (retorno.Read())
            {
                var TempVenda = new Venda()
                {
                    ID = int.Parse(retorno["cod_Venda"].ToString()),
                    Cod_Pagamento = int.Parse(retorno["cod_Pagamento"].ToString()),
                    Cod_Funcionario = int.Parse(retorno["cod_Func"].ToString()),
                    NomeCliente = retorno["nome_Cliente"].ToString(),
                    CPF = retorno["cpf_Cliente"].ToString(),
                    Telefone = retorno["telefone_Cliente"].ToString(),
                    dataVenda = DateTime.Parse(retorno["data_Venda"].ToString()),
                    Cod_Produto = int.Parse(retorno["cod_Prod"].ToString()),
                    Cod_Fornecedor = int.Parse(retorno["cod_Forn"].ToString()),
                    Nome_Produto = retorno["nome_produto"].ToString(),
                    Preco_Produto = decimal.Parse(retorno["preco_produto"].ToString()),
                    Quantidade = int.Parse(retorno["quantidade_item"].ToString()),
                    Total_Produto = decimal.Parse(retorno["total_Produto"].ToString()),
                    TotalVenda = decimal.Parse(retorno["total_Venda"].ToString())
                };
                vendas.Add(TempVenda);
            }
            retorno.Close();
            return vendas;
        }

        public Venda ListarId(int ID)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from tbl_Venda where cod_Venda = {0};", ID);
                var retorno = db.RetornaComando(strQuery);
                return ListaDeVenda(retorno).FirstOrDefault();
            }
        }
    }
}