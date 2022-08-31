using MongoDB.Bson.Serialization.Attributes;

namespace PersonMongoDbMinimalApi.Domain;
public class Person
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set; }
}
