using fina.api.Common.Api;
using fina.shared.Handlers;
using fina.shared.Models;
using fina.shared.Requests.Transactions;
using fina.shared.Responses;

namespace fina.api.Routes.Transactions;

public class GetTransactionByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapGet("/{id}", HandleAsync)
        .WithName("Transactions: Get Transaction")
        .WithSummary("Recupera uma transação")
        .WithDescription("Recupera uma transação")
        .WithOrder(4)
        .Produces<PagedResponse<List<Transaction>?>>();

    private static async Task<IResult> HandleAsync(
        ITransactionHandler handler,
        long id)
    {
        var request = new GetTransactionByIdRequest{
            UserId = ApiConfiguration.UserId,
            Id = id,
        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess 
            ? TypedResults.Ok(result) 
            : TypedResults.BadRequest(result);

    }       
}