﻿using BuildingBlocks.CQRS;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    // Command and result objects
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Business logic to create a product
            throw new NotImplementedException();
        }
    }
}
