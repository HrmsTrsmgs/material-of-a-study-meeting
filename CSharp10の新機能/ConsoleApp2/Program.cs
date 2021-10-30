using Microsoft.AspNetCore.Mvc;

var app = WebApplication.CreateBuilder(args).Build();

app.MapGet("/Default/Hello", async (context) =>
{
    var name = context.Request.Query["name"];
    await context.Response.WriteAsJsonAsync(new[] { $"Hello {name}!!" });
});

app.Run();
