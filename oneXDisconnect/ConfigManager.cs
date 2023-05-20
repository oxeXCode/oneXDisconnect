using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace oneXDisconnect
{
    public class ConfigManager<T> where T : new()
    {
        private readonly string _configFilePath;
        public T ConfigData { get; private set; }

        public ConfigManager(string configFilePath)
        {
            _configFilePath = configFilePath;
            ConfigData = LoadConfig();
        }

        public T LoadConfig()
        {
            if (File.Exists(_configFilePath))
            {
                string jsonContent = File.ReadAllText(_configFilePath);

                if (JsonSerializer.Deserialize<T>(jsonContent) is { } data)
                    return data;
            }

            ConfigData = new T();
            UpdateConfig();
            return ConfigData;
        }

        public void UpdateConfig()
        {
            string updatedJson = JsonSerializer.Serialize(ConfigData, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_configFilePath, updatedJson);
        }
    }
}
