using Hospital.Domain;
using Hospital.Domain.Users.Appointmets;
using Hospital.Domain.Users.Discharge;
using Hospital.Domain.Users.Prescriptions;
using System.ComponentModel.DataAnnotations;

public enum UserRole
{
    Admin,
    Doctor,
    Receptionist,
    Accountant,
    InventoryManager
}

public class UserBase : EntityBase
{

    [Required]
    public string FullName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    [Required]
    public UserRole Role { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsActive { get; set; } = true;

    // Relationships
    public ICollection<Appointment> AppointmentsAsDoctor { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
    public ICollection<DischargeSummary> DischargeSummaries { get; set; }
}

