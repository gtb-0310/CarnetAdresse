using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarnetAdresseApi.Models;

public class Person
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string LastName { get; set; } = null!;

    public string FirstName { get; set; }

    public int PhoneNumber { get; set; } = null!;

    public string Mail { get; set; } = null!;
}
