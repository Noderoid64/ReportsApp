using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace DAL.Repositories
{
    public interface ITaskRepository
    {
        Task<ICollection<TaskEntity>> GetTasksAsync(int skip, int take);
        Task<ICollection<TaskEntity>> GetTasksByFilterAsync(int skip, int take, string taskNumber);
        void AddTask(TaskEntity task);
        Task SaveAsync();
    }
}