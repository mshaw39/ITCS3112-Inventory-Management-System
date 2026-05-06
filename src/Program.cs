using System;
using System.Collections.Generic;
using System.Linq;
using ITCS3112InventoryManagementSystem.Contracts;
using ITCS3112InventoryManagementSystem.Domain;
using ITCS3112InventoryManagementSystem.Repositories;
using ITCS3112InventoryManagementSystem.Services;

namespace ITCS3112InventoryManagementSystem;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("  Welcome to the Inventory Management System!   ");
        Console.WriteLine("==================================================");

        // Initialize system requirements
        FileService fileService = new FileService();
        IItemRepository itemRepository = ItemRepository.GetInstance();
        IUserRepository userRepository = new UserRepository();

        IItemService itemService = new ItemService(itemRepository);
        UserService userService = new UserService(userRepository);
        
        // Initialize the new Enum Filter Service
        IEnumFilterService enumFilterService = new EnumFilterService(itemService);

        // Instantiate the Role Services
        ICustomerService customerService = new CustomerService(userService, itemRepository);
        IEmployeeService employeeService = new EmployeeService(userService, itemRepository);
        ManagerService managerService = new ManagerService(userService, itemRepository);

        // Read file and store to runtime inventory
        Console.Write("\nEnter inventory file path (Press Enter for default '~/../../docs/Inventory.json'): ");
        string? userInput = Console.ReadLine();
        string filePath = string.IsNullOrWhiteSpace(userInput) ? "../../../docs/Inventory.json" : userInput;

        List<Item> loadedItems = fileService.ReadFile(filePath);
        if (loadedItems != null)
        {
            foreach (Item item in loadedItems)
            {
                try
                {
                    itemService.NewItem(item);
                }
                catch (ArgumentException)
                {
                }
            }
        }
        else
        {
            Console.WriteLine("File is empty!");
        }

        // Populate user service with our mock users
        User aliceManager = new Manager(1, "Alice Admin");
        User bobEmployee = new Employee(2, "Bob Worker");
        User charlieCustomer = new Customer(3, "Charlie Shopper");

        userService.NewUser(aliceManager);
        userService.NewUser(bobEmployee);
        userService.NewUser(charlieCustomer);

        // application loop
        bool appIsRunning = true;
        User currentUser = null;

        while (appIsRunning)
        {
            if (currentUser == null)
            {
                Console.WriteLine("\n--- Please Select a User Profile ---");
                Console.WriteLine("1. Login as Manager  (Alice)");
                Console.WriteLine("2. Login as Employee (Bob)");
                Console.WriteLine("3. Login as Customer (Charlie)");
                Console.WriteLine("4. Save and Exit Program");
                Console.Write("Choice (1-4): ");
                string? loginChoice = Console.ReadLine();

                if (loginChoice == "1") currentUser = aliceManager;
                else if (loginChoice == "2") currentUser = bobEmployee;
                else if (loginChoice == "3") currentUser = charlieCustomer;
                else if (loginChoice == "4")
                {
                    appIsRunning = false;
                    continue;
                }
                else Console.WriteLine("Invalid selection. Try again.");

                if (currentUser != null)
                {
                    Console.WriteLine(
                        $"\n>>> Welcome, {currentUser.Name}! You are logged in as: {currentUser.Status} <<<");
                }

                continue;
            }

            // --- DYNAMIC MENU GENERATION ---
            Console.WriteLine("\n================ MAIN MENU ================");

            // Option 1 and 2 are shared by everyone
            List<string> menuOptions = new List<string> 
            { 
                "View Full Inventory",
                "Filter Inventory by Category"
            };

            // Manager gets full administrative access
            if (currentUser is Manager)
            {
                menuOptions.Add("Add New Item (ItemService)");
                menuOptions.Add("Update Item Quantity (ItemService)");
                menuOptions.Add("Manage Auto-Orders (ManagerService)");
                menuOptions.Add("View All Users (UserService)");
                menuOptions.Add("Order Item Stock (OrderService)");
            }
            // Employee gets operations access
            else if (currentUser is Employee)
            {
                menuOptions.Add("Request Low-Stock Order (EmployeeService)");
                menuOptions.Add("View All Users (UserService)");
                menuOptions.Add("Order Item Stock (OrderService)");
            }
            // Customer gets public access
            else if (currentUser is Customer)
            {
                menuOptions.Add("Reserve an Item (CustomerService)");
            }

            menuOptions.Add("Log Out");
            menuOptions.Add("Save and Exit");
            // End of customized menu creation

            // Display of custom menu
            for (int i = 0; i < menuOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menuOptions[i]}");
            }

            Console.Write($"Please select an option (1-{menuOptions.Count}): ");

            if (!int.TryParse(Console.ReadLine(), out int choiceIndex) || choiceIndex < 1 ||
                choiceIndex > menuOptions.Count)
            {
                Console.WriteLine("[Error] Invalid selection.");
                continue;
            }

            string selectedOption = menuOptions[choiceIndex - 1];
            Console.WriteLine();


            switch (selectedOption)
            {
                case "View Full Inventory":
                    List<Item> items = itemService.ListAllItems();
                    Console.WriteLine($"--- Current Inventory ({items.Count} items) ---");
                    foreach (Item item in items.OrderBy(i => i.ItemId))
                    {
                        Console.WriteLine(
                            $"[ID: {item.ItemId}] {item.Name,-35} | Type: {item.ItemType,-20} | Qty: {item.Quantity,-8} | Loc: {item.Location,-20} | Season: {item.Seasonal}");
                    }

                    break;

                case "Filter Inventory by Category":
                    Console.WriteLine("1. Filter by Item Type");
                    Console.WriteLine("2. Filter by Season");
                    Console.Write("Choice: ");
                    string? filterChoice = Console.ReadLine();

                    List<Item> filteredItems = new List<Item>();

                    if (filterChoice == "1")
                    {
                        Console.WriteLine("\n--- Select Item Type ---");
                        foreach (ItemTypeEnum type in Enum.GetValues(typeof(ItemTypeEnum)))
                        {
                            Console.WriteLine($"{(int)type}. {type}");
                        }
                        Console.Write("Enter Type Number: ");
                        if (int.TryParse(Console.ReadLine(), out int typeSelection) && Enum.IsDefined(typeof(ItemTypeEnum), typeSelection))
                        {
                            filteredItems = enumFilterService.FilterByItemType((ItemTypeEnum)typeSelection);
                        }
                        else { Console.WriteLine("[Error] Invalid selection."); }
                    }
                    else if (filterChoice == "2")
                    {
                        Console.WriteLine("\n--- Select Season ---");
                        foreach (SeasonalEnum season in Enum.GetValues(typeof(SeasonalEnum)))
                        {
                            Console.WriteLine($"{(int)season}. {season}");
                        }
                        Console.Write("Enter Season Number: ");
                        if (int.TryParse(Console.ReadLine(), out int seasonSelection) && Enum.IsDefined(typeof(SeasonalEnum), seasonSelection))
                        {
                            filteredItems = enumFilterService.FilterBySeasonal((SeasonalEnum)seasonSelection);
                        }
                        else { Console.WriteLine("[Error] Invalid selection."); }
                    }
                    else
                    {
                        Console.WriteLine("[Error] Invalid choice.");
                    }

                    if (filteredItems.Count > 0)
                    {
                        Console.WriteLine($"\n--- Filtered Inventory ({filteredItems.Count} items) ---");
                        foreach (Item item in filteredItems.OrderBy(i => i.ItemId))
                        {
                            Console.WriteLine(
                                $"[ID: {item.ItemId}] {item.Name,-35} | Type: {item.ItemType,-20} | Qty: {item.Quantity,-8} | Loc: {item.Location,-20} | Season: {item.Seasonal}");
                        }
                    }
                    else if (filterChoice == "1" || filterChoice == "2")
                    {
                        Console.WriteLine("\nNo items found for that category.");
                    }
                    break;

                case "View All Users (UserService)":
                    List<User> users = userService.ListAllUsers();
                    Console.WriteLine($"--- Registered Users ({users.Count}) ---");
                    foreach (User user in users)
                    {
                        Console.WriteLine($"[ID: {user.UserId}] {user.Name,-15} - Role: {user.Status}");
                    }

                    break;

                case "Add New Item (ItemService)":
                    try
                    {
                        Console.Write("Enter New Item ID (e.g., 2000): ");
                        int newId = int.Parse(Console.ReadLine() ?? "0");

                        Console.Write("Enter Item Name: ");
                        string newName = Console.ReadLine() ?? "Unknown Item";

                        Console.Write("Enter Quantity: ");
                        int newQty = int.Parse(Console.ReadLine() ?? "0");

                        Console.Write("Enter Location: ");
                        string newLoc = Console.ReadLine() ?? "Warehouse";

                        // Display of Item Type options for user to select from
                        Console.WriteLine("\n--- Select Item Type ---");
                        foreach (ItemTypeEnum type in Enum.GetValues(typeof(ItemTypeEnum)))
                        {
                            Console.WriteLine($"{(int)type}. {type}");
                        }

                        Console.Write("Enter Type Number: ");
                        int typeSelection = int.Parse(Console.ReadLine() ?? "0");
                        ItemTypeEnum selectedType = (ItemTypeEnum)typeSelection;

                        // Display of Seasonal Type options for user to select from
                        Console.WriteLine("\n--- Select Season ---");
                        foreach (SeasonalEnum season in Enum.GetValues(typeof(SeasonalEnum)))
                        {
                            Console.WriteLine($"{(int)season}. {season}");
                        }

                        Console.Write("Enter Season Number: ");
                        int seasonSelection = int.Parse(Console.ReadLine() ?? "0");
                        SeasonalEnum selectedSeason = (SeasonalEnum)seasonSelection;

                        // Create the item
                        Item newItem = new Item(newId, newName, newQty, selectedType, newLoc, selectedSeason);
                        itemService.NewItem(newItem);
                        Console.WriteLine($"\n[Success] {selectedType} Item '{newName}' (ID: {newId}) added!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Error] Could not add item: {ex.Message}");
                    }

                    break;

                case "Update Item Quantity (ItemService)":
                    try
                    {
                        Console.Write("Enter the Item ID to update: ");
                        int updateId = int.Parse(Console.ReadLine() ?? "0");

                        Item? foundItem = itemService.GetItem(updateId);

                        if (foundItem != null)
                        {
                            Console.WriteLine(
                                $"Current Quantity for '{foundItem.Name}' (ID {updateId}): {foundItem.Quantity}");
                            Console.Write("Enter NEW Quantity: ");
                            int updatedQty = int.Parse(Console.ReadLine() ?? "0");

                            foundItem.UpdateItem(foundItem.ItemId, foundItem.Name, updatedQty, foundItem.ItemType,
                                foundItem.Location, foundItem.Seasonal);
                            itemService.UpdateItem(foundItem);
                            Console.WriteLine("[Success] Quantity updated!");

                            managerService.TriggerAutoOrders();
                        }
                        else
                        {
                            Console.WriteLine($"[Error] Item {updateId} not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Error] Invalid input: {ex.Message}");
                    }

                    break;

                case "Reserve an Item (CustomerService)":
                    Console.Write("Enter the Item ID you wish to reserve: ");
                    if (int.TryParse(Console.ReadLine(), out int reserveId))
                    {
                        var itemName = itemRepository.GetItemById(reserveId).Name;

                        Console.Write("Enter the quantity you wish to reserve: ");
                        if (int.TryParse(Console.ReadLine(), out int reserveQty))
                        {
                            // Checks for outstanding auto order deliveries
                            managerService.TriggerAutoOrders();
                            // Reserves items for the customer
                            bool success = customerService.ReserveItem(reserveId, reserveQty);
                            // If the item has dipped below autoOrder threshold, order them again
                            managerService.TriggerAutoOrders();
                            
                            if (success)
                            {
                                INotifier notifier = new SMSNotifier();
                                notifier.SendNotification(
                                    $"Your order for {reserveQty}x of Item {itemName} is ready for pickup.");
                            }
                        }

                        else
                        {
                            Console.WriteLine("[Error] Invalid quantity format.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("[Error] Invalid ID format.");
                    }

                    break;

                case "Order Item Stock (OrderService)":
                    Console.Write("Enter the Item ID to order: ");
                    if (int.TryParse(Console.ReadLine(), out int orderItemId))
                    {
                        Console.Write("Enter the quantity to order: ");
                        if (int.TryParse(Console.ReadLine(), out int orderQty) && orderQty > 0)
                        {
                            // Alternative notifier type for Managers and Employees
                            INotifier notifier = new EmailNotifier();
                            // Inject the notifier and the repository into the OrderService
                            IOrderService orderService = new OrderService(notifier, itemRepository);
                            orderService.OrderStock(orderItemId, orderQty);
                        }
                        else
                        {
                            Console.WriteLine("[Error] Invalid quantity. Must be greater than 0.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("[Error] Invalid ID format.");
                    }

                    break;

                case "Request Low-Stock Order (EmployeeService)":
                    employeeService.RequestOrder();
                    break;

                case "Manage Auto-Orders (ManagerService)":
                    Console.WriteLine("A. View Active Auto-Orders");
                    Console.WriteLine("B. Create Auto-Order");
                    Console.WriteLine("C. Remove Auto-Order");
                    Console.WriteLine("D. Cancel Standard Order");
                    Console.Write("Choice: ");
                    string? mgrChoice = Console.ReadLine()?.ToUpper();

                    if (mgrChoice == "A")
                    {
                        managerService.ViewActiveAutoOrders();
                    }
                    else
                    {
                        Console.Write("Enter Item ID number: ");
                        if (int.TryParse(Console.ReadLine(), out int orderId))
                        {
                            if (mgrChoice == "B") managerService.AutoOrder(orderId);
                            else if (mgrChoice == "C") managerService.RemoveAutoOrder(orderId);
                            else if (mgrChoice == "D") managerService.CancelOrder(orderId);
                            else Console.WriteLine("[Error] Invalid choice.");
                        }
                    }

                    break;

                case "Log Out":
                    Console.WriteLine($"Logging out {currentUser.Name}...");
                    currentUser = null; // Triggers the login screen to reappear
                    break;

                case "Save and Exit":
                    appIsRunning = false;
                    break;
            }
        }

        // Save and Exit
        Console.WriteLine("\nSaving data...");
        fileService.InventoryData = itemService.ListAllItems();
        fileService.SaveFile(filePath);

        Console.WriteLine("Goodbye!");
    }
}