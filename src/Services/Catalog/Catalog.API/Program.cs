var builder = WebApplication.CreateBuilder(args);

// STEP 1. Add services to the container.
    // Register Carter library which will handle minimal API endpoints into ASP.NET DI container
    // Carter provides a structured way to define routes using Carter model
builder.Services.AddCarter();
    // Register MidiatR library which will manage command and query handlers
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
}); // adding required services into MediatR =>
    // tells MediatR where to find command and query handler classes

// Register and configure Marten DocumentDB library into ASP.NET DI (for PostgreSQL)
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!); // temp placeholder
}).UseLightweightSessions();
//customize Marten sessions using session operations - UseLightweightSessions() = best practices for performance

var app = builder.Build();

// STEP 2. Configure the HTTP request pipeline
    // Configure HTTP request pipeline with Carter in order to expose HTTP get/post methods
    // Carter maps routes defined in ICarterModule implementation
app.MapCarter();

app.Run();
