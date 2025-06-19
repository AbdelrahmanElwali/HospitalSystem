using Hospital.Application.Interfaces;
using Hospital.Domain.Users.MedicalServices;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalServiceController : ControllerBase
    {
        private readonly IMedicalServiceRepository _repository;

        public MedicalServiceController(IMedicalServiceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var services = await _repository.GetAllAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var service = await _repository.GetByIdAsync(id);
            return service == null ? NotFound() : Ok(service);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicalService service)
        {
            await _repository.AddAsync(service);
            return Ok(service);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, MedicalService service)
        {
            if (id != service.Id) return BadRequest();
            await _repository.UpdateAsync(service);
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
