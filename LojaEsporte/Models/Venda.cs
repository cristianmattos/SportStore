using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaEsporte.Models
{
    public class Venda
    {
        [Required(ErrorMessage = "O id é obrigatório")]
        //[Range(1, 200, ErrorMessage = "O id deve estar entre 1 e 200")]
        public int ID { get; set; } /*Podendo ser ushort dependendo da quantidade*/

        public int Cod_Pagamento { get; set; }

        public int Cod_Funcionario { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string NomeCliente { get; set; }

        //ADICIONAR A VALIDAÇÃO DO CPF
        public string CPF { get; set; }

        //ADICIONAR A VALIDAÇÃO DO TELEFONE
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe a data da venda")]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dataVenda { get; set; }

        public int Cod_Produto { get; set; }

        public int Cod_Fornecedor { get; set; }

        public string Nome_Produto { get; set; }

        public decimal Preco_Produto { get; set; }

        public double Quantidade { get; set; }

        public decimal Total_Produto { get; set; }

        [Required(ErrorMessage = "O Preco é obrigatório")]
        public decimal TotalVenda { get; set; }

    }
}