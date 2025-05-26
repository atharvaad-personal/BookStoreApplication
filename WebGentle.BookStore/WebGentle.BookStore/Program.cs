using Microsoft.Extensions.FileProviders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


// Add services to the container
builder.Services.AddControllersWithViews(); // 👈 Adds MVC (Controller + Views)

#if DEBUG
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
#endif

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");  // 👈 Custom error page
    app.UseHsts(); // 👈 Adds HTTP Strict Transport Security headers
}

app.UseHttpsRedirection(); // 👈 Redirect HTTP -> HTTPS
app.UseStaticFiles();       // 👈 Serve static files like CSS, JS, images

app.UseRouting();           // 👈 Enable routing

//app.UseStaticFiles(new StaticFileOptions()   // 👈 Not needed as this was jsut for understanding
//{
//    FileProvider = new PhysicalFileProvider
//    (Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),

//    RequestPath = "/MyStaticFiles"
//});

app.UseAuthorization();     // 👈 Add authorization middleware if needed

// Set default route for MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}"
);

app.Run();
