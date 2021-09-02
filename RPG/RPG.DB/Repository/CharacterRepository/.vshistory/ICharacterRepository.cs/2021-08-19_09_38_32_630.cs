using RPG.Domain.Dto.Character;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Data.Repository.CharacterRepository
{
    public interface ICharacterRepository
    {
        Task<List<GetCharacterDto>> GetAllCharacters(int userId);
        Task<GetCharacterDto> GetCharacterById(int id);
        Task<List<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter, int userId);
        Task<GetCharacterDto> UpdateCharacter(UpdateCharacterDto updateCharacter);
        Task<List<GetCharacterDto>> DeleteCharacters(int id);
        Task<bool> SaveChanges();
    }
}
