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
                .ForMember(dir => dir.Strength, opt => opt.MapFrom(src => src.Strength))
                .ForMember(dir => dir.Defense, opt => opt.MapFrom(src => src.Defense))
                .ForMember(dir => dir.Intelligence, opt => opt.MapFrom(src => src.Intelligence))
                .ForMember(dir => dir.Class, opt => opt.MapFrom(src => src.Class))
                .ReverseMap();
            CreateMap<Character, AddCharacterDto>();
        }
    }
}
