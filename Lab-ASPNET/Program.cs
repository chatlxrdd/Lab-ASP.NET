using Lab_ASPNET.Services.Computery;
using Lab_ASPNET.Services.Producery;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Lab_ASPNET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();                         // dodaæ
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Data.AppDbContext>();
            builder.Services.AddDefaultIdentity<IdentityUser>()       // dodaæ
                .AddRoles<IdentityRole>()                             //
                .AddEntityFrameworkStores<Data.AppDbContext>();     // 
            builder.Services.AddTransient<IComputerService, MemoryComputerService>();
            builder.Services.AddTransient<IComputerService, EFComputerService>();
            builder.Services.AddTransient<IProducerService, MemoryProducerService>();
            builder.Services.AddTransient<IProducerService, EFProducerService>();
            builder.Services.AddMemoryCache();                        // dodaæ
            builder.Services.AddSession();                            // dodaæ    
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();                                 // dodaæ
            app.UseAuthorization();                                  // dodaæ
            app.UseSession();                                        // dodaæ 
            app.MapRazorPages();                                     // dodaæ
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
