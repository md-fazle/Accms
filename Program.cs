using ACCMS_AGH.DB;
using ACCMS_AGH.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container for MVC, Web API, and Razor Pages
builder.Services.AddControllersWithViews();  // For MVC (Controllers + Views)
builder.Services.AddRazorPages();            // If using Razor Pages

// Register services for dependency injection
builder.Services.AddSingleton<DbConnection>();
builder.Services.AddScoped<AccmsRepositories>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Top-level route registrations (no need for UseEndpoints here)
app.MapControllers();  // This ensures Web API controllers are mapped
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  // MVC route for controllers with views

// Optional: If you are using Razor Pages, enable them here:
app.MapRazorPages();  // Maps Razor Pages, if applicable

app.Run();
