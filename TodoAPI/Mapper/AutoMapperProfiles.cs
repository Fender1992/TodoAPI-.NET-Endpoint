using AutoMapper;
using TodoAPI.Dto;
using TodoAPI.Model;

namespace TodoAPI.Mapper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TaskDto, UserTask>().ReverseMap();
        }
    }
}
