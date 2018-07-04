using MySql.Data.MySqlClient;
using SimpleWarehouse.Attributes;
using SimpleWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace SimpleWarehouse.Service
{
    public class EntityRepo<T> : IEntityRepository<T>
    {
        private Type EntityClass;
        private IOutputWriter Logger;

        public IMySqlManager SqlManager { get; set; }

        public EntityRepo(IMySqlManager sqlManager, IOutputWriter logger)
        {
            this.SqlManager = sqlManager;
            this.EntityClass = typeof(T);
            this.Logger = logger;
        }

        public List<T> FindManyByQuery(string query)
        {
            MySqlDataReader reader = this.SqlManager.ExecuteQueryData(query);
            if (reader == null)
            {
                this.SqlManager.CloseDataReader();
                return new List<T>();
            }
            PropertyInfo[] properties = this.GetAllAttributes(typeof(DbNameReference));


            List<T> entityArray = new List<T>();

            Type randomType = typeof(int);
            while (reader.Read())
            {
                T singleEntity = this.CreateInstance();
                foreach (PropertyInfo field in properties)
                {
                    try
                    {
                        Attribute attribute = Attribute.GetCustomAttribute(field, typeof(DbNameReference));
                        string attrName = attribute.ToString();
                        //this.Logger.Write(reader[attrName].ToString());
                        if (reader[attrName] != null && !Convert.IsDBNull(reader[attrName]))
                            field.SetValue(singleEntity, reader[attrName]);
                    }
                    catch (Exception ex)
                    {
                        this.Logger.WriteLine(ex.Message);
                        return new List<T>();
                    }
                }
                entityArray.Add(singleEntity);

            }

            this.SqlManager.CloseDataReader();

            return entityArray;
        }

        public T FindOneByQuery(string query)
        {
            MySqlDataReader reader = this.SqlManager.ExecuteQueryData(query);
            if (reader == null)
            {
                this.SqlManager.CloseDataReader();
                return default(T);
            }

            T singleEntity = this.CreateInstance();
            PropertyInfo[] properties = this.GetAllAttributes(typeof(DbNameReference));

            if (reader.HasRows)
            {
                reader.Read();
                foreach (PropertyInfo field in properties)
                {
                    try
                    {
                        Attribute attribute = Attribute.GetCustomAttribute(field, typeof(DbNameReference));
                        string attrName = attribute.ToString();
                        //this.Logger.Write(reader[attrName].ToString());
                        if (reader[attrName] != null && !Convert.IsDBNull(reader[attrName]))
                            field.SetValue(singleEntity, reader[attrName]);
                    }
                    catch (Exception ex)
                    {
                        this.Logger.WriteLine(ex.Message);
                        this.SqlManager.CloseDataReader();
                        return default(T);
                    }
                }
                this.SqlManager.CloseDataReader();
                return singleEntity;
            }
            this.SqlManager.CloseDataReader();
            return default(T);
        }

        public T FindOneBy(string tableName, string col, object value)
        {
            string query = $"SELECT * FROM {tableName} WHERE {col} = '{value.ToString()}' LIMIT 1";
            return this.FindOneByQuery(query);
        }

        public T FindOneBy(string col, object value)
        {
            return this.FindOneBy(this.GetTableName(), col, value);
        }

        public List<T> FindBy(string tableName, string col, object value)
        {
            string query = $"SELECT * FROM {tableName} WHERE {col} = '{value.ToString()}'";
            return this.FindManyByQuery(query);
        }

        public List<T> FindBy(string col, object value)
        {
            return this.FindBy(this.GetTableName(), col, value);
        }

        public List<T> FindAll()
        {
            return this.FindManyByQuery($"SELECT * FROM {this.GetTableName()}");
        }

        //PRIVATE METHODS
        private T CreateInstance()
        {
            return (T)Activator.CreateInstance(this.EntityClass);
        }

        private PropertyInfo[] GetAllAttributes(Type annotationType)
        {
            return this.EntityClass.GetProperties().Where(p => p.GetCustomAttributes(annotationType, false).Length > 0).ToArray();
        }

        private string GetTableName()
        {
            Attribute a = this.EntityClass.GetCustomAttribute(typeof(DbTableNameReference));
            if (a == null)
                throw new NotSupportedException("This entity does not have TableNameAttribute");
            return a.ToString();
        }

    }
}
