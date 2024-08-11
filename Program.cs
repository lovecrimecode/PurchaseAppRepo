using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration; // Needed for configuration
using PurchaseApp.Data; // For ApplicationDbContext
using PurchaseApp.Domain; // For User class and other domain models

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ensure cookies are only sent over HTTPS
    options.Cookie.SameSite = SameSiteMode.Lax; // Adjust SameSite as needed
});

// Add services to the container.
builder.Services.AddControllersWithViews();
    builder.Services.AddControllers();

// Configure SQLite database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ensure the connection string is correct

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 0;
    options.Password.RequiredUniqueChars = 0;
    options.User.RequireUniqueEmail = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
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

app.MapRazorPages();

// Map controller routes

app.MapControllerRoute(
    name: "account",
    pattern: "{controller=Account}/{action=Login}/{id?}"); // Route for Account controller

app.MapControllerRoute(
    name: "home",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Default to Home controller

app.MapControllerRoute(
    name: "products",
    pattern: "{controller=Product}/{action=Index}/{id?}"); // Route for Product controller

app.MapControllerRoute(
    name: "cart",
    pattern: "Cart/{action=Index}/{id?}"); // Route for Cart controller



app.Run();