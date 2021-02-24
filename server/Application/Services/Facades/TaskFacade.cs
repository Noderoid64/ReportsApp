using System;
using System.Threading.Tasks;
using Application.Models;
using DAL.Repositories;
using Domain.Entities;
using Domain.Services;
using Tools;

namespace Application.Services.Facades
{
    public class TaskFacade: ITaskFacade
    {
        private readonly ITaskService _taskService;
        private readonly ITaskRepository _taskRepository;

        public TaskFacade(
            ITaskService taskService,
            ITaskRepository taskRepository
        )
        {
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
        }
        
        public async Task AddTaskAsync(TaskEntity task)
        {
            Validators.IsNotNull(task.UserId);
            _taskService.AddNewTask(task);
            await _taskRepository.SaveAsync();
        }

        public async Task<bool> GetIsValidTaskNumberAsync(string taskNumber)
        {
            TaskEntity taskEntity = await _taskRepository.GetTaskByTaskNumberAsync(taskNumber);
            return taskEntity == null;
        }
    }
}