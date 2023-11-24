using System;
using System.IO;

using Newtonsoft.Json;

/// <summary>
/// Представляет читателя конфигурации для загрузки настроек из файла.
/// </summary>
public class ConfigurationReader
{
    /// <summary>
    /// Загружает настройки конфигурации из файла.
    /// </summary>
    /// <returns>Настройки конфигурации.</returns>
    public static Configuration LoadConfiguration()
    {
        var configFile = Path.Combine(Environment.CurrentDirectory, "config.json");

        if(!File.Exists(configFile))
        {
            throw new FileNotFoundException($"Файл конфигурации не найден по пути {configFile}");
        }

        var json = File.ReadAllText(configFile);
        var configuration = JsonConvert.DeserializeObject<Configuration>(json);
        return configuration ?? throw new JsonSerializationException("Не удалось десериализовать конфигурацию.");
    }
}