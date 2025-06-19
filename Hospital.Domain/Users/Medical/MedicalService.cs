namespace Hospital.Domain.Users.MedicalServices
{
    public class MedicalService : EntityBase
    {
        public string? Name { get; set; } // كشف – تحليل – أشعة
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
