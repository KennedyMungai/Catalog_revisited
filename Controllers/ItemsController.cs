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
}