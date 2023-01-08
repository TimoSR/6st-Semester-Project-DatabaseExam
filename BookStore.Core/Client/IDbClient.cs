using BookStore.Core.Books.Models;
using BookStore.Core.WineCollection.Models;

using MongoDB.Driver;

namespace BookStore.Core;

public interface IDbClient
{
    IMongoCollection<Book> GetBooksCollection();
    IMongoCollection<Wine> GetWineCollection();
    IMongoCollection<WineProducer> GetWineProducerCollection();
}