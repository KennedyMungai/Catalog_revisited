namespace Catalog.Repositories;

using Catalog.Entities;

public interface IInMemItemsRepository
{
    Item GetItem(Guid id);
    IEnumerable<Item> GetItems();
    void CreateItem(Item item);
    void UpdateItem(Item item);
}