namespace Catalog.API.Products.CreateProduct
{
    // command and result objects
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler
    {
    }
}
