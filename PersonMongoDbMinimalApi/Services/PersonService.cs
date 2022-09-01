using PersonMongoDbMinimalApi.Domain;
using PersonMongoDbMinimalApi.Repository;

namespace PersonMongoDbMinimalApi.Services;
public class PersonService: IPersonService
{
    private readonly IPersonRepository _repository;

    public PersonService(IPersonRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Person>> GetAllAsync()
    {
      var people= await _repository.GetAllAsync();

        return people;
    } 

    public async Task<Person> GetAsync(string id)
    {
        var people = await _repository.GetAsync(id);
        if (people is null)
        {
            throw new Exception();
        }
        return people;
    }

    public async Task DeleteAsync(string id)
    {
         await _repository.DeleteAsync(id);
    }

    public async Task CreateAsync(Person person)
    {
        await _repository.CreateAsync(person);
    }

    public async Task UpdateAsync(Person person)
    {
        await _repository.UpdateAsync( person);
    }
}
