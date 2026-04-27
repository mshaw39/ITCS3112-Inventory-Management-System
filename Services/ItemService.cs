using ITCS3112InventoryManagementSystem.Contracts;
using ITCS3112InventoryManagementSystem.Domain;
namespace ITCS3112InventoryManagementSystem.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public void NewItem(Item item)
    {
        _itemRepository.AddItem(item);
    }

    public Item? GetItem(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null.");
        }

        return _itemRepository.GetItemById(item.ItemId);
    }

    public List<Item> ListAllItems()
    {
        return _itemRepository.GetAllItems();
    }

    public void UpdateItem(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null.");
        }

        var itemUpdate = _itemRepository.GetItemById(item.ItemId);
        
        if (itemUpdate == null)
        {
            throw new ArgumentNullException(nameof(item), $"No item found with ID {item.ItemId}.");
        }

        itemUpdate.UpdateItem(item.ItemId, item.Quantity, item.ItemType, item.Location, item.Seasonal);
    }

    public void RemoveItem(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null.");
        }
        
        _itemRepository.RemoveItemById(item.ItemId);
    }
}
