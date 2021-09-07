using AutoMapper;
using Test.Database.Models;
using Test.Database.Model_Map;

namespace Test.Database.Model_Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonMap>().ReverseMap();
            //İkisi de aynı işe yarıyor.
            //CreateMap<PersonMap, Person>();

            CreateMap<Person, PersonMap>();
            //CreateMap<Person, PersonMap>().ForMember(dest => dest.FirstName,
            //    opt => opt.MapFrom(src => src.FirstName)).ForMember(dest =>
            //    dest.LastName, opt => opt.MapFrom(src => src.LastName)).ReverseMap();
            CreateMap<AddressMap, Address>().ReverseMap();

        }
    }
}
