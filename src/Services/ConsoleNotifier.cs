namespace ITCS3112InventoryManagementSystem.Services;

public class ConsoleNotifier : Notifier
{
    public override void SendNotification(string message)
    {
        Console.WriteLine($"[SIMULATED CONSOLE MSG]: {message}");
        LogNotification(message);
    }
}