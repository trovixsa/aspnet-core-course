using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ModelBindSample.Application;
using ModelBindSample.Domain;
using ModelBindSample.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
var app = builder.Build();



app.UseRouting();


app.MapGet("/employees/{id}", async (HttpContext context) =>
{
    var id = context.Request.RouteValues["id"];
    context.Response.ContentType = "text/html;";
    await context.Response.WriteAsync($"<b>Employee ID:</b> {id}");
});

// binding route parameter directly to method parameter ( implicit binding )
app.MapGet("/orders/{id}",async (HttpContext context,int id) =>
{

    await context.Response.WriteAsync($"<b>Employee ID:</b> {id}");
});

//binding route parameter directly to method parameter ( explicit binding )
app.MapGet("/products/{id}",async (HttpContext context, [FromRoute] string id) =>
{
    context.Response.ContentType = "text/html;";
    if (int.TryParse(id, out int productId))
    {
        await context.Response.WriteAsync($"<b>Product ID:</b> {productId}");
    }
    else
    {
        context.Response.StatusCode = 400; // Bad Request
        await context.Response.WriteAsync("<span style=\"color:red\">Invalid Product ID</span>");
    }
});

//make it routedate, and make the name different from the parameter name
app.MapGet("/students/{id}", (int id) =>
{
    Student student = new Student
    {
        Id = id,
        Name = "Abdullah AlGrou"
    };
    return student;
});

//try
app.MapGet("/courses/{id:int}", ([FromRoute] string id) =>
{
    return id;
});

app.MapGet("/cities/{id:int?}", ([FromRoute]int id) =>
{
    return id;
});

app.MapGet("/products/search", (
    int page,
    int pageSize,
    string category,
    string searchTerm,
    decimal? minPrice,
    decimal? maxPrice,
    bool? inStock) =>
{
    return $"Searching: {searchTerm} in {category}";
});

app.MapGet("/products/search", ([AsParameters] ProductSearchParams searchParams) =>
{
    return $"Searching: {searchParams.SearchTerm} in {searchParams.Category}";
});

app.MapPost("/products/", (ProductCreateDto product) =>
{
    return $"product {product.Id} created";
});


// try binding array from query string
app.MapGet("/employees", (int[] id) =>
{
    
});

app.MapPost("/employees", async (HttpContext context) =>
{
    var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();
    try
    {
        var employee = JsonSerializer.Deserialize<Employee>(body);
    }
    catch (Exception e)
    {
        context.Response.WriteAsync($"exception: {e.Message}");
    }
});
app.Run();
