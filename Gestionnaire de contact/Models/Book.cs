using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarnetAdresseApi.Models;

public class Person
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("LastName")]
    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public string Mail { get; set; } = null!;
}
