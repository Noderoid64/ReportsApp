using System.Collections.Generic;
using System.Threading.Tasks;
using Task = Domain.Entities.Task;

namespace DAL.Repositories
{
    public interface ITaskRepository
    {
        Task<ICollection<Task>> getTasksAsync(int skip, int take);
        Task<ICollection<Task>> getTasksByFilterAsync(int skip, int take, string taskNumber);
    }
}