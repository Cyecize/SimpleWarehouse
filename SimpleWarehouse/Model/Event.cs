using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.Model
{
    public class Event : IEvent
    {
        public delegate void WorkCompletedCallBack();

        private static int ID;
        private readonly bool _isOneTimeOnly;
        private readonly long _maxCounterValue;

        private double _accumulatedTime;


        public Event(int execTimeout, WorkCompletedCallBack callback, IEventManager manager, bool isOneTimeOnly)
        {
            Callback = callback;
            _accumulatedTime = 0;
            _maxCounterValue = execTimeout;
            Id = ++ID;
            _isOneTimeOnly = isOneTimeOnly;
            Manager = manager;
        }

        private WorkCompletedCallBack Callback { get; }
        private IEventManager Manager { get; }


        public int Id { get; set; }

        public void Update(double deltaTime)
        {
            _accumulatedTime += deltaTime;
            if (_accumulatedTime >= _maxCounterValue)
            {
                _accumulatedTime = 0;
                Callback();
                if (_isOneTimeOnly)
                    Manager.RemoveEvent(Id);
            }
        }
    }
}