using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TaskRepository: ITaskRepository, ITaskProvider
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<TaskEntity>> GetTasksAsync(int skip, int take)
        {
            var query = _context.Tasks
                .OrderBy(t => t.TaskNumber)
                .Skip(skip)
                .Take(take);
            return await query.ToListAsync();
        }

        public async Task<ICollection<TaskEntity>> GetTasksByFilterAsync(int skip, int take, string taskNumber)
        {
            var query = _context.Tasks
                .Where(t => t.TaskNumber.StartsWith(taskNumber))
                .OrderBy(t => t.TaskNumber)
                .Skip(skip)
                .Take(take);
            return await query.ToListAsync();
        }

        public void AddTask(TaskEntity task)
        {
            _context.Tasks.Add(task);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}