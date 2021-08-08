using AutoMapper;
using RPG.Data.Models;

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
