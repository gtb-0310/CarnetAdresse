using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CarnetAdresseApi.Models;

public class Person
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("LastName")]
    [JsonPropertyName("LastName")]
    public string LastName { get; set; } = null!;

    [BsonElement("FirstName")]
    [JsonPropertyName("FirstName")]
    public string FirstName { get; set; } = null!;

    [BsonElement("PhoneNumber")]
    [JsonPropertyName("PhoneNumber")]
    public int PhoneNumber { get; set; }

    [BsonElement("Mail")]
    [JsonPropertyName("Mail")]
    public string Mail { get; set; } = null!;
    
}
