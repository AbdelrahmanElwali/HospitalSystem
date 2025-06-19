using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Finance;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAccountController : ControllerBase
    {
        private readonly IPatientAccountRepository _repository;

        public PatientAccountController(IPatientAccountRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _repository.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var account = await _repository.GetByIdAsync(id);
            return account == null ? NotFound() : Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientAccount account)
        {
            await _repository.AddAsync(account);
            return Ok(account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, PatientAccount account)
        {
            if (id != account.Id) return BadRequest();
            await _repository.UpdateAsync(account);
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
