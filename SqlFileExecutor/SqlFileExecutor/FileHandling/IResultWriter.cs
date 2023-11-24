using System.Data;

namespace SqlFileExecutor.FileHandling
{
    /// <summary>Определяет писателя результатов в файл.</summary>
    public interface IResultWriter
    {
        /// <summary>
        /// Записывает результат выполнения SQL запроса в указанный файл.
        /// </summary>
        /// <param name="reader">Читатель базы данных.</param>
        void Write(IDataReader reader);
    }
}