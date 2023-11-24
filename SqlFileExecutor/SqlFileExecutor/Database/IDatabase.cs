using System.Threading.Tasks;

namespace SqlFileExecutor.Database
{
    /// <summary>Описывает работу с базой данных.</summary>
    interface IDatabase
    {
        /// <summary>Выполняет SQL запрос.</summary>
        /// <param name="query">Строка с SQL запросом.</param>
        Task ExecuteQuery(string query);
    }
}
