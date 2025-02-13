
using COMP2139_Assignment1.Data;
using COMP2139_Assignment1.Models;
using Microsoft.EntityFrameworkCore;



public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        
        // Add the context to the service collection with a connection string
        builder.Services.AddDbContext<InventoryDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<InventoryDb>();
        
        builder.Services.AddControllersWithViews();

        builder.Services.AddAuthorization();
        
        builder.WebHost.UseUrls("http://localhost:5100"); // Set Port

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        else
        {
            app.UseDeveloperExceptionPage();
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
