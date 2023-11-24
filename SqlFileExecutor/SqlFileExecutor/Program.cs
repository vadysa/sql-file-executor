using System;
using System.IO;
using System.Threading.Tasks;

using SqlFileExecutor.Database;
using SqlFileExecutor.FileHandling;

namespace SqlFileExecutor
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var configuration = ConfigurationReader.LoadConfiguration();
                var connectionString = configuration.ConnectionString;
                var queryReader = new SqlQueryReader();

                var inputFilePath = configuration.InputFilePath ?? Path.Combine(Environment.CurrentDirectory, "input.txt");
                var query = queryReader.ReadQuery(inputFilePath);

                var outputFilePath = configuration.OutputFilePath ?? Path.Combine(Environment.CurrentDirectory, "output.csv");
                var resultWriter = new SqlResultWriter(outputFilePath, configuration.Delimiter);

                var db = new SqlServerDatabase(connectionString, resultWriter);
                await db.ExecuteQuery(query);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Во время работы приложения произошла ошибка: {ex.Message}");
            }

            Console.WriteLine("Программа завершила работу.");
            Console.ReadLine();
        }
    }
}
