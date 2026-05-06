namespace ITCS3112InventoryManagementSystem.Contracts;

/// <summary>
/// This interface represents a customer service that reserves items 
/// for customers within the inventory management system.
/// </summary>
public interface ICustomerService
{
    /// <summary>
    /// Reserves a specific quantity of an item for a customer by its ID.
    /// </summary>
    /// <param name="itemId">The ID of the item to be reserved.</param>
    /// <param name="quantityToReserve">The amount to reserve.</param>
    /// <returns>True if the reservation was successful, false otherwise.</returns>
    public bool ReserveItem(int itemId, int quantityToReserve);
}