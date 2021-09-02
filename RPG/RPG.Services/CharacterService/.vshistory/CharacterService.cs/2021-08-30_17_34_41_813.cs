using RPG.Data.Repository.CharacterRepository;
using RPG.Data.Repository.SkillRepository;
using RPG.Domain.Dto.Character;
using RPG.Domain.DTO.Skill;
using RPG.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly ISkillRepository _skillRepository;

        public CharacterService(ICharacterRepository characterRepository, ISkillRepository skillRepository)
        {
            _characterRepository = characterRepository;
            _skillRepository = skillRepository;
        }

        public async Task<ServiceResponse<List<CharacterDto>>> AddCharacter(AddCharacterDto newCharacter, int userId)
        {
            ServiceResponse<List<CharacterDto>> serviceResponse = new()
            {
                Data = await _characterRepository.AddCharacter(newCharacter, userId)
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

        public async Task<ServiceResponse<CharacterDto>> AddCharacterSkill(AddCharacterSkill newCharacterSkill, int userId)
        {
            var character = await _characterRepository.GetCharacterById(newCharacterSkill.CharacterId, userId);
            ServiceResponse<CharacterDto> response = new();
            if (character == null)
            {
                response.Success = false;
                response.Message = "character not found";
                return response;
            }

            var skill = await _skillRepository.GetSkillById(newCharacterSkill.SkillId);

            if (skill == null)
            {
                response.Success = false;
                response.Message = "skill not found";
                return response;
            }
            character.Skills.Add(skill);
            character = await _characterRepository.UpdateCharacter(character, userId);
            if (character == null) { response.Success = false; response.Message = "Error"; return response; }
            response.Data = character;
            response.Message = "Skill " + skill.Name + " was added into character " + character.Name;
            return response;
        }

        public async Task<ServiceResponse<List<CharacterDto>>> DeleteCharacters(int id, int userId)
        {
            ServiceResponse<List<CharacterDto>> serviceResponse = new()
            {
                Data = await _characterRepository.DeleteCharacters(id, userId)
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

        public async Task<ServiceResponse<List<CharacterDto>>> GetAllCharacters(int userId)
        {
            return (ServiceResponse<List<CharacterDto>>)(new()
            {
                Data = await _characterRepository.GetAllCharacters(userId)
            });
        }

        public async Task<ServiceResponse<CharacterDto>> GetCharacterById(int id, int userId)
        {
            ServiceResponse<CharacterDto> ServiceResponse = new() { Data = await _characterRepository.GetCharacterById(id, userId) };
            if (ServiceResponse.Data == null) { ServiceResponse.Message = "Character Not Found"; ServiceResponse.Success = false; }
            return ServiceResponse;
        }

        public async Task<ServiceResponse<CharacterDto>> UpdateCharacter(CharacterDto updateCharacter, int userId)
        {
            ServiceResponse<CharacterDto> serviceResponse = new()
            {
                Data = await _characterRepository.UpdateCharacter(updateCharacter, userId)
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
