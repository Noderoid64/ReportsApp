using Application.Dtos;
using Domain.Entities;
using Domain.Entities.Enums;
using Tools;

namespace Application.Services.Mappers
{
    public class TaskMapperService: IMapper<TaskDto, TaskEntity>
    {
        public TaskEntity Map(TaskDto fromType)
        {
            Assert.IsNotNull(fromType);
            
            TaskEntity result = new TaskEntity();
            result.Comment = fromType.comment;
            result.Status = (TaskStatus) fromType.status;
            result.DateTime = fromType.dateTime;

            return result;
        }
    }
}