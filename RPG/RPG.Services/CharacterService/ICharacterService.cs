using RPG.Domain.Dto.Character;
using RPG.Domain.DTO.Skill;
using RPG.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<CharacterDto>>> GetAllCharacters(int userId);
        Task<ServiceResponse<CharacterDto>> GetCharacterById(int id, int userId);
        Task<ServiceResponse<List<CharacterDto>>> AddCharacter(AddCharacterDto newCharacter, int userId);
        Task<ServiceResponse<CharacterDto>> UpdateCharacter(CharacterDto updateCharacter, int userId);
        Task<ServiceResponse<List<CharacterDto>>> DeleteCharacters(int id, int userId);
        Task<ServiceResponse<CharacterDto>> AddCharacterSkill(AddCharacterSkill newCharacterSkill, int userId);
    }
}
