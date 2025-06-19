var builder = WebApplication.CreateBuilder(args);

// Bind to environment variable port
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Configure(builder.Configuration.GetSection("Kestrel"));
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "API is running");

if (app.Environment.IsDevelopment() || true) // force enable Swagger even in production
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        options.RoutePrefix = "swagger"; // URL will be /swagger/index.html
    });
}

app.MapControllers();

app.Run();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
