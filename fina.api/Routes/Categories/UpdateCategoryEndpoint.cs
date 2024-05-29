using fina.api.Common.Api;
using fina.shared.Handlers;
using fina.shared.Models;
using fina.shared.Requests.Categories;
using fina.shared.Responses;

namespace fina.api.Routes.Categories;

public class UpdateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => app.MapPut("/{id}", HandleAsync)
        .WithName("Categories: Update")
        .WithSummary("Atualiza uma categoria")
        .WithDescription("Atualiza uma categoria")
        .WithOrder(2)
        .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(ICategoryHandler handler, UpdateCategoryRequest request, long id) 
    {
        request.UserId = ApiConfiguration.UserId;
        request.Id = id;
        
        var response =  await handler.UpdateAsync(request);
        return response.IsSuccess 
            ? TypedResults.Created($"v1/categories/{response.Data?.Id}", response) 
            : TypedResults.BadRequest(response);
    }
}
