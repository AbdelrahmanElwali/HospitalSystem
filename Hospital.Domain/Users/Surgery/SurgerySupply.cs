namespace Hospital.Domain.Users.Surgery
{
    public class SurgerySupply : EntityBase
    {
        public Guid SurgeryId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string UsedBy { get; set; }

        public Surgery Surgery { get; set; }
    }
}
