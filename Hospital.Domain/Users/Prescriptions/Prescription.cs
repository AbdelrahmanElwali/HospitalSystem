
using Hospital.Domain.Users.Patients;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Domain.Users.Prescriptions
{
    public class Prescription : EntityBase
    {

        [Required]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public UserBase Doctor { get; set; }

        public DateTime DateIssued { get; set; } = DateTime.UtcNow;

        [Required]
        public string MedicationDetails { get; set; }
    }

}
