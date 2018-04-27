using SimpleWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleWarehouse.Model
{
    public class Session<T> : ISession<T>
    {
        private T _entity;

        public bool IsActive { get; set; }
        public T SessionEntity{ get { return _entity; }set { IsActive = true; _entity = value; } }

        public Session()
        {
            this.SessionEntity = default(T);
            this.IsActive = false;
        }

        public void UnsetSession()
        {
            this.SessionEntity = default(T);
            this.IsActive = false;
        }
    }
}
