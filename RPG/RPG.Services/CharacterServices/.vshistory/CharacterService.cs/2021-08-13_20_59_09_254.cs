using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG.Data.Context;
using RPG.Data.Repository.CharacterRepository;
using RPG.Domain.Dto.Character;
using RPG.Domain.Entities;
using RPG.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPG.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(IMapper mapper, ICharacterRepository characterRepository, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
            _characterRepository = characterRepository;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new()
            {
                Data = await _characterRepository.AddCharacter(newCharacter)
            };
            if (serviceResponse.Data == null)
            {
                serviceResponse.Message = "No Characters";
                serviceResponse.Success = false;
            }
            if (serviceResponse.Data != null)
            {
                serviceResponse.Message = "Characters List";
            }
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
            serviceResponse.Success = false;
            serviceResponse.Message = "No Such Character";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = _mapper.Map<List<GetCharacterDto>>(await _dataContext.Character.ToListAsync());
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(await _dataContext.Character.FirstOrDefaultAsync(c => c.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = _mapper.Map<Character>(updateCharacter);
            _dataContext.Character.Update(character);
            var success = await SaveChangesAsync();
            if (success)
            {
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
                serviceResponse.Message = "All changes saved";
            }
            if (!success)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "No Such Character";
            }
            return serviceResponse;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

    }
}
