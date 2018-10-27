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
        private const string Username = "username";
        private const string Password = "password";
        private const string Port = "port";
        private const string DatabaseName = "db_name";
        private const string Server = "server";

        private const string FolderName = "SimpleWarehouse";
        private const string FileName = "MySqlConf.json";

        private readonly string _appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        private string FullPath { get; set; }

        private DbProperties DbProperties { get; set; }

        public DbConnectionStorageManager()
        {
            this.FullPath = $"{this._appDataPath}\\{FolderName}\\{FileName}";
            this.Initialize();
        }

        public DbProperties GetSettings()
        {
            if (this.DbProperties != null)
                return this.DbProperties;
            try
            {
                Dictionary<string, string> rawProps = this.ParseJson();
                DbProperties properties = new DbProperties
                {
                    Server = rawProps[Server],
                    Port = rawProps[Port],
                    Username = rawProps[Username],
                    Password = rawProps[Password],
                    DatabaseName = rawProps[DatabaseName]
                };
                this.DbProperties = properties;
                return properties;
            }
            catch (Exception) { }
            return new DbProperties();
        }

        public void SaveSettings(DbProperties properties)
        {

            Dictionary<string, string> rawProps = new Dictionary<string, string>()
            {
                {Server, properties.Server },
                {Port, properties.Port },
                {Username, properties.Username },
                {Password, properties.Password },
                {DatabaseName, properties.DatabaseName },
            };

            this.WriteToFile(JsonConvert.SerializeObject(rawProps));
        }

        //PRIVATE METHODS
        private void Initialize()
        {
            if (!Directory.Exists($"{this._appDataPath}\\{FolderName}"))
                Directory.CreateDirectory($"{this._appDataPath}\\{FolderName}");
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
