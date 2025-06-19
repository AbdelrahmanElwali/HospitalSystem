namespace Hospital.Domain.Users.Payments
{
    public class Payment : EntityBase
    {

        public Guid? SurgeryId { get; set; }
        public Guid? PatientStayId { get; set; }

        public decimal Total { get; set; }
        public decimal Paid { get; set; }

        public decimal Remaining => Total - Paid;
    }
}
