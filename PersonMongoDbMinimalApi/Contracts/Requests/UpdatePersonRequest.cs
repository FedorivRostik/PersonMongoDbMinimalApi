namespace PersonMongoDbMinimalApi.Contracts.Requests;
public class UpdatePersonRequest: CreatePersonRequest
{
    public string? Id { get; set; }

}
