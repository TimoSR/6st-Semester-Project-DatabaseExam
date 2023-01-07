using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStore.Core.WineCollection.Models;

public class Wine
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public string? Brand { get; set; }
    public string? Type { get; set; }
    public ProducerInfo? Producer { get; set; }
    public string? Year { get; set; }
    public string? Country { get; set; }
    public string? AContents { get; set; }
    
    
    
}

public class ProducerInfo
{
    public string? producer_id { get; set; }
}
