using System.Diagnostics;
namespace Catalog.Controllers;

using System.Linq;
using Catalog.Dto;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IInMemItemsRepository _repository;

    public ItemsController(IInMemItemsRepository repository)
    {
        _repository = repository;
    }

    [HttpGet(Name = "Get All Items")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<ItemDto>> GetAllItemsEndpoint()
    {
        var items = _repository.GetItems().Select(item => item.AsDto());
        return Ok(items);
    }

    [HttpGet("{id}", Name = "Get Item")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ItemDto> GetItemEndpoint(Guid id)
    {
        var item = _repository.GetItem(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item.AsDto());
    }


    [HttpPost(Name = "Create Item")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<ItemDto> CreateItemEndpoint(CreateItemDto itemDto)
    {
        Item item = new()
        {
            Id = Guid.NewGuid(),
            Name = itemDto.Name,
            Price = itemDto.Price,
            CreatedDate = DateTimeOffset.UtcNow
        };

        _repository.CreateItem(item);

        return CreatedAtAction(nameof(GetItemEndpoint), new { id = item.Id }, item.AsDto());
    }

    [HttpPut("{id}", Name = "Update Item")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult UpdateItemEndpoint(Guid id, UpdateItemDto itemDto)
    {
        var existingItem = _repository.GetItem(id);

        if (existingItem is null)
        {
            return NotFound();
        }

        Item updatedItem = existingItem with
        {
            Name = itemDto.Name,
            Price = itemDto.Price
        };

        _repository.UpdateItem(updatedItem);

        return NoContent();
    }
}