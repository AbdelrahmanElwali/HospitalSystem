namespace Hospital.Domain.Users.HumanResources
{
    public class EmployeeLoan : EntityBase
    {
        public Guid EmployeeId { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
