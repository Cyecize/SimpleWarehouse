using Newtonsoft.Json;
using SimpleWarehouse.Interfaces;
using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Services
{
    public class DbConnectionStorageManager : IDbConnectionPropertiesStorageManager
    {
        private const string USERNAME = "username";
        private const string PASSWORD = "password";
        private const string PORT = "port";
        private const string DATABASE_NAME = "db_name";
        private const string SERVER = "server";

        private const string FOLDER_NAME = "SimpleWarehouse";
        private const string FILE_NAME = "MySqlConf.json";

        private string APP_DATA_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        private string FullPath { get; set; }

        public DbConnectionStorageManager()
        {
            this.FullPath = $"{APP_DATA_PATH}\\{FOLDER_NAME}\\{FILE_NAME}";
            this.Initialize();
        }

        public DbProperties GetSettings()
        {
            try
            {
                Dictionary<string, string> rawProps = this.ParseJson();
                DbProperties properties = new DbProperties
                {
                    Server = rawProps[SERVER],
                    Port = rawProps[PORT],
                    Username = rawProps[USERNAME],
                    Password = rawProps[PASSWORD],
                    DatabaseName = rawProps[DATABASE_NAME]
                };
                return properties;
            }
            catch (Exception) { }
            return new DbProperties();
        }

        public void SaveSettions(DbProperties properties)
        {

            Dictionary<string, string> rawProps = new Dictionary<string, string>()
            {
                {SERVER, properties.Server },
                {PORT, properties.Port },
                {USERNAME, properties.Username },
                {PASSWORD, properties.Password },
                {DATABASE_NAME, properties.DatabaseName },
            };

            this.WriteToFile(JsonConvert.SerializeObject(rawProps));
        }

        //PRIVATE METHODS
        private void Initialize()
        {
            if (!Directory.Exists($"{APP_DATA_PATH}\\{FOLDER_NAME}"))
                Directory.CreateDirectory($"{APP_DATA_PATH}\\{FOLDER_NAME}");
            if (!File.Exists(this.FullPath))
            {
                var f = File.Create(this.FullPath);
                f.Close();
            }
            if (this.ReadFile().Trim() != "")
            {
                try { this.ParseJson(); }
                catch (Exception) { this.WriteToFile(string.Empty); }
            }
        }

        private Dictionary<string, string> ParseJson()
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(this.ReadFile());
        }

        private string ReadFile()
        {
            return File.ReadAllText(this.FullPath);
        }

        private void WriteToFile(string content)
        {
            System.IO.File.WriteAllText(this.FullPath, content);
        }
    }
}
