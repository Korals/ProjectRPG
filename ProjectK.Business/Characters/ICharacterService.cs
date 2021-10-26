using System.Threading.Tasks;
using ProjectK.Contracts;

namespace ProjectK.Business.Characters
{
    public interface ICharacterService
    {
        Task<CharacterDto> GetCharacterByIdAsync(int id);
        Task<CharacterDto> CreateCharacterAsync(CharacterDto model);
        Task<CharacterDto> UpdateCharacterByIdAsync(int id, CharacterDto model);
        Task<bool> DeleteCharacterByIdAsync(int id);
    }

    // TODO: custom exceptions
}