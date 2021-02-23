using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Ports;
using Tools;

namespace Domain.Services
{
    public class TaskService: ITaskService
    {
        private ITaskProvider _taskProvider;

        public TaskService(ITaskProvider taskProvider)
        {
            _taskProvider = taskProvider;
        }

        public void AddNewTask(TaskEntity task)
        {
            Assert.IsNotNull(task, "Task should not be null");

            task.TaskNumber = CalculateTaskNumber();
            _taskProvider.AddTask(task);
        }

        #region TaskNumberCalculation
        
        // TODO: move to separate service
        private DateTime _currentDate = DateTime.Today;
        private int _counter = 0;
        
        private string CalculateTaskNumber()
        {
            if (!_currentDate.Equals(DateTime.Today))
            {
                _currentDate = DateTime.Today;
                _counter = 0;
            }
            return $"{_currentDate.ToShortDateString()}-{_counter++}";
        }

        #endregion
        
    }
}