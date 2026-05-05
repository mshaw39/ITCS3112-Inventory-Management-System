using ITCS3112InventoryManagementSystem.Domain;
namespace ITCS3112InventoryManagementSystem.Contracts;

/// <summary>
/// This interface represents a repository that stores and retrieves items
/// for the inventory management system.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Adds a user to the repository.
    /// </summary>
    /// <param name="user">The user object being added.</param>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="user"/> is not null.
    /// Postconditions:
    /// The user is added and can be retrieved using <see cref="GetUserById(int)"/> or <see cref="ListAllUsers()"/>. 
    /// </remarks>
    public void AddUser(User user);

    /// <summary>
    /// Retrieves a user from the repository by its unique identifier.
    /// </summary>
    /// <param name="userId">The user's ID.</param>
    /// <returns>The user if found; otherwise, null.</returns>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="userId"/> is a valid identifier and not null.
    /// Postconditions:
    /// The user is returned if found; otherwise, null.
    /// </remarks>
    public User? GetUserById(int userId);

    /// <summary>
    /// Retrieves all users within the repository.
    /// </summary>
    /// <returns>A list of all users; otherwise, an empty list if no users are found.</returns>
    /// <remarks>
    /// Preconditions:
    /// None.
    /// Postconditions:
    /// Returns all users. If no users are found, an empty list is returned.
    /// </remarks>
    public List<User> ListAllUsers();

    /// <summary>
    /// Removes a user from the repository by its unique identifier.
    /// </summary>
    /// <param name="userId">The user's ID.</param>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="userId"/> is a valid identifier and not null.
    /// Postconditions:
    /// The user is removed if found; otherwise, no changes are made to the repository.
    /// </remarks>
    public void RemoveUserById(int userId);
}