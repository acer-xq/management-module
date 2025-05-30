using ManagementModule.EntityModel;
using ManagementModule.Services;
using Microsoft.EntityFrameworkCore;

namespace ManagementModule
{
    public class Program
    {
        private static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ManagementModuleContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("ManagementModuleContext") ?? throw new InvalidOperationException("Missing connection string")));

            builder.Services.AddScoped<ProductsService>();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else { 
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ManagementModuleContext>();
                DbInitialiser.Initialise(context);
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}