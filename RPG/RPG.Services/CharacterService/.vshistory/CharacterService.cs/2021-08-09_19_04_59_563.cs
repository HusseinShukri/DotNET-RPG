using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG.Data.Context;
using RPG.Data.Models;
using RPG.Domain.Dto.Character;
using RPG.Domain.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static readonly List<Character> CharacterList = new List<Character> {
        new Character(),
        new Character{Id=1, Name="Omar"}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public CharacterService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            Character character = _mapper.Map<Character>(newCharacter);
            await _dataContext.Character.AddAsync(character);
            await _dataContext.SaveChangesAsync();
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = _mapper.Map<List<GetCharacterDto>>(_dataContext.Character.ToList());
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacters(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = await _dataContext.Character.FirstOrDefaultAsync(c=>c.Id==id);
            if (character != null)
            {
                _dataContext.Character.Remove(character);

                if () {
                    serviceResponse.Data = _mapper.Map<List<GetCharacterDto>>(await _dataContext.Character.ToListAsync());
                    serviceResponse.Message = "Character :" + character.Name + ", deleted successfully";
                }
                else{ 
                
                }
            }
            if (character == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "No Such Character";
            }

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
            Character character = await _dataContext.Character.FirstOrDefaultAsync(c => c.Id == updateCharacter.Id);
            var c = _mapper.Map<Character>(updateCharacter);
            _dataContext.Character.Update(c);

            if (character != null)
            {
               
                
                
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
                serviceResponse.Message = "All changes saved";
            }
            if (character == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "No Such Character";
            }

            return serviceResponse;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dataContext.SaveChangesAsync() > 0);
        }

    }
}
