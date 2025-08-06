using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string Id { get; set; }

    public required string Name { get; set; }
    public decimal Price { get; set; }

    [BsonElement("images")] public List<ProductImage> Images { get; set; } = [];

    [BsonElement("details")] public ProductDetail? Details { get; set; }

    public string? CategoryId { get; set; }
    [BsonIgnore] public Category? Category { get; set; }
}