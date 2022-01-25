//using LojaEsporte.Models;
//using MySql.Data.MySqlClient;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace LojaEsporte
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            // Variavel do Banco
//            var banco = new Banco();

//            var usuarioDAO = new UsuarioDAO();
//            var usuario = new Usuario();

//            // Código para inserir registro
//            usuarioDAO.Atualizar(usuario);


//            // Código para mostrar registros
//            string strSelecionaUsu = "Select * from tbUsuario";
//            MySqlDataReader leitor = banco.RetornaComando(strSelecionaUsu);

//            while (leitor.Read())
//            {
//                Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}",
//                                    leitor["IdUsu"], leitor["EmailUsu"], leitor["Senha"]
//                                 );
//            }

//            Console.ReadLine();
//        }
//    }
//}