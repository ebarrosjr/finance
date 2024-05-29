using fina.api.Common.Api;
using fina.shared.Handlers;
using fina.shared.Models;
using fina.shared.Requests.Transactions;
using fina.shared.Responses;

namespace fina.api.Routes.Transactions;

public class DeleteTransactionEndpoint : IEndpoint 
{
    public static void Map(IEndpointRouteBuilder app) => app.MapDelete("/{id}", HandleAsync)
        .WithName("Transactions: Delete")
        .WithSummary("Exclui uma nova transação")
        .WithDescription("Exclui uma nova transação")
        .WithOrder(3)
        .Produces<Response<Transaction?>>();

    private static async Task<IResult> HandleAsync(ITransactionHandler handler, long id) 
    {
        var request = new DeleteTransactionRequest{ UserId = ApiConfiguration.UserId, Id = id };
        var response =  await handler.DeleteAsync(request);
        return response.IsSuccess 
            ? TypedResults.Ok(response) 
            : TypedResults.BadRequest(response);
    }
}