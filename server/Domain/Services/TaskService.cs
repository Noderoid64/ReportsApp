﻿using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Ports;
using Tools;

namespace Domain.Services
{
    public class TaskService: ITaskService
    {
        private readonly ITaskProvider _taskProvider;
        private readonly ITaskNumberGenerator _taskNumberGenerator;

        public TaskService(
            ITaskProvider taskProvider,
            ITaskNumberGenerator taskNumberGenerator
            )
        {
            _taskProvider = taskProvider;
            _taskNumberGenerator = taskNumberGenerator;
        }

        public void AddNewTask(TaskEntity task)
        {
            Validators.IsNotNull(task, "Task should not be null");

            if (string.IsNullOrEmpty(task.TaskNumber))
            {
                task.TaskNumber = _taskNumberGenerator.CalculateTaskNumber();
            }
            
            _taskProvider.AddTask(task);
        }

    }
}