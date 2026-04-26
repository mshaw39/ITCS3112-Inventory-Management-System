using System;
using System.Collections.Generic;
using ITCS3112InventoryManagementSystem.Contracts;
using ITCS3112InventoryManagementSystem.Domain;
namespace ITCS3112InventoryManagementSystem.Services;

public class EmployeeService : IEmployeeService
{
    private readonly UserService _userService;
    private readonly IItemRepository _itemRepository; 
    public EmployeeService(UserService userService, IItemRepository itemRepository)
    {
        _userService = userService;
        _itemRepository = itemRepository;
    }

    public void RequestOrder()
    {
      
        List<Item> allItems = _itemRepository.GetAllItems();
        int itemsOrdered = 0;

        Console.WriteLine("[EmployeeService] Scanning inventory for low stock (Quantity < 15)...");
        
        foreach (Item item in allItems)
        {
            // If stock is below 15, automatically order a batch of 50
            if (item.Quantity < 15)
            {
                item.Quantity += 50; 
                itemsOrdered++;
                Console.WriteLine($"  -> Ordered 50 units of {item.ItemType} (ID: {item.ItemId}). New Stock: {item.Quantity}");
            }
        }

        if (itemsOrdered == 0)
        {
            Console.WriteLine("[EmployeeService] No items are low on stock. No orders placed.");
        }
        else
        {
            Console.WriteLine($"[EmployeeService] Restock complete. Orders placed for {itemsOrdered} unique items.");
        }
    }
}