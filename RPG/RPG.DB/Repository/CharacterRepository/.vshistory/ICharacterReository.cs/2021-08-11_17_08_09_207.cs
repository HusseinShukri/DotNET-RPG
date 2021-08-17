using System.Threading.Tasks;

namespace RPG.Data.Repository.CharacterRepository
{
    public interface ICharacterReository
    {
        Task<bool> SaveChanges();

    }
}
