using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using PersonMongoDbMinimalApi.Contracts.Requests;
using PersonMongoDbMinimalApi.Contracts.Responses;
using PersonMongoDbMinimalApi.Mapping;
using PersonMongoDbMinimalApi.Services;

namespace PersonMongoDbMinimalApi.Endpoints;
[HttpGet("people/{id:length(24)}"),AllowAnonymous]
public class GetPersonEndpoint : Endpoint<GetPersonRequest, PersonResponse>
{
    private readonly IPersonService _personService;
    public GetPersonEndpoint(IPersonService people)
    {
        _personService = people;
    }
    public override async Task HandleAsync(GetPersonRequest personReq,CancellationToken ct)
    {
        var person = await _personService.GetAsync(personReq.Id!);

        var personResponse = person.ToPersonResponse();

        await SendOkAsync(personResponse, ct);
    }
}
