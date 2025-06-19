using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Inpatients;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaySupplyController : ControllerBase
    {
        private readonly IStaySupplyRepository _repository;

        public StaySupplyController(IStaySupplyRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{stayId}")]
        public async Task<IActionResult> GetByStayId(Guid stayId)
        {
            var items = await _repository.GetByStayIdAsync(stayId);
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Add(StaySupply supply)
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
