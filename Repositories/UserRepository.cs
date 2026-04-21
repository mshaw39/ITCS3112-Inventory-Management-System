using ITCS3112InventoryManagementSystem.Domain;
using ITCS3112InventoryManagementSystem.Contracts;
namespace ITCS3112InventoryManagementSystem.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users;

    public UserRepository()
    {
        _users = new List<User>();
    }

    public void AddUser(User user)
    {
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        _users.Add(user);
    }
    
    public User? GetUserById(int userId)
    {
        return _users.FirstOrDefault(u => u.UserId == userId);
    }

    public List<User> ListAllUsers()
    {
        return _users;
    }

    public void RemoveUserById(int userId)
    {
        _users.Remove(GetUserById(userId));
    }
}