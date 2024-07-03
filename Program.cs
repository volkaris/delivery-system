using Microsoft.EntityFrameworkCore;
using testTask.DbContexts;
using testTask.Services;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<OrderDbContext>(
            options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection")));


        builder.Services.AddScoped<IOrderService, OrderService>();
        
        var app = builder.Build();

        using (var scope=app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
            dbContext.Database.Migrate();
        }

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            "default",
            "{controller=Order}/{action=Index}/{id?}");

        app.MapControllers(); 
        app.Run();
    }
}