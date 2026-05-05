namespace ITCS3112InventoryManagementSystem.Domain;

public class Customer : User
{
    public Customer(int userId, string name) : base(userId, name)
    {
        Status = "Customer";
    }
}