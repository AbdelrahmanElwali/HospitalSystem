using Hospital.Domain.Users.Patients;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Domain.Users.Discharge
{
    public class DischargeSummary :EntityBase
    {
        [Required]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public UserBase Doctor { get; set; }

        [Required]
        public string SummaryText { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;
    }

}
