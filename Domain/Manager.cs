namespace ITCS3112InventoryManagementSystem.Domain;

public class Manager : User
{
    public Manager(int userId, string name) : base(userId, name)
    {
        Status = "Manager";
    }
}