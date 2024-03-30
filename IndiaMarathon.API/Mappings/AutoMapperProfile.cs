using AutoMapper;
using IndiaMarathon.API.Models.Domain;
using IndiaMarathon.API.Models.DTO;

namespace IndiaMarathon.API.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<State,StatesDto>().ReverseMap();
            CreateMap<AddStateDto,State>().ReverseMap();
            CreateMap<Level,LevelDto>().ReverseMap();
            CreateMap<AddLevelDto, Level>().ReverseMap();
            CreateMap<Marathon,MarathonDto>().ReverseMap();
            CreateMap<AddMarathonDto,Marathon>().ReverseMap();  
        }
    }
}
