using System.Threading.Tasks;

namespace RPG.Data.Repository.CharacterRepository
{
    public class CharacterReository : ICharacterReository
    {
        Task<bool> SaveChanges();
    }
}
