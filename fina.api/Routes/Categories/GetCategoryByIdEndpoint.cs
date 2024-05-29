using fina.api.Common.Api;
using fina.shared;
using fina.shared.Handlers;
using fina.shared.Models;
using fina.shared.Requests.Categories;
using fina.shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace fina.api.Routes.Categories;

public class GetCategoryByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapGet("/{id}", HandleAsync)
        .WithName("Categories: Get Category")
        .WithSummary("Recupera uma categoria")
        .WithDescription("Recupera uma categoria")
        .WithOrder(4)
        .Produces<PagedResponse<List<Category>?>>();

    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler,
        long id)
    {
        var request = new GetCategoryByIdRequest{
            UserId = ApiConfiguration.UserId,
            Id = id,
        };

        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess 
            ? TypedResults.Ok(result) 
            : TypedResults.BadRequest(result);

    }   
    
}