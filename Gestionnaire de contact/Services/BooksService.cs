using CarnetAdresseApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace CarnetAdresseApi.Services;

public class PeopleService
{
    private readonly IMongoCollection<Person> _peopleCollection;

    public PeopleService(
        IOptions<CarnetAdresseDatabaseSettings> CarnetAdresseDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            CarnetAdresseDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            CarnetAdresseDatabaseSettings.Value.DatabaseName);

        _peopleCollection = mongoDatabase.GetCollection<Person>(
            CarnetAdresseDatabaseSettings.Value.PeopleCollectionName);
    }

    public async Task<List<Person>> GetAsync() =>
        await _peopleCollection.Find(_ => true).ToListAsync();

    public async Task<Person?> GetAsync(string id) =>
        await _peopleCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Person newPerson) =>
        await _peopleCollection.InsertOneAsync(newPerson);

    public async Task UpdateAsync(string id, Person updatedPerson) =>
        await _peopleCollection.ReplaceOneAsync(x => x.Id == id, updatedPerson);

    public async Task RemoveAsync(string id) =>
        await _peopleCollection.DeleteOneAsync(x => x.Id == id);
}