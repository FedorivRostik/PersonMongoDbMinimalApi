using MongoDB.Driver;
using PersonMongoDbMinimalApi.Database;
using PersonMongoDbMinimalApi.Domain;

namespace PersonMongoDbMinimalApi.Services;
public class PersonSerive
{
    private readonly IMongoCollection<Person> _people;

    public PersonSerive(IPersonDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);

        var database = client.GetDatabase(settings.DatabaseName);

        _people = database.GetCollection<Person>(settings.PersonCollectionName);
    }

    public async Task<List<Person>> GetPeopleAsync()
    {
        var people = await _people.FindAsync(emp=>true).Result.ToListAsync();
        return people;
    }
}
