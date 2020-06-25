using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.Model
{
    public class Session<T> : ISession<T>
    {
        private T _entity;

        public Session()
        {
            SessionEntity = default;
            IsActive = false;
        }

        public bool IsActive { get; set; }

        public T SessionEntity
        {
            get => _entity;
            set
            {
                IsActive = true;
                _entity = value;
            }
        }

        public void UnsetSession()
        {
            SessionEntity = default;
            IsActive = false;
        }
    }
}