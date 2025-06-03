using Hospital.Domain.Interfaces;
using Hospital.Domain.Users.Patients;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hospital.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientRepository.GetAllAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Patient patient)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _patientRepository.AddAsync(patient);
            return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Patient patient)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != patient.Id) return BadRequest("ID mismatch");

            await _patientRepository.UpdateAsync(patient);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null) return NotFound();

            await _patientRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
