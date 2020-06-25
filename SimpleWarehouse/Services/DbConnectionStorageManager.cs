using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Services
{
    public class DbConnectionStorageManager : IDbConnectionPropertiesStorageManager
    {
        private const string Username = "username";
        private const string Password = "password";
        private const string Port = "port";
        private const string DatabaseName = "db_name";
        private const string Server = "server";

        private const string FolderName = "SimpleWarehouse";
        private const string FileName = "MySqlConf.json";

        private readonly string _appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public DbConnectionStorageManager()
        {
            FullPath = $"{_appDataPath}\\{FolderName}\\{FileName}";
            Initialize();
        }

        private string FullPath { get; }

        private DbProperties DbProperties { get; set; }

        public DbProperties GetSettings()
        {
            if (DbProperties != null)
                return DbProperties;
            try
            {
                var rawProps = ParseJson();
                var properties = new DbProperties
                {
                    Server = rawProps[Server],
                    Port = rawProps[Port],
                    Username = rawProps[Username],
                    Password = rawProps[Password],
                    DatabaseName = rawProps[DatabaseName]
                };
                DbProperties = properties;
                return properties;
            }
            catch (Exception)
            {
            }

            return new DbProperties();
        }

        public void SaveSettings(DbProperties properties)
        {
            var rawProps = new Dictionary<string, string>
            {
                {Server, properties.Server},
                {Port, properties.Port},
                {Username, properties.Username},
                {Password, properties.Password},
                {DatabaseName, properties.DatabaseName}
            };

            WriteToFile(JsonConvert.SerializeObject(rawProps));
        }

        //PRIVATE METHODS
        private void Initialize()
        {
            if (!Directory.Exists($"{_appDataPath}\\{FolderName}"))
                Directory.CreateDirectory($"{_appDataPath}\\{FolderName}");
            if (!File.Exists(FullPath))
            {
                var f = File.Create(FullPath);
                f.Close();
            }

            if (ReadFile().Trim() != "")
                try
                {
                    ParseJson();
                }
                catch (Exception)
                {
                    WriteToFile(string.Empty);
                }
        }

        private Dictionary<string, string> ParseJson()
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(ReadFile());
        }

        private string ReadFile()
        {
            return File.ReadAllText(FullPath);
        }

        private void WriteToFile(string content)
        {
            File.WriteAllText(FullPath, content);
        }
    }
}