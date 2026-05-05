namespace ITCS3112InventoryManagementSystem.Contracts;

/// <summary>
/// This interface represents a manager service that manages auto ordering, canceling orders, and removing auto orders
/// for the inventory management system.
/// </summary>
public interface IManagerService
{
    /// <summary>
    /// Places an automatic order for the specified order identifier.
    /// </summary>
    /// <param name="orderId">The order's ID.</param>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="orderId"/> is a valid order identifier.
    /// Postconditions:
    /// An automatic order is placed for the specified order identifier.
    /// </remarks>
    public void AutoOrder(int orderId);

    /// <summary>
    /// Cancels the order with the specified order identifier.
    /// </summary>
    /// <param name="orderId">The order's ID.</param>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="orderId"/> is a valid order identifier.
    /// Postconditions:
    /// The order is canceled if found; otherwise, no changes are made to the <see cref="IItemRepository"/>.
    /// </remarks>
    public void CancelOrder(int orderId);

    /// <summary>
    /// Removes the automatic order with the specified order identifier.
    /// </summary>
    /// <param name="orderId">The order's ID.</param>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="orderId"/> is a valid order identifier.
    /// Postconditions:
    /// The automatic order is removed if found; otherwise, no changes are made to the <see cref="IItemRepository"/>.
    /// </remarks>
    public void RemoveAutoOrder(int orderId);
}