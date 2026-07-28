using Carrington.Blake.Models;
using Carrington.Blake.Services;

namespace Carrington.Blake.Endpoints;

public static class AccountEndpoints
{
    public static IEndpointRouteBuilder MapAccountEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/accounts").WithTags("Accounts");

        group.MapGet("/", (IAccountStore store) =>
            Results.Ok(store.GetAll()));

        group.MapGet("/{id:guid}", (Guid id, IAccountStore store) =>
            store.GetById(id) is { } account
                ? Results.Ok(account)
                : Results.NotFound());

        group.MapPost("/", (CreateAccountRequest request, IAccountStore store) =>
        {
            var account = store.Create(request);
            return Results.Created($"/api/accounts/{account.Id}", account);
        });

        group.MapPut("/{id:guid}", (Guid id, UpdateAccountRequest request, IAccountStore store) =>
            store.Update(id, request) is { } account
                ? Results.Ok(account)
                : Results.NotFound());

        group.MapDelete("/{id:guid}", (Guid id, IAccountStore store) =>
            store.Delete(id)
                ? Results.NoContent()
                : Results.NotFound());

        return routes;
    }
}
