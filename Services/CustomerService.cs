using System;
using ITCS3112InventoryManagementSystem.Contracts;
using ITCS3112InventoryManagementSystem.Domain;
namespace ITCS3112InventoryManagementSystem.Services;

public class CustomerService : ICustomerService
{
    private readonly UserService _userService;
    private readonly IItemRepository _itemRepository; 

   
    public CustomerService(UserService userService, IItemRepository itemRepository)
    {
        _userService = userService;
        _itemRepository = itemRepository;
    }

    public void ReserveItem(Item item)
    {
       
        if (item == null)
        {
            Console.WriteLine("[CustomerService] Error: Item cannot be null.");
            return;
        }

        Item? repoItem = _itemRepository.GetItemById(item.ItemId);
        
        // Check if item exists and is in stock
        if (repoItem != null && repoItem.Quantity > 0)
        {
            repoItem.Quantity -= 1; // Reserving reduces available stock by 1
            Console.WriteLine($"[CustomerService] Success: Reserved 1x {repoItem.ItemType} (ID: {repoItem.ItemId}). Remaining stock: {repoItem.Quantity}");
        }
        else
        {
            Console.WriteLine($"[CustomerService] Failed: Item ID {item.ItemId} is either out of stock or does not exist.");
        }
    }
}