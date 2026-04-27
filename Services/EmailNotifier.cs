namespace ITCS3112InventoryManagementSystem.Services;

public class EmailNotifier : Notifier
{
    public override void SendNotification(string message)
    {
        Console.WriteLine($"[SIMULATED EMAIL]: {message}");
        LogNotification(message);
    }
}