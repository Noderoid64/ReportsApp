#nullable enable
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Extensions;
using Application.Models.Dtos;
using Application.Services.Facades;
using AutoMapper;
using DAL.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/tasks")]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskFacade _taskFacade;
        private readonly IMapper _mapper;

        public TaskController(
            ITaskRepository taskRepository,
            ITaskFacade taskFacade,
            IMapper mapper
        )
        {
            _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
            _taskFacade = taskFacade ?? throw new ArgumentNullException(nameof(taskFacade));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<TaskEntity>>> GetTasksAsync(int skip, int take, string? taskNumber)
        {
            long userId = User.RetrieveUserId();

            // TODO move to facade
            ICollection<TaskEntity> tasks = await _taskRepository.GetTasksAsync(skip, take, userId, taskNumber);
            long taskCount = await _taskRepository.GetTaskCount(userId, taskNumber);

            ICollection<TaskDto> taskDtos = _mapper.Map<ICollection<TaskDto>>(tasks);
            return Ok(
                new
                {
                    tasks = taskDtos,
                    taskCount
                });
        }

        [HttpGet("validate")]
        public async Task<ActionResult<bool>> GetIsValidTaskNumber(string taskNumber)
        {
            return Ok(await _taskFacade.GetIsValidTaskNumberAsync(taskNumber));
        }

        [HttpPut("add")]
        public async Task<IActionResult> AddTask(TaskDto taskDto)
        {
            TaskEntity task = _mapper.Map<TaskEntity>(taskDto);

            await _taskFacade.AddTaskAsync(task);
            
            return Ok();
        }
    }
}