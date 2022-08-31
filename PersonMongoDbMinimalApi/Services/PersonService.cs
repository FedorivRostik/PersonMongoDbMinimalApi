using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PersonMongoDbMinimalApi.Database;
using PersonMongoDbMinimalApi.Domain;

namespace PersonMongoDbMinimalApi.Services;
public class PersonService: IPersonService
{
    private readonly IMongoCollection<Person> _people;

    public PersonService(IOptions<PersonDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);

        var database = client.GetDatabase(settings.Value.DatabaseName);

        _people = database.GetCollection<Person>(settings.Value.PersonCollectionName);
    }

    public async Task<List<Person>> GetAllAsync()
    {
        var people = await _people.FindAsync(emp=>true).Result.ToListAsync();
        return people;
    }
}
