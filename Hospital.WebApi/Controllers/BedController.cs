using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Inpatients;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedController : ControllerBase
    {
        private readonly IBedRepository _repository;

        public BedController(IBedRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("room/{roomId}")]
        public async Task<IActionResult> GetByRoomId(Guid roomId)
        {
            var beds = await _repository.GetByRoomIdAsync(roomId);
            return Ok(beds);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var bed = await _repository.GetByIdAsync(id);
            return bed == null ? NotFound() : Ok(bed);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bed bed)
        {
            await _repository.AddAsync(bed);
            return Ok(bed);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Bed bed)
        {
            if (id != bed.Id) return BadRequest();
            await _repository.UpdateAsync(bed);
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
