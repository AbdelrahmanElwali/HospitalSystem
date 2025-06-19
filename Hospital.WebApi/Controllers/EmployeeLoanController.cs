using Hospital.Application.Interfaces;
using Hospital.Domain.Users.HumanResources;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLoanController : ControllerBase
    {
        private readonly IEmployeeLoanRepository _repository;

        public EmployeeLoanController(IEmployeeLoanRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var loan = await _repository.GetByIdAsync(id);
            return loan == null ? NotFound() : Ok(loan);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeLoan loan)
        {
            await _repository.AddAsync(loan);
            return Ok(loan);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
