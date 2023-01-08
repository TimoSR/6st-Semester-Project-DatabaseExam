using BookStore.Core.WineCollection.Models;
namespace BookStore.Core.WineCollection.Services;

public interface IWineProducerServices
{
    List<WineProducer> GetProducers();
    WineProducer AddProducer(WineProducer producer);
    WineProducer GetProducer(string id);
    void DeleteProducer(string id);
    WineProducer UpdateProducer(WineProducer producer);
}