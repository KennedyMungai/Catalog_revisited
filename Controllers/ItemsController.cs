namespace Catalog.Controllers;

using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IInMemItemsRepository _repository;

    public ItemsController(InMemItemsRepository repository)
    {
        _repository = repository;
    }

    [HttpGet(Name = "Get All Items")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Item>> GetAllItemsEndpoint()
    {
        var items = _repository.GetItems();
        return Ok(items);
    }

    [HttpGet("{id}", Name = "Get Item")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Item> GetItemEndpoint(Guid id)
    {
        var item = _repository.GetItem(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

}