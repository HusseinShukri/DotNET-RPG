using RPG.Data.Repository.CharacterRepository;
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

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter, int userId)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new()
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

        public Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkill newCharacterSkill, int userId)
        {
            var character = await _characterRepository.GetCharacterById(newCharacterSkill.CharacterId, userId);
            ServiceResponse<GetSkillDto> response = new();
            if (character == null)
            {
                response.Success = false;
                response.Message = "character not found";
                return response;
            }

            //var skill = await _dataContext.Skill.FirstOrDefaultAsync(s => s.Id == newCharacterSkill.SkillId);

            //if (character == null)
            //{
            //    response.Success = false;
            //    response.Message = "skill not found";
            //    return response;
            //}
            //character.Skills = new() { skill };
            //_dataContext.Character.Update(character);
            //await _dataContext.SaveChangesAsync();

            //response.Data = _mapper.Map<GetSkillDto>(skill);
            //response.Message = "Skill " + skill.Name + " was added into character " + character.Name;
            //return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacters(int id, int userId)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new()
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

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters(int userId)
        {
            return (ServiceResponse<List<GetCharacterDto>>)(new()
            {
                Data = await _characterRepository.GetAllCharacters(userId)
            });
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id, int userId)
        {
            ServiceResponse<GetCharacterDto> ServiceResponse = new() { Data = await _characterRepository.GetCharacterById(id, userId) };
            if (ServiceResponse.Data == null) { ServiceResponse.Message = "Character Not Found"; ServiceResponse.Success = false; }
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter, int userId)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new()
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
