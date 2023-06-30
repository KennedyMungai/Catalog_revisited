using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly InMemItemsRepository _repository;

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
}