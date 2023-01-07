using BookStore.Core.WineCollection.Models;
using MongoDB.Driver;

namespace BookStore.Core.WineCollection.Services;

public class WineServices : IWineServices
{

    private readonly IMongoCollection<Wine> _wine;

    public WineServices(IDbClient dbClient)
    {
        _wine = dbClient.GetWineCollection();
    }
    
    public List<Wine> GetWines()
    {
        return _wine.Find(wine => true).ToList();
    }

    public Wine AddWine(Wine wine)
    {
        _wine.InsertOne(wine);
        return wine;
    }

    public Wine GetWine(string id) => _wine.Find(wine => wine.Id == id).First();

    public void DeleteWine(string id) => _wine.DeleteOne(wine => wine.Id == id);

    public Wine UpdateWine(Wine wine)
    {
        GetWine(wine.Id);
        _wine.ReplaceOne(w => w.Id == wine.Id, wine);
        return wine;
    }
}