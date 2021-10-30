using Microsoft.AspNetCore.Mvc;

var app = WebApplication.CreateBuilder(args).Build();

app.Map("/Default/Hello",
    [HttpGet]([FromQuery] string? name) => new[] { $"Hello {name}!!" });

app.Run();
