using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Surgery;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurgeryController : ControllerBase
    {
        private readonly ISurgeryRepository _surgeryRepository;

        public SurgeryController(ISurgeryRepository surgeryRepository)
        {
            _surgeryRepository = surgeryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var surgeries = await _surgeryRepository.GetAllAsync();
            return Ok(surgeries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var surgery = await _surgeryRepository.GetByIdAsync(id);
            return surgery == null ? NotFound() : Ok(surgery);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Surgery surgery)
        {
            await _surgeryRepository.AddAsync(surgery);
            return Ok(surgery);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Surgery surgery)
        {
            if (id != surgery.Id)
                return BadRequest();

            await _surgeryRepository.UpdateAsync(surgery);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _surgeryRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
