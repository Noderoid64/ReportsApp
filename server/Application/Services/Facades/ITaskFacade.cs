using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Services.Facades
{
    public interface ITaskFacade
    {
        Task AddTaskAsync(TaskEntity task);
        Task<bool> GetIsValidTaskNumberAsync(string taskNumber);
    }
}