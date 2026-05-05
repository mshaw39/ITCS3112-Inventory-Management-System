using ITCS3112InventoryManagementSystem.Contracts;
using ITCS3112InventoryManagementSystem.Domain;

namespace ITCS3112InventoryManagementSystem.Services;

public abstract class Notifier : INotifier
{
    public List <NotificationMessage> NotificationLog {get; set;} = new List<NotificationMessage>();
    
    //child classes will use their own message
    public abstract void SendNotification(string message);

    public void LogNotification(string message)
    {
        //sends message with current date/time
        NotificationLog.Add(new NotificationMessage(message));
    }
}