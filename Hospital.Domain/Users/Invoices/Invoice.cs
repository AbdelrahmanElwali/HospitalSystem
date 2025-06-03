using Hospital.Domain.Users.Patients;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Domain.Users.Invoices

{
    public class Invoice :EntityBase
    {
        [Required]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public DateTime DateIssued { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }

}
