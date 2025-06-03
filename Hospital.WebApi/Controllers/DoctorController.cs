using Hospital.Domain.Interfaces;
using Hospital.Domain.Users.Doctors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
    
            await _doctorRepository.AddAsync(doctor);
            return CreatedAtAction(nameof(GetById), new { id = doctor.Id }, doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != doctor.Id) return BadRequest("ID mismatch");
            await _doctorRepository.UpdateAsync(doctor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null) return NotFound();

            await _doctorRepository.DeleteAsync(id);
            return NoContent();
        }


    }
}
