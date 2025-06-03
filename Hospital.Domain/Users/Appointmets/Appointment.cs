using Hospital.Domain.Users.Patients;
using System.ComponentModel.DataAnnotations;


namespace Hospital.Domain.Users.Appointmets
{
    public enum AppointmentStatus
    {
        Scheduled,
        Cancelled,
        Completed
    }

    public class Appointment : EntityBase
    {

        [Required]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public UserBase Doctor { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;
    }

}
