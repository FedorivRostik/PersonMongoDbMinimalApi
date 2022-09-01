using PersonMongoDbMinimalApi.Domain;

namespace PersonMongoDbMinimalApi.Repository;
public interface IPersonRepository
{
    public Task<List<Person>> GetAllAsync();
    public Task<Person> GetAsync(string id);
    public Task DeleteAsync(string id);
    public Task CreateAsync(Person person);
    public Task UpdateAsync(Person person);
}
