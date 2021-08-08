using AutoMapper;
using RPG.Data.Models;
using RPG.Domain.Dto.Character;

namespace RPG.Data.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Character, GetCharacterDto>()
                .ForMember(dir => dir.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dir => dir.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dir => dir.HitPoints, opt => opt.MapFrom(src => src.HitPoints))
                .ForMember(dir => dir.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dir => dir.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dir => dir.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<Character, AddCharacterDto>();
        }
    }
}
