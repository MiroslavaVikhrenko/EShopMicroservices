using Carter;
using Mapster;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    // Define request and response records for endpoint
    public record CreateProductRequest(string Name, List<string> Categories, string Description, string ImageFile, decimal Price);
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            // Define HTTP POST endpoint using Carter and Mapster 
            // Map request to command object
            // Send it through MediatR
            // Map result back to response model

            app.MapPost("/products",
                async (CreateProductRequest request, ISender sender) =>
            {
                // Get command object from request using Mapster
                var command = request.Adapt<CreateProductCommand>();

                // Convert using Mapster from request to command object 
                // Why need command object? Because MediatR requires command object in order to trigger command handler

                var result = await sender.Send(command); // it starts MediatR and and triggers handler class

                // After getting result, convert response type from result using Mapster

                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{response.Id}", response); // 202 response 
            })
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create product")
            .WithDescription("Create product");
            
        }
    }
}
