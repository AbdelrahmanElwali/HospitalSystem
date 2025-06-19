namespace Hospital.Domain.Users.Surgery
{
    public class Surgery : EntityBase
    {
        public Guid PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }

        public ICollection<SurgeryStaff> Staff { get; set; }
        public ICollection<SurgerySupply> Supplies { get; set; }
    }
}
