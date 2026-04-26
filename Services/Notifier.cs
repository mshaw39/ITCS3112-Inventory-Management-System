using ITCS3112InventoryManagementSystem.Contracts;

namespace ITCS3112InventoryManagementSystem.Services;

public abstract class Notifier : INotifier
{
    public List <string> NotificationLog {get; set;} = new List<string>();
    
    //child classes will use their own message
    public abstract void SendNotification(string message);

    public void LogNotification(string message)
    {
        //sends message with current date/time
        NotificationLog.Add($"[{DateTime.Now}] {message}");
    }
}