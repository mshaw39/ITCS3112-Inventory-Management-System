namespace ITCS3112InventoryManagementSystem.Domain;

public struct NotificationMessage
{
    public string Message { get; }
    public DateTime Timestamp { get; }

    public NotificationMessage(string message)
    {
        Message = message;
        Timestamp = DateTime.Now;
    }

    public override string ToString()
    {
        return $"[{Timestamp}] {Message}";
    }
}