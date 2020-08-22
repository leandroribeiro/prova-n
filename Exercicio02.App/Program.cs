using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

namespace Exercicio02.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = "Server=exercicio02_database;Database=Exercicio02;User Id=sa;Password=Dev123456789";

            using (var conexaoBD = new SqlConnection(connection))
            {
                Console.WriteLine("Query 1");
                
                string query = @"
                select Nome
                from Empregado
                where Codigo in (select Codigo
                    from Empregado)
                    AND Codigo NOT IN ((select E1.Codigo
                    from Empregado E1, Empregado E2
                    where E1.Salario < E2.Salario));";

                ExecuteQuery(conexaoBD, query);

                Console.WriteLine("");
                Console.WriteLine("Query 2");
                
                query = @"select Nome from Empregado
where Salario = (select max(Salario) from Empregado)";

                ExecuteQuery(conexaoBD, query);

                Console.WriteLine("");
                Console.WriteLine("Query 3");
                
                query = @"select Nome from Empregado
where Salario >= all (select Salario from Empregado)";

                ExecuteQuery(conexaoBD, query);

                Console.WriteLine("");
                Console.WriteLine("Query 4");
                
                query = @"select Nome from Empregado
where Codigo in ( select E1.Codigo from Empregado E1, Empregado E2
where E1.Salario > E2.Salario
)";

                ExecuteQuery(conexaoBD, query);
            }
        }

        private static void ExecuteQuery(SqlConnection conexaoBD, string query1)
        {
            var resultado = conexaoBD.Query<string>(query1).ToList();

            resultado.ForEach(Console.WriteLine);
        }
    }
}