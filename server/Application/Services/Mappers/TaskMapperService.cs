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
                TaskStatus.TryParse(fromType.Status, out TaskStatus status), 
                "Can't parse task status"
                ); 
            
            result.Status = status;
            result.Comment = fromType.Comment;
            result.DateTime = fromType.Date;
            result.UserId = fromType.UserId;
            result.TaskNumber = fromType.TaskNumber;

            return result;
        }
        
        public TaskDto MapBack(TaskEntity fromType)
        {
            Validators.IsNotNull(fromType);

            TaskDto result = new TaskDto();
            result.Id = fromType.Id;
            result.TaskNumber = fromType.TaskNumber;
            result.Comment = fromType.Comment;
            result.Date = fromType.DateTime;
            result.Status = fromType.Status.ToString();

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