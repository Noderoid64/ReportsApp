#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Models.Dtos;
using Application.Services.Facades;
using Application.Services.Mappers;
using DAL.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tools;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IBiCollectionMapper<TaskDto, TaskEntity> _taskMapper;
        private readonly ITaskFacade _taskFacade;

        public TaskController(
            ITaskRepository taskRepository,
            IBiCollectionMapper<TaskDto, TaskEntity> taskMapper,
            ITaskFacade taskFacade
        )
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
            _taskMapper = taskMapper ?? throw new ArgumentNullException(nameof(taskMapper));
            _taskFacade = taskFacade ?? throw new ArgumentNullException(nameof(taskFacade));
        }

        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<ICollection<TaskEntity>>> GetTasksAsync(int skip, int take, string? taskNumber)
        {
            // TODO find another way to retrieve userId
            long userId = GetUserIdFromClaims();

            ICollection<TaskEntity> tasks = await _taskRepository.GetTasksAsync(skip, take, userId, taskNumber);
            long taskCount = await _taskRepository.GetTaskCount(userId, taskNumber);

            ICollection<TaskDto> taskDtos = _taskMapper.MapBack(tasks);
            return Ok(
                new
                {
                    tasks = taskDtos,
                    taskCount
                });
        }

        [HttpGet("validate")]
        // [Authorize]
        public async Task<ActionResult<bool>> GetIsValidTaskNumber(string taskNumber)
        {
            return Ok(await _taskFacade.GetIsValidTaskNumberAsync(taskNumber));
        }

        [HttpPut("add")]
        // [Authorize]
        public async Task<IActionResult> AddTask(TaskDto taskDto)
        {
            // TODO send userId in taskDto from client
            taskDto.userId = GetUserIdFromClaims();
            TaskEntity task = _taskMapper.Map(taskDto);

            await _taskFacade.AddTaskAsync(task);
            
            return Ok();
        }

        // TODO find other way to retrieve claims 
        private long GetUserIdFromClaims()
        {
            string strId = User.Claims.FirstOrDefault(c => c.Type.Equals("id"))?.Value;
            Validators.IsNotNull(strId);
            return long.Parse(strId);
        }
    }
}