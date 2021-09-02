using AutoMapper;
using RPG.Domain.Dto.Character;
using RPG.Domain.DTO.Fight;
using RPG.Domain.DTO.Skill;
using RPG.Domain.DTO.Weapon;
using RPG.Domain.Entities;

namespace RPG.Data.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Character, CharacterDto>()
                .ForMember(dir => dir.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dir => dir.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dir => dir.HitPoints, opt => opt.MapFrom(src => src.HitPoints))
                .ForMember(dir => dir.Strength, opt => opt.MapFrom(src => src.Strength))
                .ForMember(dir => dir.Defense, opt => opt.MapFrom(src => src.Defense))
                .ForMember(dir => dir.Fights, opt => opt.MapFrom(src => src.Fights))
                .ForMember(dir => dir.Defeats, opt => opt.MapFrom(src => src.Defeats))
                .ForMember(dir => dir.Victories, opt => opt.MapFrom(src => src.Victories))
                .ForMember(dir => dir.Intelligence, opt => opt.MapFrom(src => src.Intelligence))
                .ForMember(dir => dir.Class, opt => opt.MapFrom(src => src.Class))
                .ForMember(dir => dir.Weapon, opt => opt.MapFrom(src => src.Weapon))
                .ForMember(dir => dir.Skills, opt => opt.MapFrom(src => src.Skills))
                .ReverseMap();

            CreateMap<Character, AddCharacterDto>()
                .ForMember(dir => dir.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dir => dir.HitPoints, opt => opt.MapFrom(src => src.HitPoints))
                .ForMember(dir => dir.Strength, opt => opt.MapFrom(src => src.Strength))
                .ForMember(dir => dir.Defense, opt => opt.MapFrom(src => src.Defense))
                .ForMember(dir => dir.Intelligence, opt => opt.MapFrom(src => src.Intelligence))
                .ForMember(dir => dir.Class, opt => opt.MapFrom(src => src.Class))
                .ReverseMap();

            CreateMap<Weapon, AddWeaponDto>()
                .ReverseMap();

            CreateMap<Weapon, GetWeaponDto>()
                .ReverseMap();

            CreateMap<Skill, GetSkillDto>()
                .ReverseMap();

            CreateMap<Skill, NewSkillDto>()
                .ReverseMap();

            CreateMap<Skill, UpdateSkillDto>()
                .ReverseMap();

            CreateMap<Character, HighScoreDato>()
                .ReverseMap();

        }
    }
}
