using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStore.Core.WineCollection.Models;

public class Producer
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Country { get; set; }
    public List<string>? WineCollection { get; set; }
}