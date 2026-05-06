using System.Collections.Generic;
using System.Linq;
using ITCS3112InventoryManagementSystem.Contracts;
using ITCS3112InventoryManagementSystem.Domain;

namespace ITCS3112InventoryManagementSystem.Services;

public class EnumFilterService : IEnumFilterService
{
    private readonly IItemService _itemService;

    public EnumFilterService(IItemService itemService)
    {
        _itemService = itemService;
    }

    public List<Item> FilterByItemType(ItemTypeEnum itemType)
    {
        return _itemService.ListAllItems()
            .Where(item => item.ItemType == itemType)
            .ToList();
    }

    public List<Item> FilterBySeasonal(SeasonalEnum season)
    {
        return _itemService.ListAllItems()
            .Where(item => item.Seasonal == season)
            .ToList();
    }
}