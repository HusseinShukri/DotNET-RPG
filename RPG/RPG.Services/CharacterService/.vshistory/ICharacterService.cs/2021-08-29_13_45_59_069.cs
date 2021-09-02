using RPG.Domain.Dto.Character;
using RPG.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters(int userId);
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id, int userId);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter, int userId);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter, int userId);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacters(int id, int userId);
    }
}
