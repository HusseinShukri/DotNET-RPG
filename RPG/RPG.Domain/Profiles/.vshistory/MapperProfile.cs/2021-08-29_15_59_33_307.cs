using AutoMapper;
using RPG.Domain.Dto.Character;
using RPG.Domain.DTO.Weapon;
using RPG.Domain.Entities;

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
                .ForMember(dir => dir.Weapon, opt => opt.MapFrom(src => src.Weapon))
                //.ForMember(dir => dir.Skills, opt => opt.MapFrom(src => src.Skills.ConvertAll(c => c.Characters)))
                .ReverseMap();

            CreateMap<Character, AddCharacterDto>()
                .ForMember(dir => dir.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dir => dir.HitPoints, opt => opt.MapFrom(src => src.HitPoints))
                .ForMember(dir => dir.Strength, opt => opt.MapFrom(src => src.Strength))
                .ForMember(dir => dir.Defense, opt => opt.MapFrom(src => src.Defense))
                .ForMember(dir => dir.Intelligence, opt => opt.MapFrom(src => src.Intelligence))
                .ForMember(dir => dir.Class, opt => opt.MapFrom(src => src.Class))
                .ReverseMap();

            CreateMap<Character, UpdateCharacterDto>()
                .ReverseMap();

            CreateMap<Weapon, AddWeaponDto>()
                .ReverseMap();

            CreateMap<Weapon, GetWeaponDto>()
                .ReverseMap();
        }
    }
}
