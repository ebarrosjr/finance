using fina.api.Common.Api;
using fina.shared.Handlers;
using fina.shared.Models;
using fina.shared.Requests.Transactions;
using fina.shared.Responses;

namespace fina.api.Routes.Transactions;

public class UpdateTransactionEndpoint : IEndpoint
{
     public static void Map(IEndpointRouteBuilder app) => app.MapPut("/{id}", HandleAsync)
        .WithName("Transactions: Update")
        .WithSummary("Atualiza uma transação")
        .WithDescription("Atualiza uma transação")
        .WithOrder(2)
        .Produces<Response<Transaction?>>();

    private static async Task<IResult> HandleAsync(ITransactionHandler handler, UpdateTransactionRequest request, long id) 
    {
        request.UserId = ApiConfiguration.UserId;
        request.Id = id;
        
        var response =  await handler.UpdateAsync(request);
        return response.IsSuccess 
            ? TypedResults.Created($"v1/transactions/{response.Data?.Id}", response) 
            : TypedResults.BadRequest(response);
    }   
}