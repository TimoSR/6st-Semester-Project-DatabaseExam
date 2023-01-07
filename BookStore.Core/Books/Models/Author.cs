using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStore.Core.Books.Models;

public class Author
{
    public string? Id { get; set; }
    public string? Name { get; set; }
}