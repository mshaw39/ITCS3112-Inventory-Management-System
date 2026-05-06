using ITCS3112InventoryManagementSystem.Domain;

namespace ITCS3112InventoryManagementSystem.Contracts;

public interface IFileService
{
    public List<Item> ReadFile(string filePath);

    public void SaveFile(string filePath);
    
}