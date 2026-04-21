using ITCS3112InventoryManagementSystem.Contracts;
namespace ITCS3112InventoryManagementSystem.Services;

public class EmployeeService : IEmployeeService
{
    private readonly UserService _userService;

    public EmployeeService(UserService userService)
    {
        _userService = userService;
    }

    public void RequestOrder()
    {
        throw new NotImplementedException();
    }
}