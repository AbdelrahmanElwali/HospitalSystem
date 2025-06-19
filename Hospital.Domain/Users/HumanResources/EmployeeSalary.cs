namespace Hospital.Domain.Users.HumanResources
{
    public class EmployeeSalary : EntityBase
    {
        public Guid EmployeeId { get; set; } // from UserBase

        public decimal NetSalary { get; set; }
        public decimal Paid { get; set; }

        public DateTime Date { get; set; }
    }
}
