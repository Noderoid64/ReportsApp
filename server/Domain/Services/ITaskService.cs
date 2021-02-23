using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Services
{
    public interface ITaskService
    {
        void AddNewTask(TaskEntity task);
    }
}