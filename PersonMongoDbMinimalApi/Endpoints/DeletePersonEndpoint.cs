using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using PersonMongoDbMinimalApi.Contracts.Requests;
using PersonMongoDbMinimalApi.Services;

namespace PersonMongoDbMinimalApi.Endpoints;
[HttpDelete("people/{id:length(24)}"), AllowAnonymous]
public class DeletePersonEndpoint:Endpoint<DeletePersonRequest>
{
    private readonly IPersonService _service;

    public DeletePersonEndpoint(IPersonService service)
    {
        _service = service;
    }

    public override async Task HandleAsync(DeletePersonRequest req, CancellationToken ct)
    {
        var personExist =await _service.GetAsync(req.Id!);

        if (personExist is null)
        {
            await SendNotFoundAsync();
            return;
        }

        await _service.DeleteAsync(req.Id!);

        await SendNoContentAsync(ct);
    }
}
