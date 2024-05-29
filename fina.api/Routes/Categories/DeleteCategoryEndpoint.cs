using fina.api.Common.Api;
using fina.shared.Handlers;
using fina.shared.Models;
using fina.shared.Requests.Categories;
using fina.shared.Responses;

namespace fina.api.Routes.Categories;

public class DeleteCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapDelete("/{id}", HandleAsync)
        .WithName("Categories: Delete")
        .WithSummary("Exclui uma nova categoria")
        .WithDescription("Exclui uma nova categoria")
        .WithOrder(3)
        .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(ICategoryHandler handler, long id) 
    {
        var request = new DeleteCategoryRequest{ UserId = ApiConfiguration.UserId, Id = id };
        var response =  await handler.DeleteAsync(request);
        return response.IsSuccess 
            ? TypedResults.Ok(response) 
            : TypedResults.BadRequest(response);
    }
}