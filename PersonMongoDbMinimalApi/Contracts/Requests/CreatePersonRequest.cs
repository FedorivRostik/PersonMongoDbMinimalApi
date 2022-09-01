namespace PersonMongoDbMinimalApi.Contracts.Requests;
public class CreatePersonRequest
{
    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public int Age { get; set; }

    public string? Email { get; set; }

    public string? Telephone { get; set; }
}
