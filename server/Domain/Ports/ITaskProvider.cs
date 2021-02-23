using Domain.Entities;

namespace Domain.Ports
{
    public interface ITaskProvider
    {
        void AddTask(TaskEntity task);
    }
}