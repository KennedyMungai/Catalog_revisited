using Catalog.Entities;

namespace Catalog.Repositories;


public class InMemItemsRepository
{
    private readonly List<Item> items = new()
    {
        new Item
        {
            Id = Guid.NewGuid(),
            Name = "Potion",
            Price = 9,
            CreatedDate = DateTimeOffset.UtcNow
        },
        new Item
        {
            Id = Guid.NewGuid(),
            Name = "Iron Sword",
            Price = 20,
            CreatedDate = DateTimeOffset.UtcNow
        },
        new Item
        {
            Id = Guid.NewGuid(),
            Name = "Bronze Shield",
            Price = 15,
            CreatedDate = DateTimeOffset.UtcNow
        },
    };
}