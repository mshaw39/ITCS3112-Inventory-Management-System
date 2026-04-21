using ITCS3112InventoryManagementSystem.Contracts;
using ITCS3112InventoryManagementSystem.Domain;
namespace ITCS3112InventoryManagementSystem.Services;

public class CustomerService : ICustomerService
{
    private readonly UserService _userService;

    public CustomerService(UserService userService)
    {
        _userService = userService;
    }

    public void ReserveItem(Item item)
    {
        throw new NotImplementedException();
    }
}