﻿namespace Catalog.API.Products.CreateProduct
{
    // Command and result objects
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession session) 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // 1.Create Product entity from command object

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            // 2.Save to db (Marten)
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            // 3.Return result (CreateProductResult)

            return new CreateProductResult(product.Id);
        }
    }
}
