using MongoDB.Bson.Serialization.Attributes;

namespace PersonMongoDbMinimalApi.Domain;
public class Person
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("firstName")]
    public string? FirstName { get; set; }

    [BsonElement("secondName")]
    public string? SecondName { get; set; }

    [BsonElement("age")]
    public int Age { get; set; }

    [BsonElement("email")]
    public string? Email { get; set; }

    [BsonElement("telephone")]
    public string? Telephone { get; set; }
}
