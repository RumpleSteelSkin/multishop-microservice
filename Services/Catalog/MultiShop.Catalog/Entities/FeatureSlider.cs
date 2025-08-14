using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class FeatureSlider
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required bool Status { get; set; }
}