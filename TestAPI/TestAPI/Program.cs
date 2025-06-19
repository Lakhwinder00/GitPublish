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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsDevelopment() || true) // optional: always show in production
{
    app.UseSwagger();
    app.UseSwaggerUI(); // You can customize Swagger UI here if needed
}

app.MapControllers();

app.Run();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
