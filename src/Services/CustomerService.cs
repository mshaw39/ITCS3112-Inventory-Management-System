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

    public bool ReserveItem(int itemId, int quantityToReserve)
    {
        if (quantityToReserve <= 0)
        {
            Console.WriteLine("[CustomerService] Error: Reservation quantity must be greater than zero.");
            return false;
        }

        Item? repoItem = _itemRepository.GetItemById(itemId);
        
        // Check if item exists and has ENOUGH stock
        if (repoItem != null && repoItem.Quantity >= quantityToReserve)
        {
            repoItem.Quantity -= quantityToReserve; 
            Console.WriteLine($"[CustomerService] Success: Reserved {quantityToReserve}x '{repoItem.Name}' (ID: {repoItem.ItemId}). Remaining stock: {repoItem.Quantity}");
            return true;
        }
        else if (repoItem != null)
        {
            Console.WriteLine($"[CustomerService] Failed: Not enough stock for '{repoItem.Name}'. Requested: {quantityToReserve}, Available: {repoItem.Quantity}");
            return false;
        }
        else
        {
            Console.WriteLine($"[CustomerService] Failed: Item ID {itemId} does not exist.");
            return false;
        }
    }
}