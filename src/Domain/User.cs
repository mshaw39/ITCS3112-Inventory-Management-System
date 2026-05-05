namespace ITCS3112InventoryManagementSystem.Domain;

public class User
{
    public int UserId { get; set;}
    public string Name { get; set; }
    public string Status { get; set; }

    public User(int userId, string name)
    {
        UserId = userId;
        Name = name;
        Status = "User";
    }

    public void UpdateUser(int userId, string name, string status)
    {
        UserId = userId;
        Name = name;
        Status = status;
    }
}