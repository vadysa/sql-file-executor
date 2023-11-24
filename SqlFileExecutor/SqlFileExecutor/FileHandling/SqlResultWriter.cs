using System.Data;
using System.IO;
using System.Linq;

namespace SqlFileExecutor.FileHandling
{
    /// <summary>Представляет писателя результатов в файл.</summary>
    class SqlResultWriter : IResultWriter
    {
        private readonly string _outputFilePath;
        private readonly string _delimiter;

        /// <summary>Создаёт экземпляр класса <see cref="SqlResultWriter"/>.</summary>
        /// <param name="outputFilePath">Путь к файлу, в который будет записан результат.</param>
        /// <param name="delimiter">Разделитель данных.</param>
        public SqlResultWriter(string outputFilePath, string delimiter = ",")
        {
            _outputFilePath = outputFilePath;
            _delimiter = delimiter;
            Directory.CreateDirectory(Directory.GetParent(_outputFilePath).FullName);
        }

        /// <inheritdoc/>
        public void Write(IDataReader reader)
        {
            using(var sw = new StreamWriter(_outputFilePath, false))
            {
                var headerLine = string.Join(_delimiter, Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i) ?? ""));
                if(headerLine.Length > 0)
                {
                    sw.WriteLine(headerLine);
                }

                while(reader.Read())
                {
                    string dataLine = string.Join(_delimiter, Enumerable.Range(0, reader.FieldCount).Select(i => GetValueString(reader.GetValue(i))));
                    sw.WriteLine(dataLine);
                }
            }
        }

        private static string GetValueString(object value)
        {
            return value?.ToString() ?? "";
        }
    }
}
