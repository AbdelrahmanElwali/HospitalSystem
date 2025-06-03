using Hospital.Domain.Users.Appointmets;
using Hospital.Domain.Users.Discharge;
using Hospital.Domain.Users.Invoices;
using Hospital.Domain.Users.Prescriptions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Domain.Users.Patients
{
    public class Patient : EntityBase
    {
        [Required]
        public string FullName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        public bool IsAdmitted { get; set; }

        public string Status { get; set; }

        // Relationships
        public ICollection<Appointment> Appointments { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
        public ICollection <DischargeSummary> DischargeSummary { get; set; }
    }

}
