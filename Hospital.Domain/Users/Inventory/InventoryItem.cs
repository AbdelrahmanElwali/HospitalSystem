using System.ComponentModel.DataAnnotations;

namespace Hospital.Domain.Users.Inventory
{
    public class InventoryItem :EntityBase
    {
        [Required]
        public string ItemName { get; set; }

        public int Quantity { get; set; }

        public string Unit { get; set; }

        public int ReorderLevel { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }

}
