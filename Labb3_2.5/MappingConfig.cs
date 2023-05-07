using AutoMapper;
using Labb3_2._5.Models.DTO;
using Labb3_2._5.Models;

namespace Labb3_2._5
{
    public class MappingConfig : Profile
    {

        public MappingConfig()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Person, PersonCreateDto>().ReverseMap();

            CreateMap<Interest, InterestDto>().ReverseMap();
            CreateMap<Interest, InterestCreateDto>().ReverseMap();

            CreateMap<Link, LinkDto>().ReverseMap();
            CreateMap<Link, LinkCreateDto>().ReverseMap();
        }
    }
}
