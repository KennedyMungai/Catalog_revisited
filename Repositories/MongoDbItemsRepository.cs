using Catalog.Entities;
using MongoDB.Driver;

namespace Catalog.Repositories;


public class MongoDbItemsRepository : IDbCRUDOperations
{
    private const string databaseName = "catalog";
    private const string collectionName = "items";

    private readonly IMongoCollection<Item> _itemsCollection;

    public MongoDbItemsRepository(IMongoClient mongoClient)
    {
        IMongoDatabase database = mongoClient.GetDatabase(databaseName);
        _itemsCollection = database.GetCollection<Item>(collectionName);
    }

    public void CreateItem(Item item)
    {
        throw new NotImplementedException();
    }

    public void DeleteItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public Item GetItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Item> GetItems()
    {
        throw new NotImplementedException();
    }

    public void UpdateItem(Item item)
    {
        throw new NotImplementedException();
    }
}