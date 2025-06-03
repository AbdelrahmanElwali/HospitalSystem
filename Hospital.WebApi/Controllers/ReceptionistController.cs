using Hospital.Domain.Interfaces;
using Hospital.Domain.Users.Receptionists;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistController : ControllerBase
    {
        private readonly IReceptionistRepository _repository;

        public ReceptionistController(IReceptionistRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var receptionist = await _repository.GetByIdAsync(id);
            return receptionist == null ? NotFound() : Ok(receptionist);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Receptionist receptionist)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _repository.AddAsync(receptionist);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Receptionist receptionist)
        {
            if (!ModelState.IsValid || id != receptionist.Id) return BadRequest();
            await _repository.UpdateAsync(receptionist);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var receptionist = await _repository.GetByIdAsync(id);
            if (receptionist == null) return NotFound();
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
