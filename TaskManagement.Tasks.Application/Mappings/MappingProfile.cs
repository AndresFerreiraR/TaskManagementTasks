using AutoMapper;
using TaskManagement.Tasks.Application.Dto;
using TaskManagement.Tasks.Domain.Entities;

namespace TaskManagement.Tasks.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, TaskItemDto>().ReverseMap();
            CreateMap<State, StateDto>().ReverseMap();
            CreateMap<Priority, PriorityDto>().ReverseMap();
            CreateMap<TaskCommets, TaskCommetsDto>().ReverseMap();
            CreateMap<TaskCommentCosmosDb, TaskCommentCosmosDbDto>().ReverseMap();
            CreateMap<TaskCosmosDb, TaskCosmosDbDto>().ReverseMap();
        }
    }
}