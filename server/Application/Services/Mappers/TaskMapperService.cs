using System.Collections.Generic;
using Application.Models.Dtos;
using Domain.Entities;
using Domain.Entities.Enums;
using Tools;

namespace Application.Services.Mappers
{
    public class TaskMapperService: IBiCollectionMapper<TaskDto, TaskEntity>
    {
        public TaskEntity Map(TaskDto fromType)
        {
            Validators.IsNotNull(fromType);
            
            TaskEntity result = new TaskEntity();
            Validators.IsFalse(
                TaskStatus.TryParse(fromType.status, out TaskStatus status), 
                "Can't parse task status"
                ); 
            
            result.Status = status;
            result.Comment = fromType.comment;
            result.DateTime = fromType.date;
            result.UserId = fromType.userId;
            result.TaskNumber = fromType.taskNumber;

            return result;
        }
        
        public TaskDto MapBack(TaskEntity fromType)
        {
            Validators.IsNotNull(fromType);

            TaskDto result = new TaskDto();
            result.id = fromType.Id;
            result.taskNumber = fromType.TaskNumber;
            result.comment = fromType.Comment;
            result.date = fromType.DateTime;
            result.status = fromType.Status.ToString();

            return result;
        }
        
        // TODO: move collection mapping to common abstract class

        public ICollection<TaskEntity> Map(ICollection<TaskDto> fromCollection)
        {
            Validators.IsNotNull(fromCollection);
            IList<TaskEntity> result = new List<TaskEntity>();
            foreach (var from in fromCollection)
            {
                result.Add(Map(from));
            }

            return result;
        }
        
        public ICollection<TaskDto> MapBack(ICollection<TaskEntity> fromCollection)
        {
            Validators.IsNotNull(fromCollection);
            IList<TaskDto> result = new List<TaskDto>();
            foreach (var from in fromCollection)
            {
                result.Add(MapBack(from));
            }

            return result;
        }
    }
}