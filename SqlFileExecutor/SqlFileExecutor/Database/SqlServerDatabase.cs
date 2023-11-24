using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

using SqlFileExecutor.FileHandling;

namespace SqlFileExecutor.Database
{
    /// <summary>Представляет работу с Microsoft SQL Server.</summary>
    class SqlServerDatabase : IDatabase
    {
        private readonly string _connectionString;
        private readonly IResultWriter _writer;

        /// <summary>Создаёт экземпляр класса <see cref="SqlServerDatabase"/>.</summary>
        /// <param name="connectionString">Строка подключения к базе данных.</param>
        /// <param name="writer">Писатель результатов в файл.</param>
        public SqlServerDatabase(string connectionString, IResultWriter writer)
        {
            _connectionString = connectionString;
            _writer = writer;
        }

        /// <inheritdoc/>
        public async Task ExecuteQuery(string query)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using(var command = new SqlCommand(query, connection))
                {
                    using(var reader = await command.ExecuteReaderAsync())
                    {
                        if(reader.HasRows)
                        {
                            _writer.Write(reader);
                            Console.WriteLine("Запрос выполнен успешно.");
                        }
                        else
                        {
                            Console.WriteLine("Запрос выполнен успешно, но не было данных.");
                        }
                    }
                }
            }
        }
    }
}
