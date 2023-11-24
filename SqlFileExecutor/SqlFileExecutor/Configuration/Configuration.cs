/// <summary>
/// Представляет конфигурацию настроек для приложения.
/// </summary>
public class Configuration
{
    /// <summary>
    /// Путь к файлу SQL-запроса.
    /// </summary>
    public string InputFilePath { get; set; } = "";

    /// <summary>
    /// Путь к файлу вывода для результатов.
    /// </summary>
    public string OutputFilePath { get; set; } = "";

    /// <summary>
    /// Разделитель, используемый в файле вывода.
    /// </summary>
    public string Delimiter { get; set; } = "\t";

    /// <summary>
    /// Строка подключения к базе данных.
    /// </summary>
    public string ConnectionString { get; set; } = "Server=(localdb)\\mssqllocaldb;Database=testdb;Trusted_Connection=True;";
}