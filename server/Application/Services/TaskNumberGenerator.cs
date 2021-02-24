using System;
using System.Threading;
using Domain.Ports;

namespace Application.Services
{
    public class TaskNumberGenerator: ITaskNumberGenerator
    {
        // TODO: the logic should be based on persisted data
        // to avoid same task numbers after server rebooting
        private DateTime _currentDate = DateTime.Today;
        private int _counter = 0;
        private Mutex _mutex = new Mutex();
        
        public string CalculateTaskNumber()
        {
            _mutex.WaitOne();
            if (!_currentDate.Day.Equals(DateTime.Today.Day))
            {
                _currentDate = DateTime.Today;
                _counter = 0;
            }
            string result = $"{_currentDate.Year}{_currentDate.Month}{_currentDate.Day}-{(_counter++).ToString("D" + 4)}";
            _mutex.ReleaseMutex();
            return result;
        }
    }
}