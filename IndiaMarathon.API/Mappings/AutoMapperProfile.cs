using AutoMapper;
using IndiaMarathon.API.Models.Domain;
using IndiaMarathon.API.Models.DTO;

namespace IndiaMarathon.API.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<States, StatesDto>().ReverseMap();
            CreateMap<AddStateDto,States>().ReverseMap();  
        }
    }
}
