using Application.Models.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class TaskProfile: Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskEntity, TaskDto>().ReverseMap();
        }
    }
}