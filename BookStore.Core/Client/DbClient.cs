using BookStore.Core.Books.Models;
using BookStore.Core.WineCollection.Models;

using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStore.Core;

public class DbClient : IDbClient
{

    private readonly IMongoCollection<Book> _books;
    private readonly IMongoCollection<Wine> _wines;
    private readonly IMongoCollection<WineProducer> _wineProducer;

    public DbClient(IOptions<BookStoreDbConfig> bookstoreDbConfig)
    {
        var client = new MongoClient(bookstoreDbConfig.Value.Connection_String);
        var database = client.GetDatabase(bookstoreDbConfig.Value.Database_Name);
        _books = database.GetCollection<Book>(bookstoreDbConfig.Value.Books_Collection_Name);
        _wines = database.GetCollection<Wine>(bookstoreDbConfig.Value.Wines_Collection_Name);
        _wineProducer = database.GetCollection<WineProducer>(bookstoreDbConfig.Value.Wine_Producer_Collection_Name);
    }

    public IMongoCollection<Book> GetBooksCollection() => _books;
    public IMongoCollection<Wine> GetWineCollection() => _wines;
    public IMongoCollection<WineProducer> GetWineProducerCollection() => _wineProducer;
}