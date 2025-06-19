using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Surgery;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurgeryStaffController : ControllerBase
    {
        private readonly ISurgeryStaffRepository _repository;

        public SurgeryStaffController(ISurgeryStaffRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{surgeryId}")]
        public async Task<IActionResult> GetBySurgeryId(Guid surgeryId)
        {
            var staff = await _repository.GetBySurgeryIdAsync(surgeryId);
            return Ok(staff);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SurgeryStaff staff)
        {
            await _repository.AddAsync(staff);
            return Ok(staff);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
