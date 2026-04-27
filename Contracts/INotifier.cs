namespace ITCS3112InventoryManagementSystem.Contracts;

    /// <summary>
    /// Interface for abstract notification class to notify different
    /// types of members about order information (Strategy Pattern). 
    /// </summary>
public interface INotifier
{
    /// <summary>
    /// Simulates sending notification to a particular user. 
    /// </summary>
    /// <param name="message"> The content/string that will be displayed. </param>
    /// <remarks>
    /// Preconditions: message cannot be null or empty (valid input).
    /// Postconditions: simulated message is printed. 
    /// </remarks>
    void SendNotification(string message);
    
    /// <summary>
    /// Serves as a record/ notification log and keeps the history of
    /// all sent notifications.
    /// </summary>
    /// <param name="message"> The content/string that will be displayed. </param>
    /// <remarks>
    /// Postconditions: Message is added to the internal log. 
    /// </remarks>
    void LogNotification(string message);
}