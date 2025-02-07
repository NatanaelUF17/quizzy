var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/health", () => new { Status = "Success", Code = 200 });

app.Run();
