using Hospital.Application.Interfaces;
using Hospital.Domain.Users.HumanResources;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSalaryController : ControllerBase
    {
        private readonly IEmployeeSalaryRepository _repository;

        public EmployeeSalaryController(IEmployeeSalaryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var salary = await _repository.GetByIdAsync(id);
            return salary == null ? NotFound() : Ok(salary);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeSalary salary)
        {
            await _repository.AddAsync(salary);
            return Ok(salary);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, EmployeeSalary salary)
        {
            if (id != salary.Id) return BadRequest();
            await _repository.UpdateAsync(salary);
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
