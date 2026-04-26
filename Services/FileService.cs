using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using ITCS3112InventoryManagementSystem.Contracts;
using ITCS3112InventoryManagementSystem.Domain;

namespace ITCS3112InventoryManagementSystem.Services;

public class FileService : IFileService
{
    public List<Item> InventoryData { get; set; } = new List<Item>();

    public List<Item> readFile(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"[Warning] File not found at: {filePath}. Starting with an empty inventory.");
                return null;
            }

            string jsonContent = File.ReadAllText(filePath);
            
            List<Item>? loadedData = JsonSerializer.Deserialize<List<Item>>(jsonContent);
            if (loadedData != null)
            {
                InventoryData = loadedData;
            }
            
            Console.WriteLine($"[Success] Read {InventoryData.Count} items from the file.");
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine($"[Error] Failed to parse the inventory file. The data might be corrupted: {jsonEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Error] An unexpected error occurred while reading the file: {ex.Message}");
        }

        return InventoryData;
    }

    public void saveFile(string filePath)
    {
        try
        {
            // Ensure the directory exists before attempting to write to it.
            string? directoryPath = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrWhiteSpace(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Serialize the inventory list into a JSON string with indentation for readability.
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonContent = JsonSerializer.Serialize(InventoryData, options);

            // Write the JSON string to the specified file path.
            File.WriteAllText(filePath, jsonContent);
            Console.WriteLine($"[Success] Inventory data saved to {filePath}.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"[Error] You do not have permission to write to this file path: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Error] An unexpected error occurred while saving the file: {ex.Message}");
        }
    }
}