#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Services.Mappers;
using DAL.Repositories;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tools;

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
        // [Authorize]
        public async Task<ActionResult<ICollection<TaskEntity>>> GetTasksAsync(int skip, int take, string? taskNumber)
        {
            ActionResult<ICollection<TaskEntity>> result;
            try
            {
                long userId = GetUserIdFromClaims();
                
                ICollection<TaskEntity> tasks = await _taskRepository.GetTasksAsync(skip, take, userId, taskNumber);
                long taskCount = await _taskRepository.GetTaskCount(userId, taskNumber);
                
                ICollection<TaskDto> taskDtos = _taskMapper.MapBack(tasks);
                result = Ok(
                    new {
                    tasks = taskDtos,
                    taskCount
                });
            }
            catch (Exception e)
            {
                result = Problem(e.Message);
            }

            return result;
        }

        [HttpGet("validate")]
        // [Authorize]
        public async Task<ActionResult<bool>> GetIsValidTaskNumber(string taskNumber)
        {
            ActionResult<bool> result;
            try
            {
                TaskEntity taskEntity = await _taskRepository.GetTaskByTaskNumberAsync(taskNumber);
                result = Ok(taskEntity == null);
            }
            catch (Exception e)
            {
                result = Problem(e.Message);
            }

            return result;
        }

        [HttpPut("add")]
        // [Authorize]
        public async Task<IActionResult> AddTask(TaskDto taskDto)
        {
            IActionResult result;
            try
            {
                taskDto.userId = GetUserIdFromClaims();
                Assert.IsNotNull(taskDto.userId);
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

        private long GetUserIdFromClaims()
        {
            string strId = User.Claims.FirstOrDefault(c => c.Type.Equals("id"))?.Value;
            Assert.IsNotNull(strId);
            return long.Parse(strId);
        }
    }
}