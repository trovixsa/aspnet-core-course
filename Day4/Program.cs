using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Use(async (context, next) =>
//{
//    await next(context);
//});

app.UseRouting();

//app.Use(async (context, next) =>
//{
//    await next(context);
//});

app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/employees", async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Get Employees");
    });

    endpoint.MapPost("/employees", async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Employee created");
    });

    endpoint.MapPut("/employees", async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Employee updated");
    });

    endpoint.MapDelete("/employees", async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Employee deleted");
    });
});

app.Run();
