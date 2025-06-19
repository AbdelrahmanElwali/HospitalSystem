namespace Hospital.Domain.Users.Surgery
{
    public class SurgeryStaff : EntityBase
    {
        public Guid SurgeryId { get; set; }
        public string StaffId { get; set; } // ID of Doctor or Nurse
        public string Role { get; set; }

        public Surgery Surgery { get; set; }
    }
}
