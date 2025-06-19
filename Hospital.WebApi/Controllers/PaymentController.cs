using Hospital.Application.Interfaces;
using Hospital.Domain.Users.Payments;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _repository;

        public PaymentController(IPaymentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments = await _repository.GetAllAsync();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var payment = await _repository.GetByIdAsync(id);
            return payment == null ? NotFound() : Ok(payment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Payment payment)
        {
            await _repository.AddAsync(payment);
            return Ok(payment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Payment payment)
        {
            if (id != payment.Id)
                return BadRequest();

            await _repository.UpdateAsync(payment);
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
