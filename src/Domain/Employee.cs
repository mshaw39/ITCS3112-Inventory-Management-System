namespace ITCS3112InventoryManagementSystem.Domain;

public class Employee : User
{
    public Employee(int userId, string name) : base(userId, name)
    {
        Status = "Employee";
    }
}