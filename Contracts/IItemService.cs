using ITCS3112InventoryManagementSystem.Domain;
namespace ITCS3112InventoryManagementSystem.Contracts;

/// <summary>
/// This interface represents an item service that adds, retrieves, updates, and removes items
/// for the inventory management system.
/// </summary>
public interface IItemService
{
    /// <summary>
    /// Creates a new item and adds it to the <see cref="IItemRepository"/>.
    /// </summary>
    /// <param name="item">The item object being added.</param>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="item"/> is not null.
    /// Postconditions:
    /// The item is added and can be retrieved using <see cref="GetItem(Item)"/> or <see cref="ListAllItems()"/>.
    /// </remarks>
    public void NewItem(Item item);

    /// <summary>
    /// Retrieves an item from the <see cref="IItemRepository"/> by its unique identifier.
    /// </summary>
    /// <param name="item">The item object being retrieved.</param>
    /// <returns>The item if found; otherwise, null.</returns>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="item"/> is not null and has a valid ID number.
    /// Postconditions:
    /// The item is returned if found; otherwise, null.
    /// </remarks>
    public Item? GetItem(Item item);

    /// <summary>
    /// Lists all items from the <see cref="IItemRepository"/>.
    /// </summary>
    /// <returns>A list of all items; otherwise, an empty list if no items are found.</returns>
    /// <remarks>
    /// Preconditions:
    /// None.
    /// Postconditions:
    /// Returns all items. If no items are found, an empty list is returned.
    /// </remarks>
    public List<Item> ListAllItems();

    /// <summary>
    /// Updates an existing item in the <see cref="IItemRepository"/>.
    /// </summary>
    /// <param name="item">The item object being updated.</param>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="item"/> is not null and has a valid ID number.
    /// Postconditions:
    /// The item is updated if found; otherwise, no changes are made to the repository.
    /// </remarks>
    public void UpdateItem(Item item);

    /// <summary>
    /// Removes an item from the <see cref="IItemRepository"/> by its unique identifier.
    /// </summary>
    /// <param name="item">The item object being removed.</param>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="item"/> is not null and has a valid ID number.
    /// Postconditions:
    /// The item is removed if found; otherwise, no changes are made to the repository.
    /// </remarks>
    public void RemoveItem(Item item);
}