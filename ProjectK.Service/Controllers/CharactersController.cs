using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectK.Business.Characters;
using ProjectK.Contracts;

namespace ProjectK.Service.Controllers
{
    // TODO: authorize
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _service;

        public CharactersController(ICharacterService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
        {
            var result = await _service.GetCharacterByIdAsync(id);

            return result ?? (ActionResult<CharacterDto>) NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<CharacterDto>> CreateCharacter(CharacterDto model)
        {
            var result = await _service.CreateCharacterAsync(model);

            return result ?? (ActionResult<CharacterDto>) NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CharacterDto>> UpdateCharacter(int id, CharacterDto model)
        {
            var result = await _service.UpdateCharacterByIdAsync(id, model);

            return result ?? (ActionResult<CharacterDto>) NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CharacterDto>> DeleteCharacter(int id)
        {
            var result = await _service.DeleteCharacterByIdAsync(id);

            return result ? NoContent() : NotFound();
        }
    }
}