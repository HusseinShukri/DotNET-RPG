using RPG.Data.Repository.CharacterRepository;
using RPG.Domain.Dto.Character;
using RPG.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new()
            {
                Data = await _characterRepository.AddCharacter(newCharacter)
            };
            if (serviceResponse.Data != null)
            {
                serviceResponse.Message = "Characters List";
                return serviceResponse;
            }
            serviceResponse.Message = "No Characters";
            serviceResponse.Success = false;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacters(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new()
            {
                Data = await _characterRepository.DeleteCharacters(id)
            };
            if (serviceResponse.Data != null)
            {
                serviceResponse.Message = "Character deleted successfully";
                return serviceResponse;
            }
            serviceResponse.Message = "No Such Character";
            serviceResponse.Success = false;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            return (ServiceResponse<List<GetCharacterDto>>)(new()
            {
                Data = await _characterRepository.GetAllCharacters()
            });
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> ServiceResponse = new() { Data = await _characterRepository.GetCharacterById(id) };
            if (ServiceResponse.Data == null) { ServiceResponse.Message = "Character Not Found"; ServiceResponse.Success = false; }
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new()
            {
                Data = await _characterRepository.UpdateCharacter(updateCharacter)
            };

            if (serviceResponse.Data != null)
            {
                serviceResponse.Message = "All changes saved";
                return serviceResponse;
            }
            serviceResponse.Success = false;
            serviceResponse.Message = "No Such Character";
            return serviceResponse;
        }
    }
}
