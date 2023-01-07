using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStore.Core.Books.Models;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
    public Author Author { get; set; }
    public List<String> Comments { get; set; }
}

