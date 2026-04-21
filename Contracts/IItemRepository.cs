using ITCS3112InventoryManagementSystem.Domain;
namespace ITCS3112InventoryManagementSystem.Contracts;

/// <summary>
/// This interface represents a repository that stores and retrieves items
/// for the inventory management system.
/// </summary>
public interface IItemRepository
{
    /// <summary>
    /// Adds a new item to the repository.
    /// </summary>
    /// <param name="item">The item object being added.</param>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="item"/> is not null.
    /// Postconditions:
    /// The item is added and can be retrieved using <see cref="GetItemById(int)"/> or <see cref="GetAllItems()"/>.
    /// </remarks>
    public void AddItem(Item item);

    /// <summary>
    /// Retrieves an item from the repository by its unique identifier.
    /// </summary>
    /// <param name="itemId">The item's ID.</param>
    /// <returns>The item if found; otherwise, null.</returns>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="itemId"/> is a valid ID.
    /// Postconditions:
    /// The item is returned if found; otherwise, null.
    /// </remarks>
    public Item? GetItemById(int itemId);

    /// <summary>
    /// Retrieves all items from the repository.
    /// </summary>
    /// <returns>A list of all items; otherwise, an empty list if no items are found.</returns>
    /// <remarks>
    /// Preconditions:
    /// None.
    /// Postconditions:
    /// Returns all items. If no items are found, an empty list is returned.
    /// </remarks>
    public List<Item> GetAllItems();

    /// <summary>
    /// Removes an item from the repository by its unique identifier.
    /// </summary>
    /// <param name="itemId">The item's ID.</param>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="itemId"/> is a valid ID.
    /// Postconditions:
    /// The item is removed if found; otherwise, no changes are made to the repository.
    /// </remarks>
    public void RemoveItemById(int itemId);
}