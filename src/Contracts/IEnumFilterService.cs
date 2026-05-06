using System.Collections.Generic;
using ITCS3112InventoryManagementSystem.Domain;

namespace ITCS3112InventoryManagementSystem.Contracts;

public interface IEnumFilterService
{
    public List<Item> FilterByItemType(ItemTypeEnum itemType);
    public List<Item> FilterBySeasonal(SeasonalEnum season);
}