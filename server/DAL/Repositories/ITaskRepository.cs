using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace DAL.Repositories
{
    public interface ITaskRepository
    {
        Task<ICollection<TaskEntity>> GetTasksAsync(int skip, int take, long userId);
        Task<ICollection<TaskEntity>> GetTasksByFilterAsync(int skip, int take, string taskNumber, long userId);
        Task<long> GetTaskCount(long userId);
        void AddTask(TaskEntity task);
        Task SaveAsync();
    }
}