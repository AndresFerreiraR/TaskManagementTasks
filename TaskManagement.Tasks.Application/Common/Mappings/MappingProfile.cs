using AutoMapper;
using TaskManagement.Tasks.Application.Dto;
using TaskManagement.Tasks.Domain.Entities;

namespace TaskManagement.Tasks.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskCommentCosmosDb, TaskCommentCosmosDbDto>().ReverseMap();
            CreateMap<TaskCosmosDb, TaskCosmosDbDto>().ReverseMap();
        }
    }
}