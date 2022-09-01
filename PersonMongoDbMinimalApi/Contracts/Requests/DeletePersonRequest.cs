using Microsoft.AspNetCore.Mvc;

namespace PersonMongoDbMinimalApi.Contracts.Requests;
public class DeletePersonRequest
{
    public string? Id { get; set; }
}
