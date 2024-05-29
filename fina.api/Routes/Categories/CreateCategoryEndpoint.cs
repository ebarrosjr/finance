using fina.api.Common.Api;
using fina.shared.Handlers;
using fina.shared.Models;
using fina.shared.Requests.Categories;
using fina.shared.Responses;

namespace fina.api.Routes.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapPost("/", HandleAsync)
        .WithName("Categories: Create")
        .WithSummary("Cria uma nova categoria")
        .WithDescription("Cria uma nova categoria")
        .WithOrder(1)
        .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(ICategoryHandler handler, CreateCategoryRequest request) 
    {
        request.UserId = ApiConfiguration.UserId;
        var response =  await handler.CreateAsync(request);
        return response.IsSuccess 
            ? TypedResults.Created($"v1/categories/{response.Data?.Id}", response) 
            : TypedResults.BadRequest(response);
    }
}