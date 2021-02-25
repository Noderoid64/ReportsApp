using System;
using System.Threading.Tasks;
using DAL.Repositories;
using Domain.Entities;
using Tools;

namespace Application.Services.Facades
{
    public class TaskFacade: ITaskFacade
    {
        private readonly ITaskNumberGenerator _taskNumberGenerator;
        private readonly ITaskRepository _taskRepository;

        public TaskFacade(
            ITaskNumberGenerator taskNumberGenerator,
            ITaskRepository taskRepository
        )
        {
            _taskNumberGenerator = taskNumberGenerator ?? throw new ArgumentNullException(nameof(taskNumberGenerator));
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
        }
        
        public async Task AddTaskAsync(TaskEntity task)
        {
            Validators.IsNotNull(task);
            
            if (string.IsNullOrEmpty(task.TaskNumber))
            {
                task.TaskNumber = _taskNumberGenerator.CalculateTaskNumber();
            }
            
            _taskRepository.AddTask(task);
            await _taskRepository.SaveAsync();
        }

        public async Task<bool> GetIsValidTaskNumberAsync(string taskNumber)
        {
            TaskEntity taskEntity = await _taskRepository.GetTaskByTaskNumberAsync(taskNumber);
            return taskEntity == null;
        }
    }
}