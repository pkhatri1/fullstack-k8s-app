using CoreService.Models;

namespace CoreService.Services.Interfaces;

public interface IItemService
{
    IEnumerable<Item> GetAll();
    Item Create(string name);
}
