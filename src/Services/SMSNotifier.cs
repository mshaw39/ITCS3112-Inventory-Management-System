namespace ITCS3112InventoryManagementSystem.Services;

public class SMSNotifier : Notifier
{
    public override void SendNotification(string message)
    {
        Console.WriteLine($"[SIMULATED SMS]: {message}");
        LogNotification(message);
    }
}