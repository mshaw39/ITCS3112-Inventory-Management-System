using ITCS3112InventoryManagementSystem.Contracts;

namespace ITCS3112InventoryManagementSystem.Services;

public class OrderService : IOrderService
{
    private readonly INotifier _notifier;
    public int orderID { get; set; }

    public OrderService(INotifier notifier)
    {
        _notifier = notifier;
    }

    public void OrderStock(int itemId, int quantity)
    {
        Console.WriteLine($"Order #{orderID} for item {itemId} quantity {quantity}");
        _notifier.SendNotification($"Order #{orderID} placed for item {itemId} quantity {quantity}");
    }

    public void CancelOrder(int orderID)
    {
        Console.WriteLine($"Order #{orderID} has been cancelled");
        _notifier.SendNotification($"Order #{orderID} Cancelled");
    }
}