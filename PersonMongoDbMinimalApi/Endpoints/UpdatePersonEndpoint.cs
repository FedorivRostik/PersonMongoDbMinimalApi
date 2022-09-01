using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using PersonMongoDbMinimalApi.Contracts.Requests;
using PersonMongoDbMinimalApi.Contracts.Responses;
using PersonMongoDbMinimalApi.Mapping;
using PersonMongoDbMinimalApi.Services;

namespace PersonMongoDbMinimalApi.Endpoints;
[HttpPut("people"), AllowAnonymous]
public class UpdatePersonEndpoint:Endpoint<UpdatePersonRequest, PersonResponse>
{
    private readonly IPersonService _service;

    public UpdatePersonEndpoint(IPersonService service)
    {
        _service = service;
    }
    public override async Task HandleAsync(UpdatePersonRequest req, CancellationToken ct)
    {
        var existingPerson = await _service.GetAsync(req.Id!);

        if (existingPerson is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var person = req.ToPerson();

        await _service.UpdateAsync(person);

        var personResponse = person.ToPersonResponse();

        await SendOkAsync(personResponse, ct);
    }
}
