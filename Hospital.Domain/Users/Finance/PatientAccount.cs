namespace Hospital.Domain.Users.Finance
{
    public class PatientAccount : EntityBase
    {
        public Guid PatientId { get; set; }

        public decimal TotalCost { get; set; }
        public decimal Discount { get; set; }
        public decimal Paid { get; set; }

        public decimal Remaining => (TotalCost - Discount) - Paid;
    }
}
