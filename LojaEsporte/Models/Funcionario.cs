using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace LojaEsporte.Models
{
    public class Funcionario
    {
        [Required(ErrorMessage = "O id é obrigatório")]
        //[Range(1, 200, ErrorMessage = "O id deve estar entre 1 e 200")]
        public int ID { get; set; } /*Podendo ser ushort dependendo da quantidade*/

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        //ADICIONAR A VALIDAÇÃO DO CPF
        public string CPF { get; set; }

        //[RegularExpression(@"[a-zA-Z]{5,15}", ErrorMessage = "Somente letras, no minimo 5 e no máximo 15")]
        //[Required(ErrorMessage = "O login é obrigatório")]
        //[Remote("Validalogin", "Usuario", ErrorMessage = "Este login já existe!")]
        //public string Login { get; set; }

        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\-][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$", ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas são diferentes")]
        public string ConfirmaSenha { get; set; }
    }
}