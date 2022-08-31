namespace PersonMongoDbMinimalApi.Contracts.Responses;
public class GetPeopleResponse
{
    public IEnumerable<PersonResponse> People { get; init; } = Enumerable.Empty<PersonResponse>();
}
