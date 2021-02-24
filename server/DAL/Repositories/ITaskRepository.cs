using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace DAL.Repositories
{
    public interface ITaskRepository
    {
        Task<ICollection<TaskEntity>> GetTasksAsync(int skip, int take, long userId, string? taskNumber);

        Task<TaskEntity> GetTaskByTaskNumberAsync(string taskNumber);
        Task<long> GetTaskCount(long userId, string? taskNumber);
        void AddTask(TaskEntity task);
        Task SaveAsync();
    }
}