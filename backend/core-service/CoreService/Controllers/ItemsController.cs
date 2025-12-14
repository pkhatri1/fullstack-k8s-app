using CoreService.Data;
using CoreService.Domain.Entities;
using CoreService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;
    private readonly AppDbContext _db;

    public ItemsController(IItemService itemService, AppDbContext db)
    {
        _itemService = itemService;
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetItems()
    {
        var items = await _db.Items.ToListAsync();
        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem(ItemEntity item)
    {
        _db.Items.Add(item);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetItems), new { id = item.Id }, item);
    }
}

public class CreateItemRequest
{
    public string Name { get; set; } = string.Empty;
}
