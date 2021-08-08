using AutoMapper;
using RPG.Data.Models;
using RPG.Domain.Dto.Character;

namespace RPG.Data.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<Character, AddCharacterDto>();
        }
    }
}
