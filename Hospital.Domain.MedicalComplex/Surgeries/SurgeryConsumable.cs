using Hospital.Domain.MedicalComplex;

namespace Hospital.Domain.MedicalComplexes.Surgeries;
/// <summary>
/// Represents a record of medical supplies or consumables used during a specific operation,
/// including item details, quantity, cost, and related inventory information.
/// </summary>
public class SurgeryConsumable : EntityBase
{

    /// <summary>
    /// The date the consumable was used.
    /// </summary>
    public DateOnly DateUsed { get; set; }

    /// <summary>
    /// The time the consumable was used.
    /// </summary>
    public TimeOnly TimeUsed { get; set; }
    /// <summary>
    /// Identifier of the item (consumable or supply) used.
    /// </summary>
    public int ItemId { get; set; }

    /// <summary>
    /// Unit of measurement for the item (e.g., piece, ml, box).
    /// </summary>
    public string Unit { get; set; }

    /// <summary>
    /// Quantity of the item that was used.
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Sale price of the item at the time it was used.
    /// </summary>
    public decimal SalePrice { get; set; }

    /// <summary>
    /// Profit made from using this item, if applicable.
    /// </summary>
    public decimal Profit { get; set; }

    /// <summary>
    /// Identifier of the warehouse from which the item was drawn.
    /// </summary>
    public int WarehouseId { get; set; }

    /// <summary>
    /// Identifier of the staff member or user who recorded the usage.
    /// </summary>
    public Guid UsedByUserId { get; set; }

    /// <summary>
    /// Additional notes related to the usage of the consumable.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Identifier of the operation during which this consumable was used.
    /// </summary>
    public Guid SurgeryId { get; set; }
}

