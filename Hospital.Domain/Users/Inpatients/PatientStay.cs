using Hospital.Domain.Users.Rooms;

namespace Hospital.Domain.Users.Inpatients
{
    public class PatientStay : EntityBase
    {
        public Guid PatientId { get; set; }
        public Guid BedId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public decimal Cost { get; set; }
        public decimal Discount { get; set; }
        public decimal Paid { get; set; }

        public Bed? Bed { get; set; }
    }
}
