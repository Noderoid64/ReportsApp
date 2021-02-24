#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.Dtos;
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
    public class TaskController : Controller
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
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
            _taskMapper = taskMapper ?? throw new ArgumentNullException(nameof(taskMapper));
        }

        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<ICollection<TaskEntity>>> GetTasksAsync(int skip, int take, string? taskNumber)
        {
            ActionResult<ICollection<TaskEntity>> result;

            long userId = GetUserIdFromClaims();

            ICollection<TaskEntity> tasks = await _taskRepository.GetTasksAsync(skip, take, userId, taskNumber);
            long taskCount = await _taskRepository.GetTaskCount(userId, taskNumber);

            ICollection<TaskDto> taskDtos = _taskMapper.MapBack(tasks);
            result = Ok(
                new
                {
                    tasks = taskDtos,
                    taskCount
                });

            return result;
        }

        [HttpGet("validate")]
        // [Authorize]
        public async Task<ActionResult<bool>> GetIsValidTaskNumber(string taskNumber)
        {
            ActionResult<bool> result;

            TaskEntity taskEntity = await _taskRepository.GetTaskByTaskNumberAsync(taskNumber);
            result = Ok(taskEntity == null);

            return result;
        }

        [HttpPut("add")]
        // [Authorize]
        public async Task<IActionResult> AddTask(TaskDto taskDto)
        {
            IActionResult result;

            taskDto.userId = GetUserIdFromClaims();
            Validators.IsNotNull(taskDto.userId);
            TaskEntity taskEntity = _taskMapper.Map(taskDto);
            _taskService.AddNewTask(taskEntity);
            await _taskRepository.SaveAsync();
            result = Ok();


            return result;
        }

        private long GetUserIdFromClaims()
        {
            string strId = User.Claims.FirstOrDefault(c => c.Type.Equals("id"))?.Value;
            Validators.IsNotNull(strId);
            return long.Parse(strId);
        }
    }
}