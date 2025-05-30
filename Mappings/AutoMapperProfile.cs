using AutoMapper;
using TaskFlow.DTOs;
using TaskFlow.Models;

namespace TaskFlow.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskCreateDto, TaskItem>();
            CreateMap<TaskItem, TaskReadDto>();
        }
    }
}