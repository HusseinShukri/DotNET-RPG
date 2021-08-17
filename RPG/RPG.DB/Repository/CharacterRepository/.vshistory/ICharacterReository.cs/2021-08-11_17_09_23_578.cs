using RPG.Domain.Dto.Character;
using RPG.Domain.Response;
using System.Threading.Tasks;

namespace RPG.Data.Repository.CharacterRepository
{
    public interface ICharacterReository
    {
        Task<ServiceResponse<>> UpdateCharacter(UpdateCharacterDto updateCharacter);
        Task<bool> SaveChanges();
    }
}
