namespace ITCS3112InventoryManagementSystem.Contracts;

/// <summary>
/// This interface represents an employee service that requests orders 
/// for the inventory management system.
/// </summary>
public interface IEmployeeService
{
    /// <summary>
    /// Requests an order for items that are low in stock.
    /// </summary>
    /// <remarks>
    /// Preconditions:
    /// None.
    /// Postconditions:
    /// An order is requested for items that are low in stock, 
    /// and the item's quantity is updated in the <see cref="IItemRepository"/>.
    /// </remarks>
    public void RequestOrder();
}