using Microsoft.EntityFrameworkCore;
using Lab3.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Dodawanie us³ug do kontenera.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();
var appOne = builder.Build();

// Inicjalizacja danych, jeœli jest potrzebna
using (var scope = appOne.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await DataInitializer.SeedData(userManager, roleManager);
}

// Dodawanie us³ug MVC i Razor Pages (jeœli s¹ u¿ywane)
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();


// Konfiguracja potoku ¿¹dañ HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Wa¿ne: Musi byæ przed UseAuthorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages(); // Jeœli u¿ywasz Razor Pages

app.Run();

