using Microsoft.AspNetCore.Mvc;

var app = WebApplication.CreateBuilder(args).Build();

app.MapGet("/Default/Hello", () => new[] { "Hello User!!" });

app.Run();
