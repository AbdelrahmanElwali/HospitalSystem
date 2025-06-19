using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Inpatients;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientStayController : ControllerBase
    {
        private readonly IPatientStayRepository _repository;

        public PatientStayController(IPatientStayRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stays = await _repository.GetAllAsync();
            return Ok(stays);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var stay = await _repository.GetByIdAsync(id);
            return stay == null ? NotFound() : Ok(stay);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientStay stay)
        {
            await _repository.AddAsync(stay);
            return Ok(stay);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, PatientStay stay)
        {
            if (id != stay.Id) return BadRequest();
            await _repository.UpdateAsync(stay);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
