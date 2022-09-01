using FastEndpoints;
using Google.Api.Ads.AdWords.v201809;
using Microsoft.AspNetCore.Authorization;
using PersonMongoDbMinimalApi.Contracts.Requests;
using PersonMongoDbMinimalApi.Contracts.Responses;
using PersonMongoDbMinimalApi.Mapping;
using PersonMongoDbMinimalApi.Services;

namespace PersonMongoDbMinimalApi.Endpoints;

[HttpPost("people"), AllowAnonymous]
public class CreatePersonEndpoint:Endpoint<CreatePersonRequest, PersonResponse>
{
    private readonly IPersonService _service;

    public CreatePersonEndpoint(IPersonService service)
    {
        _service = service;
    }

    public override async Task HandleAsync(CreatePersonRequest req, CancellationToken ct)
    {
        var person = req.ToPerson();

        await _service.CreateAsync(person);

        var personResponse = person.ToPersonResponse();

        await SendCreatedAtAsync<GetPersonEndpoint>(
           new { Id = personResponse.Id }, personResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}
