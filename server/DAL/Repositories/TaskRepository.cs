using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

namespace DAL.Repositories
{
    public class TaskRepository: ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<Task>> getTasksAsync(int skip, int take)
        {
            var query = _context.Tasks
                .OrderBy(t => t.TaskNumber)
                .Skip(skip)
                .Take(take);
            return await query.ToListAsync();
        }

        public async Task<ICollection<Task>> getTasksByFilterAsync(int skip, int take, string taskNumber)
        {
            var query = _context.Tasks
                .Where(t => t.TaskNumber.StartsWith(taskNumber))
                .OrderBy(t => t.TaskNumber)
                .Skip(skip)
                .Take(take);
            return await query.ToListAsync();
        }
        
    }
}