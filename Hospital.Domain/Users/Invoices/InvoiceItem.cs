using System.ComponentModel.DataAnnotations;

namespace Hospital.Domain.Users.Invoices
{
    public class InvoiceItem :EntityBase
    {
        public int InvoiceId { get; set; }

        public Invoice? Invoices { get; set; }

        [Required]
        public string? ServiceName { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }

}
