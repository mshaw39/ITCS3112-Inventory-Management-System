using System;
using System.Collections.Generic;
using System.Linq;
using ITCS3112InventoryManagementSystem.Contracts;
using ITCS3112InventoryManagementSystem.Domain;

namespace ITCS3112InventoryManagementSystem.Repositories;

public class ItemRepository : IItemRepository
{
    private static ItemRepository _instance = null;
    private readonly Dictionary<int, Item> _items;
    private ItemRepository()
    {
        _items = new Dictionary<int, Item>();
    }

    public static ItemRepository GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ItemRepository();
        }

        return _instance;
    }

    public void AddItem(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item cannot be null.");
        } 
        else if (_items.ContainsKey(item.ItemId)) 
        {
            throw new ArgumentException($"An item with ID {item.ItemId} already exists.");
        }

        _items[item.ItemId] = item;
    }

    public Item? GetItemById(int itemId)
    {
        _items.TryGetValue(itemId, out var item);
        return item;
    }

    public List<Item> GetAllItems()
    {
        return _items.Values.ToList();
    }

    public void RemoveItemById(int itemId)
    {
        if (!_items.ContainsKey(itemId))
        {
            throw new KeyNotFoundException($"No item found with ID {itemId}.");
        }
        
        _items.Remove(itemId);
    }
}