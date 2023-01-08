using BookStore.Core.WineCollection.Models;
using MongoDB.Driver;

namespace BookStore.Core.WineCollection.Services;

public class WineProducerServices : IWineProducerServices
{

    private readonly IMongoCollection<WineProducer> _producer;

    public WineProducerServices(IDbClient dbClient)
    {
        _producer = dbClient.GetWineProducerCollection();
    }
    
    public List<WineProducer> GetProducers()
    {
        return _producer.Find(producer => true).ToList();
    }

    public WineProducer AddProducer(WineProducer producer)
    {
        _producer.InsertOne(producer);
        return producer;
    }

    public WineProducer GetProducer(string id) => _producer.Find(producer => producer.Id == id).First();

    public void DeleteProducer(string id) => _producer.DeleteOne(producer => producer.Id == id);

    public WineProducer UpdateProducer(WineProducer producer)
    {
        GetProducer(producer.Id);
        _producer.ReplaceOne(p => p.Id == producer.Id, producer);
        return producer;
    }
}