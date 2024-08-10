using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration; // Needed for configuration
using PurchaseApp.Data; // For ApplicationDbContext
using PurchaseApp.Domain; // For User class and other domain models

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure SQLite database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ensure the connection string is correct

// Register Identity services
builder.Services.AddIdentity<User, IdentityRole>() // Use your User class defined in the Domain
    .AddEntityFrameworkStores<ApplicationDbContext>() // Use your ApplicationDbContext
    .AddDefaultTokenProviders();

// Configure logging (optional)
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Register your repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Show error page in production
    app.UseHsts(); // Use HSTS in production
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Enable authentication
app.UseAuthorization();

// Map controller routes
app.MapControllerRoute(
    name: "home",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Default to Home controller

app.MapControllerRoute(
    name: "products",
    pattern: "{controller=Product}/{action=Index}/{id?}"); // Route for Product controller

app.MapControllerRoute(
    name: "cart",
    pattern: "Cart/{action=Index}/{id?}"); // Route for Cart controller

app.MapControllerRoute(
    name: "account/default",
    pattern: "Account/{action=Login}/{id?}"); // Route for Account controller

app.Run();