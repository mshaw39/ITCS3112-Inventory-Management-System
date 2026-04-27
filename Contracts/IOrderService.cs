namespace ITCS3112InventoryManagementSystem.Contracts;

/// <summary>
/// Processes and manages inventory order.
/// Acts as a template for transactions related to stocks
/// within the system.
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Process of ordering stocks for specific item.
    /// </summary>
    /// <param name="itemId">
    /// Unique item identifier number in inventory system.
    /// </param>
    /// <param name="quantity"> The number if items to be ordered. </param>
    /// <remarks>
    /// Preconditions: itemId must exist in IItemRepository
    /// Postconditions: Stock levels are updated and notification is sent
    /// through INotifier.
    /// </remarks>
    void OrderStock (int itemId, int quantity);
    
    /// <summary>
    /// Cancels order and updates the repository (allowing control to
    /// manage ordering process).
    /// </summary>
    /// <param name="orderId">
    /// Unique order identifier number in inventory system.
    /// </param>
    /// <remarks>
    /// Preconditions: orderId must be of a valid, active order in place
    /// Postconditions: order will be marked canceled and repo is updated
    /// </remarks>
    void CancelOrder(int orderID);
}