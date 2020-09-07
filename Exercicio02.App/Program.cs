using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using Polly;

namespace Exercicio02.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = "Server=exercicio02_database;Database=Exercicio02;User Id=sa;Password=Dev123456789";

            
            Policy retryPolicy = Policy.Handle<SqlException>().WaitAndRetry(
                retryCount: 3,
                sleepDurationProvider: attempt => TimeSpan.FromMilliseconds(5000));
            
            retryPolicy.Execute(() =>
            {
                using (var conexaoBD = new SqlConnection(connection))
                {
                    ExecuteQuery1(conexaoBD);

                    Console.WriteLine("");
                    ExecuteQuery2(conexaoBD);

                    Console.WriteLine("");
                    ExecuteQuery3(conexaoBD);

                    Console.WriteLine("");
                    ExecuteQuery4(conexaoBD);
                }
            });

        }

        private static void ExecuteQuery4(SqlConnection conexaoBD)
        {
            string query;
            Console.WriteLine("Query 4");

            query = @"
                select 
                    Nome 
                from 
                    Empregado 
                where 
                    Codigo in ( select E1.Codigo from Empregado E1, Empregado E2 where E1.Salario > E2.Salario)";

            ExecuteQuery(conexaoBD, query);
        }

        private static void ExecuteQuery3(SqlConnection conexaoBD)
        {
            string query;
            Console.WriteLine("Query 3");

            query = @"
                    select 
                        Nome
                    from 
                        Empregado 
                    where 
                        Salario >= all (select Salario from Empregado)";

            ExecuteQuery(conexaoBD, query);
        }

        private static void ExecuteQuery2(SqlConnection conexaoBD)
        {
            string query;
            Console.WriteLine("Query 2");

            query = @"
                    select
                        Nome 
                    from 
                        Empregado
                    where Salario = (select max(Salario) from Empregado)";

            ExecuteQuery(conexaoBD, query);
        }

        private static void ExecuteQuery1(SqlConnection conexaoBD)
        {
            Console.WriteLine("Query 1");

            string query = @"
                select 
                    Nome
                from 
                    Empregado
                where Codigo in (select Codigo
                    from Empregado)
                    AND Codigo NOT IN ((select E1.Codigo
                    from Empregado E1, Empregado E2
                    where E1.Salario < E2.Salario));";

            ExecuteQuery(conexaoBD, query);
        }

        private static void ExecuteQuery(SqlConnection conexaoBD, string query1)
        {
            var resultado = conexaoBD.Query<string>(query1).ToList();

            resultado.ForEach(Console.WriteLine);
        }
    }
}