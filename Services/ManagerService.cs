using System;
using System.Collections.Generic;
using ITCS3112InventoryManagementSystem.Contracts;
using ITCS3112InventoryManagementSystem.Domain;

namespace ITCS3112InventoryManagementSystem.Services;

public class ManagerService : IManagerService
{
    private readonly UserService _userService;
    private readonly IItemRepository _itemRepository;
    private readonly HashSet<int> _activeAutoOrders; 

    public ManagerService(UserService userService, IItemRepository itemRepository)
    {
        _userService = userService;
        _itemRepository = itemRepository;
        _activeAutoOrders = new HashSet<int>();
    }

    public void AutoOrder(int orderId)
    {
        if (_activeAutoOrders.Add(orderId))
        {
            Console.WriteLine($"[ManagerService] Auto-order for Item #{orderId} activated.");
        }
        else
        {
            Console.WriteLine($"[ManagerService] Warning: Auto-order for Item #{orderId} is already active.");
        }
    }

    public void CancelOrder(int orderId)
    {
        Console.WriteLine($"[ManagerService] Standard Order #{orderId} has been successfully canceled.");
    }

    public void RemoveAutoOrder(int orderId)
    {
        if (_activeAutoOrders.Remove(orderId))
        {
            Console.WriteLine($"[ManagerService] Auto-order for Item #{orderId} has been deactivated.");
        }
        else
        {
            Console.WriteLine($"[ManagerService] Error: Auto-order #{orderId} was not found.");
        }
    }

    public void ViewActiveAutoOrders()
    {
        if (_activeAutoOrders.Count == 0)
        {
            Console.WriteLine("No active auto-orders.");
            return;
        }
        
        Console.WriteLine("--- Active Auto-Orders ---");
        foreach (int id in _activeAutoOrders)
        {
            Console.WriteLine($"- Tracking Item ID: {id}");
        }
    }

    // Scans tracked items and automatically adds 50 if they drop below 15
    public void TriggerAutoOrders()
    {
        foreach (int id in _activeAutoOrders)
        {
            Item? item = _itemRepository.GetItemById(id);
            if (item != null && item.Quantity < 15)
            {
                item.Quantity += 50;
                Console.WriteLine($"\n*** [SYSTEM ALERT] Item {id} stock dropped below 15! Auto-order triggered. 50 units added. New Stock: {item.Quantity} ***");
            }
        }
    }
}