using PersonMongoDbMinimalApi.Domain;

namespace PersonMongoDbMinimalApi.Services;
public interface IPersonService
{
    public Task<List<Person>> GetAllAsync();
}
