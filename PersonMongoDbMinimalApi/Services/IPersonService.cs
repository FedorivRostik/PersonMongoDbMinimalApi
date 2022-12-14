using PersonMongoDbMinimalApi.Domain;

namespace PersonMongoDbMinimalApi.Services;
public interface IPersonService
{
    public Task<List<Person>> GetAllAsync();
    public Task<Person> GetAsync(string id);
    public Task DeleteAsync(string id);
    public Task CreateAsync(Person person);
    public Task UpdateAsync(Person person);
}
