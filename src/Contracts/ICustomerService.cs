using ITCS3112InventoryManagementSystem.Domain;
namespace ITCS3112InventoryManagementSystem.Contracts;

/// <summary>
/// This interface represents a customer service that reserves items 
/// for customers within the inventory management system.
/// </summary>
public interface ICustomerService
{
    /// <summary>
    /// Reserves an item for a customer.
    /// </summary>
    /// <param name="item">The item to be reserved.</param>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="item"/> is not null and has a valid identifier.
    /// Postconditions:
    /// The item is reserved for the customer if it is available; 
    /// otherwise, no changes are made to the <see cref="IItemRepository"/>.
    /// </remarks>
    public void ReserveItem(int itemId, int quantityToReserve);
}