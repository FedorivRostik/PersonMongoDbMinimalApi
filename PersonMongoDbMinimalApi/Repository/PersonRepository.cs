using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PersonMongoDbMinimalApi.Database;
using PersonMongoDbMinimalApi.Domain;

namespace PersonMongoDbMinimalApi.Repository;
public class PersonRepository : IPersonRepository
{
    private readonly IMongoCollection<Person> _people;

    public PersonRepository(IOptions<PersonDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);

        var database = client.GetDatabase(settings.Value.DatabaseName);

        _people = database.GetCollection<Person>(settings.Value.PersonCollectionName);
    }

    public async Task CreateAsync(Person person)
    {
        await _people.InsertOneAsync(person);
    }

    public async Task DeleteAsync(string id)
    {
        await _people.DeleteOneAsync(p => p.Id == id);
    }

    public async Task<List<Person>> GetAllAsync()
    {
        var people = await _people.FindAsync(x=> true).Result.ToListAsync();
        return people;
    }

    public async Task<Person> GetAsync(string id)
    {
        var person = await _people.FindAsync(p => p.Id == id).Result.SingleOrDefaultAsync();

        return person;
    }

    public async Task UpdateAsync(Person person)
    {
        await _people.ReplaceOneAsync(p => p.Id == person.Id, person);
    }
}
