using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectK.Business.Weapons;
using ProjectK.Contracts;

namespace ProjectK.Service.Controllers
{
    // TODO: authorize
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponsController : ControllerBase
    {
        private readonly IWeaponService _service;

        public WeaponsController(IWeaponService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WeaponDto>> GetWeapon(int id)
        {
            var result = await _service.GetWeaponByIdAsync(id);

            return result ?? (ActionResult<WeaponDto>) NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<WeaponDto>> CreateWeapon(WeaponDto model)
        {
            var result = await _service.CreateWeaponAsync(model);

            return result ?? (ActionResult<WeaponDto>) NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WeaponDto>> UpdateWeapon(int id, WeaponDto model)
        {
            var result = await _service.UpdateWeaponByIdAsync(id, model);

            return result ?? (ActionResult<WeaponDto>) NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WeaponDto>> DeleteWeapon(int id)
        {
            var result = await _service.DeleteWeaponByIdAsync(id);

            return result ? NoContent() : NotFound();
        }
    }
}