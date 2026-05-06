using System;
using ITCS3112InventoryManagementSystem.Contracts;

namespace ITCS3112InventoryManagementSystem.Services;

public class OrderService : IOrderService
{
    private readonly INotifier _notifier;
    private readonly IItemRepository _itemRepository;
    public int orderID { get; set; }

    // Inject both the Notifier Strategy and the ItemRepository
    public OrderService(INotifier notifier, IItemRepository itemRepository)
    {
        _notifier = notifier;
        _itemRepository = itemRepository;
        orderID = new Random().Next(10000, 99999); // Generate a random 5-digit order ID
    }

    public void OrderStock(int itemId, int quantity)
    {
        var item = _itemRepository.GetItemById(itemId);
        if (item != null)
        {
            // increase the stock
            item.Quantity += quantity;
            Console.WriteLine($"[OrderService] Order #{orderID} fulfilled. Added {quantity} units to Item {itemId}. New Stock: {item.Quantity}");
            
            // Send the notification using the injected strategy
            _notifier.SendNotification($"Order #{orderID} placed for item '{item.Name}' (ID: {itemId}), quantity {quantity}.");
        }
        else
        {
            Console.WriteLine($"[OrderService] Error: Item ID {itemId} not found in inventory.");
        }
    }

    public void CancelOrder(int orderID)
    {
        Console.WriteLine($"Order #{orderID} has been cancelled");
        _notifier.SendNotification($"Order #{orderID} Cancelled");
    }
}