using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using PersonMongoDbMinimalApi.Contracts.Responses;
using PersonMongoDbMinimalApi.Mapping;
using PersonMongoDbMinimalApi.Services;

namespace PersonMongoDbMinimalApi.Endpoints;

[HttpGet("people"),AllowAnonymous]
public class GetPeopleEndpoint: EndpointWithoutRequest<GetPeopleResponse>
{
    private readonly IPersonService _personService;

    public GetPeopleEndpoint(IPersonService personService)
    {
        _personService = personService;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var people = await _personService.GetAllAsync();

        var peopleResponse = people.ToPeopleResponse();

        await SendOkAsync(peopleResponse, ct);
    }
}
