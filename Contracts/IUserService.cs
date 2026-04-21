using ITCS3112InventoryManagementSystem.Domain;
namespace ITCS3112InventoryManagementSystem.Contracts;

/// <summary>
/// This interface represents a user service that adds, retrieves, updates, and removes users
/// for the inventory management system.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Creates a new user and adds it to the <see cref="IUserRepository"/>. 
    /// </summary>
    /// <param name="user">The user object being added.</param>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="user"/> is not null.
    /// Postconditions:
    /// The user is added and can be retrieved using <see cref="GetUser(User)"/>.
    /// </remarks>
    public void NewUser(User user);

    /// <summary>
    /// Retrieves a user from the <see cref="IUserRepository"/> by its unique identifier. 
    /// </summary>
    /// <param name="user">The user object being retrieved.</param>
    /// <returns>The user if found; otherwise, null.</returns>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="user"/> is not null and has a valid ID number.
    /// Postconditions:
    /// The user is returned if found; otherwise, null.
    /// </remarks>
    public User? GetUser(User user);

    /// <summary>
    /// Lists all users from the <see cref="IUserRepository"/>.
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
    /// Updates an existing user in the <see cref="IUserRepository"/>.
    /// </summary>
    /// <param name="user">The user object being updated.</param>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="user"/> is not null and has a valid ID number.
    /// Postconditions:
    /// The user is updated if found; otherwise, no changes are made to the repository.
    /// </remarks>
    public void UpdateUser(User user);

    /// <summary>
    /// Removes a user from the <see cref="IUserRepository"/> by its unique identifier.
    /// </summary>
    /// <param name="user">The user object being removed.</param>
    /// <remarks>
    /// Preconditions:
    /// <paramref name="user"/> is not null and has a valid ID number.
    /// Postconditions:
    /// The user is removed if found; otherwise, no changes are made to the repository.
    /// </remarks>
    public void RemoveUser(User user);

}