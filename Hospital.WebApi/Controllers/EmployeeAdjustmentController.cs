using Hospital.Application.Interfaces;
using Hospital.Domain.Users.HumanResources;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAdjustmentController : ControllerBase
    {
        private readonly IEmployeeAdjustmentRepository _repository;

        public EmployeeAdjustmentController(IEmployeeAdjustmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var adj = await _repository.GetByIdAsync(id);
            return adj == null ? NotFound() : Ok(adj);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeAdjustment adjustment)
        {
            await _repository.AddAsync(adjustment);
            return Ok(adjustment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
