using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using LojaEsporte;


namespace LojaEsporte
{
    public class Banco:IDisposable
    {
        private readonly MySqlConnection conexao;
        public Banco ()
        {
            conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexao.Open();
        }

        public void ExecutaComando(string strQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };
            vComando.ExecuteNonQuery();
        }

        public MySqlDataReader RetornaComando(string strQuery)
        {
            var vComando = new MySqlCommand(strQuery, conexao);
            return vComando.ExecuteReader();
        }

        public MySqlDataReader RetornaComandoo(string strQuery)
        {
            var vComando = new MySqlCommand(strQuery, conexao);
            MySqlDataReader sdr = vComando.ExecuteReader();


            return vComando.ExecuteReader();
        }


        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }
    }
}