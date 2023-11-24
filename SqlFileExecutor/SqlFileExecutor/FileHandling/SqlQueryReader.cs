using System.IO;

namespace SqlFileExecutor.FileHandling
{
    /// <summary>Представляет читателя SQL запроса из файла.</summary>
    class SqlQueryReader
    {
        /// <summary>
        /// Читает SQL запрос из указанного файла.
        /// </summary>
        /// <param name="filePath">Путь к файлу с SQL запросом.</param>
        /// <returns>Прочитанный SQL запрос в виде строки.</returns>
        public string ReadQuery(string filePath)
        {
            if(File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            else
            {
                throw new FileNotFoundException($"Не найдено файла по пути {filePath}");
            }
        }
    }
}
