using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaEsporte.Models
{
    public class Fornecedor
    {
        [Required(ErrorMessage = "O id é obrigatório")]
        //[Range(1, 200, ErrorMessage = "O id deve estar entre 1 e 200")]
        public int Cod_Fornecedor { get; set; } /*Podendo ser ushort dependendo da quantidade*/

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\-][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$", ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set; }

        //ADICIONAR A VALIDAÇÃO DO CNPJ
        public string CNPJ { get; set; }

        //ADICIONAR A VALIDAÇÃO DO TELEFONE
        public string Telefone { get; set; }

        //ADICIONAR A VALIDAÇÃO DO CEP !ARRUMAR AS VARIAVEIS DO TIPO INT 
        public string CEP { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Digite o CEP corretamente")]
        public string Rua { get; set; }

        //ADICIONAR A VALIDAÇÃO DO NUMERO
        public string Numero { get; set; }

        //ADICIONAR A VALIDAÇÃO DO COMPLEMENTO
        public string Complemento { get; set; }

        //ADICIONAR A VALIDAÇÃO DO BAIRRO
        public string Bairro { get; set; }

        //ADICIONAR A VALIDAÇÃO DO CIDADE
        public string Cidade { get; set; }

        //ADICIONAR A VALIDAÇÃO DO ESTADO
        public string Estado { get; set; }
    }
}