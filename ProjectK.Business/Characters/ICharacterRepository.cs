using System.Threading.Tasks;

namespace ProjectK.Business.Characters
{
    public interface ICharacterRepository
    {
        Task<Character> GetCharacterByIdAsync(int id, bool write = false);
        Task SaveCharacterAsync(Character character);
        Task DeleteCharacterByIdAsync(Character character);
    }
}