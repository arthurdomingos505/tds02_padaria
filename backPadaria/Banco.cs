using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backPadaria
{
    public static class Banco
    {
        private static string stringDeConexao = "Server=10.91.45.54;Port=3306;DataBase=padaria_bd;Uid=admin;Pwd=12345678";


        public static void connectAndTest()
        {
            using (var connection = new MySqlConnection(stringDeConexao))
            {
                try
                {
                    Console.WriteLine("Tentando conectar ao banco de dados");

                    connection.Open();

                    Console.WriteLine("Conexao bem sucedida");

                    using (var command = new MySqlCommand("SELECT VERSION();", connection))
                    {
                        string version = command.ExecuteScalar()?.ToString();
                        Console.WriteLine($"Versao do MariaDB {version}");
                    }
                        




                }catch (MySqlException ex)
                {
                    Console.WriteLine("Erro ao conectar no banco de dados");
                    Console.WriteLine(ex.Message);
                }

            }

        }

    }
}
