#nullable enable
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Services.Mappers;
using DAL.Repositories;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController: Controller
    {
        private ITaskRepository _taskRepository;
        private ITaskService _taskService;
        private IBiCollectionMapper<TaskDto, TaskEntity> _taskMapper;

        public TaskController(
            ITaskRepository taskRepository, 
            ITaskService taskService, 
            IBiCollectionMapper<TaskDto, TaskEntity> taskMapper
            )
        {
            _taskRepository = taskRepository;
            _taskService = taskService;
            _taskMapper = taskMapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<ICollection<TaskEntity>>> GetTasksAsync(int skip, int take, string? taskNumber)
        {
            ActionResult<ICollection<TaskEntity>> result;
            try
            {
                ICollection<TaskEntity> tasks = !string.IsNullOrEmpty(taskNumber)
                    ? await _taskRepository.GetTasksByFilterAsync(skip, take, taskNumber)
                    : await _taskRepository.GetTasksAsync(skip, take);
                ICollection<TaskDto> taskDtos = _taskMapper.MapBack(tasks);
                result = Ok(taskDtos);
            }
            catch (Exception e)
            {
                result = Problem(e.Message);
            }

            return result;
        }

        [HttpPut("add")]
        public async Task<IActionResult> AddTask(TaskDto taskDto)
        {
            IActionResult result;
            try
            {
                TaskEntity taskEntity = _taskMapper.Map(taskDto);
                _taskService.AddNewTask(taskEntity);
                await _taskRepository.SaveAsync();
                result = Ok();
            }
            catch (Exception e)
            {
                result = Problem(e.Message);
            }
            
            return result;
        }
    }
}