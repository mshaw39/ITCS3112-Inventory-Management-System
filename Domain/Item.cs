namespace ITCS3112InventoryManagementSystem.Domain;

public class Item
{
    public int ItemId { private set; get;}
    public int Quantity { set; get;}
    public ItemTypeEnum ItemType { set; get;}
    public string Location { set; get;}
    public SeasonalEnum Seasonal { set; get;}

    public Item(int itemId, int quantity, ItemTypeEnum itemType, string location, SeasonalEnum seasonal)
    {
        ItemId = itemId;
        Quantity = quantity;
        ItemType = itemType;
        Location = location;
        Seasonal = seasonal;
    }

    public void UpdateItem(int itemId, int quantity, ItemTypeEnum itemType, string location, SeasonalEnum seasonal)
    {
        ItemId = itemId;
        Quantity = quantity;
        ItemType = itemType;
        Location = location;
        Seasonal = seasonal;
    }
}