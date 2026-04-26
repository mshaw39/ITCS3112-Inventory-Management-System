using ITCS3112InventoryManagementSystem.Domain;

namespace ITCS3112InventoryManagementSystem.Contracts;

public interface IFileService
{
    public List<Item> readFile(string filePath);

    public void saveFile(string filePath);
    
}