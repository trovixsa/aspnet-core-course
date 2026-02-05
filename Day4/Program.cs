
using System;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<int> numbers = [1, 2, 3, 4, 5, 6];
app.Use(async (context, next) =>
{
    await next(context);
});

app.UseRouting();

app.Use(async (context, next) =>
{
    await next(context);
});

app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/employees", async (HttpContext context) =>

    {

        foreach (var num in numbers)
        {
            await context.Response.WriteAsync($"{num}\r\n");

        }




    });



    endpoint.MapPost("/employees/{id}/{add}", async (HttpContext context) =>
    {

        //var num = int.TryParse(context.Request.Query["id"],out int result);

        if (int.TryParse(context.Request.Query["id"], out int num))
        {
            numbers.Add(num);
            await context.Response.WriteAsync($"Number Added");
        }
        else
        {
            await context.Response.WriteAsync("Enter Only Number!!");
        }



    });

    endpoint.MapPut("/employees/{id}/{update}", async (HttpContext context) =>
    {
        if (int.TryParse(context.Request.Query["Update"], out int num) && int.TryParse(context.Request.Query["newNumber"], out int num2))
        {
            if (numbers.Contains(num))
            {
                int index = numbers.FindIndex(i => i == num);

                numbers[index] = num2;
                context.Response.WriteAsync("Number updated");


            }
            else
            {
                context.Response.WriteAsync("Number not Found");
            }
            //await context.Response.WriteAsync($"Number Added");
        }
        else
        {
            await context.Response.WriteAsync("Enter Only Number!!");
        }
        //await context.Response.WriteAsync("Employee updated");
    });

    endpoint.MapDelete("/employees/{id}/{delete}", async (HttpContext context) =>
    {
        if (int.TryParse(context.Request.Query["Delete"], out int num))
        {
            if (numbers.Contains(num))
            {
                numbers.Remove(num);


                context.Response.WriteAsync("Number Deleted");


            }
            else
            {
                context.Response.WriteAsync("Number not Found");
            }
            //await context.Response.WriteAsync($"Number Added");
        }
        else
        {
            await context.Response.WriteAsync("Enter Only Number!!");
        }
    });
});

app.Run();


