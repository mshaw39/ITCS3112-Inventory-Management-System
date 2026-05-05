namespace ITCS3112InventoryManagementSystem.Domain;

public class Item
{
    public int ItemId { private set; get;}
    public string Name { set; get;}
    public int Quantity { set; get;}
    public ItemTypeEnum ItemType { set; get;}
    public string Location { set; get;}
    public SeasonalEnum Seasonal { set; get;}

    public Item(int itemId, string name, int quantity, ItemTypeEnum itemType, string location, SeasonalEnum seasonal)
    {
        ItemId = itemId;
        Name = name;
        Quantity = quantity;
        ItemType = itemType;
        Location = location;
        Seasonal = seasonal;
    }

    public void UpdateItem(int itemId, string name, int quantity, ItemTypeEnum itemType, string location, SeasonalEnum seasonal)
    {
        ItemId = itemId;
        Name = name;
        Quantity = quantity;
        ItemType = itemType;
        Location = location;
        Seasonal = seasonal;
    }
}