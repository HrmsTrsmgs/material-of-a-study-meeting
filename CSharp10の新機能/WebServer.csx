#r "sdk:Microsoft.NET.Sdk.Web"
using Microsoft.AspNetCore.Builder;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/Hello", () => "Hello WebApplication!!");

app.Run();
