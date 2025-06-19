namespace Hospital.Domain.Users.HumanResources
{
    public enum AdjustmentType
    {
        Bonus,
        Penalty
    }

    public class EmployeeAdjustment : EntityBase
    {
        public Guid EmployeeId { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public AdjustmentType Type { get; set; }
    }
}
