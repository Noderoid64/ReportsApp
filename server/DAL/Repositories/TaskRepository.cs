using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TaskRepository: ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<TaskEntity>> GetTasksAsync(int skip, int take, long userId, string? taskNumber)
        {
            var query = _context.Tasks
                .Where(t => t.UserId.Equals(userId));

            query = tryAddTaskNumberFilter(query, taskNumber);
            
            query = query
                .OrderBy(t => t.TaskNumber)
                .Skip(skip)
                .Take(take);
            
            return await query.ToListAsync();
        }

        public async Task<TaskEntity> GetTaskByTaskNumberAsync(string taskNumber)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.TaskNumber.Equals(taskNumber));
        }

        public async Task<long> GetTaskCount(long userId, string? taskNumber)
        {
            var query = _context.Tasks.Where(t => t.UserId.Equals(userId));
            query = tryAddTaskNumberFilter(query, taskNumber);

            return await query.CountAsync();
        }

        public void AddTask(TaskEntity task)
        {
            _context.Tasks.Add(task);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private IQueryable<TaskEntity> tryAddTaskNumberFilter(IQueryable<TaskEntity> query, string? taskNumber)
        {
            if (taskNumber != null)
            {
                query = query.Where(t => t.TaskNumber.Contains(taskNumber));
            }

            return query;
        }
    }
}