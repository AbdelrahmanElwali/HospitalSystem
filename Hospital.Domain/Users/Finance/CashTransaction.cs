namespace Hospital.Domain.Users.Finance
{
    public class CashTransaction : EntityBase
    {

        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public string Type { get; set; } // "In" or "Out"
        public string? Description { get; set; }

        public string? CashierName { get; set; }
    }
}
