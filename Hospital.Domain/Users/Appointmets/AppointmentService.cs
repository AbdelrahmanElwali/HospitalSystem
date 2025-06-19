using Hospital.Domain;
using Hospital.Domain.Users.Appointmets;
using Hospital.Domain.Users.MedicalServices;

public class AppointmentService : EntityBase
{
    public Guid AppointmentId { get; set; }
    public Guid MedicalServiceId { get; set; }
    public Appointment? Appointment { get; set; }
    public MedicalService MedicalService { get; set; }
}

