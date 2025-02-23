var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    // Register Carter library which will handle minimal API endpoints into ASP.NET DI container
    // Carter provides a structured way to define routes using Carter model
builder.Services.AddCarter();
    // Register MidiatR library which will manage command and query handlers
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
}); // adding required services into MediatR =>
// tells MediatR where to find command and query handler classes

var app = builder.Build();

// Configure the HTTP request pipeline
    // Configure HTTP request pipeline with Carter in order to expose HTTP get/post methods
    // Carter maps routes defined in ICarterModule implementation
app.MapCarter();

app.Run();
