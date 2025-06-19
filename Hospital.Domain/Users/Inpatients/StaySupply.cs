namespace Hospital.Domain.Users.Inpatients
{
    public class StaySupply : EntityBase
    {
        public Guid PatientStayId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? UsedBy { get; set; }
        public string? Notes { get; set; }
    }
}
