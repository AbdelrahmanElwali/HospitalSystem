using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Surgery;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurgerySupplyController : ControllerBase
    {
        private readonly ISurgerySupplyRepository _repository;

        public SurgerySupplyController(ISurgerySupplyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{surgeryId}")]
        public async Task<IActionResult> GetBySurgeryId(Guid surgeryId)
        {
            var supplies = await _repository.GetBySurgeryIdAsync(surgeryId);
            return Ok(supplies);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SurgerySupply supply)
        {
            await _repository.AddAsync(supply);
            return Ok(supply);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
