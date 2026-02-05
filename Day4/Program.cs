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

    endpoint.MapGet("/employees/{id:int?}", async (HttpContext context) =>
    {
        //var empId = context.Request.RouteValues["id"] ;

        await context.Response.WriteAsync($"Get Employees ");
    });

    List<int> Orders = null;

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



