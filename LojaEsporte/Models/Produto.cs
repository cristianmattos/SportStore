using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaEsporte.Models
{
    public class Produto
    {
        [Required(ErrorMessage = "O id é obrigatório")]
        //[Range(1, 200, ErrorMessage = "O id deve estar entre 1 e 200")]
        public int ID { get; set; } /*Podendo ser ushort dependendo da quantidade*/

        public int Cod_Fornecedor { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Descricao é obrigatório")]
        public string Descriçao { get; set; }

        [Required(ErrorMessage = "O Preco é obrigatório")]
        public decimal Preço { get; set; }

        [Required(ErrorMessage = "A Unidade é obrigatório")]
        public string Unidade { get; set; }
    }
}