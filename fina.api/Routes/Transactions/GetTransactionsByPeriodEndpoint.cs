using fina.api.Common.Api;
using fina.shared;
using fina.shared.Handlers;
using fina.shared.Models;
using fina.shared.Requests.Transactions;
using fina.shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace fina.api.Routes.Transactions;

public class GetTransactionsByPeriodEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapGet("/", HandleAsync)
        .WithName("Transactions: Get All by Period")
        .WithSummary("Recupera todas as transações no período")
        .WithDescription("Recupera todas as transações no período")
        .WithOrder(5)
        .Produces<PagedResponse<List<Transaction>?>>();

    private static async Task<IResult> HandleAsync(
        ITransactionHandler handler,
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endtDate = null,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetTransactionsByPeriodRequest{
            UserId = ApiConfiguration.UserId,
            PageNumber = pageNumber,
            PageSize = pageSize,
            StartDate = startDate,
            EndDate = endtDate
        };

        var result = await handler.GetAllAsync(request);
        return result.IsSuccess 
            ? TypedResults.Ok(result) 
            : TypedResults.BadRequest(result);

    }   
}