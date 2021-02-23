#nullable enable
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Task = Domain.Entities.Task;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController: Controller
    {
        private ITaskRepository _taskRepository;

        public TaskController(ITaskRepository takRepository)
        {
            _taskRepository = takRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<Task>> GetTasksAsync(int skip, int take, string? taskNumber)
        {
            ActionResult<Task> result;
            try
            {
                ICollection<Task> tasks = !string.IsNullOrEmpty(taskNumber)
                    ? await _taskRepository.getTasksByFilterAsync(skip, take, taskNumber)
                    : await _taskRepository.getTasksAsync(skip, take);

                result = Ok(tasks);
            }
            catch (Exception e)
            {
                result = Problem(e.Message);
            }

            return result;
        }
    }
}