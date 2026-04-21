using ITCS3112InventoryManagementSystem.Contracts;
namespace ITCS3112InventoryManagementSystem.Services;

public class ManagerService : IManagerService
{
    private readonly UserService _userService;

    public ManagerService(UserService userService)
    {
        _userService = userService;
    }

    public void AutoOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public void CancelOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public void RemoveAutoOrder(int orderId)
    {
        throw new NotImplementedException();
    }
}