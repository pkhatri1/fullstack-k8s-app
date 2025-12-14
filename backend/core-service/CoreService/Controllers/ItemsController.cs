using CoreService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_itemService.GetAll());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateItemRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest("Name is required.");

        var item = _itemService.Create(request.Name);
        return CreatedAtAction(nameof(Get), item);
    }
}

public class CreateItemRequest
{
    public string Name { get; set; } = string.Empty;
}
