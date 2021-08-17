using RPG.Domain.Dto.Character;
using RPG.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacters(int id);
    }
}
