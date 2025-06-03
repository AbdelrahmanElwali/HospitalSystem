using Hospital.Domain.Interfaces;
using Hospital.Domain.Users.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly IInventoryItemRepository _repository;

        public InventoryItemController(IInventoryItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryItem item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _repository.AddAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] InventoryItem item)
        {
            if (!ModelState.IsValid || id != item.Id) return BadRequest();
            await _repository.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return NotFound();
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
