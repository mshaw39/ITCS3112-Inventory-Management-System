using ITCS3112InventoryManagementSystem.Domain;
using ITCS3112InventoryManagementSystem.Contracts;
namespace ITCS3112InventoryManagementSystem.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void NewUser(User user)
    {
        _userRepository.AddUser(user);
    }

    public User? GetUser(User user)
    {
        return _userRepository.GetUserById(user.UserId);
    }

    public List<User> ListAllUsers()
    {
        return _userRepository.ListAllUsers();
    }

    public void UpdateUser(User user)
    {
        var UserUpdate = _userRepository.GetUserById(user.UserId);
        if (UserUpdate != null)
        {
            UserUpdate.UpdateUser(user.UserId, user.Name, user.Status);
        }
    }

    public void RemoveUser(User user)
    {
        _userRepository.RemoveUserById(user.UserId);
    }
}