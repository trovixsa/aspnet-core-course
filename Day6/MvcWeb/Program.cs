using MvcWeb.Application;

var builder = WebApplication.CreateBuilder(args);

// configure services
// ÊÓÌíá ÇáÎÏãÇÊ İí ÇáÍÇæíÉ (Container)
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<UserService>();

//builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default-api",
    pattern: "api/{controller=Home}/{action=Index}/{id?}"
);

app.MapGet("/", () =>
{
    var userService = new UserService();
    userService.RegisterUser("Ahmad");
});



app.MapGet("/TestDi", (UserService userService) =>
{
    userService.RegisterUser("Ahmad");
});

app.Run();
