using RPG.Domain.Dto.Character;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Data.Repository.CharacterRepository
{
    public interface ICharacterRepository
    {
        Task<List<CharacterDto>> GetAllCharacters(int userId);
        Task<CharacterDto> GetCharacterById(int id, int userId);
        Task<List<CharacterDto>> AddCharacter(AddCharacterDto newCharacter, int userId);
        Task<CharacterDto> AddCharacterSkill(CharacterDto characterDto, int skillId);
        Task<CharacterDto> UpdateCharacter(CharacterDto updateCharacter, int userId);
        Task<List<CharacterDto>> DeleteCharacters(int id, int userId);
        Task<bool> SaveChanges();
    }
}
