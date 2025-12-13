using CoreService.Models;
using CoreService.Services.Interfaces;

namespace CoreService.Services;

public class ItemService : IItemService
{
    private static readonly List<Item> _items = new();

    public IEnumerable<Item> GetAll()
    {
        return _items;
    }

    public Item Create(string name)
    {
        var item = new Item
        {
            Id = Guid.NewGuid(),
            Name = name,
            CreatedAt = DateTime.UtcNow
        };

        _items.Add(item);
        return item;
    }
}
