using RPG.Domain.Dto.Character;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Data.Repository.CharacterRepository
{
    public interface ICharacterRepository
    {
        Task<List<GetCharacterDto>> GetAllCharacters(int userId);
        Task<GetCharacterDto> GetCharacterById(int id, int userId);
        Task<List<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter, int userId);
        Task<GetCharacterDto> UpdateCharacter(UpdateCharacterDto updateCharacter, int userId);
        Task<List<GetCharacterDto>> DeleteCharacters(int id, int userId);
        Task<bool> SaveChanges();
    }
}
