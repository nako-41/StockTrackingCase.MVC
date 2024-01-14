using Microsoft.EntityFrameworkCore;
using Serilog;
using StockTrackingCase.Business.Services;
using StockTrackingCase.DataAccess.Context;
using StockTrackingCase.DataAccess.Repositories;
using StockTrackingCase.DataAccess.Services;
using StockTrackingCase.Entities.Abstractions;
using StockTrackingCase.Entities.Repositories;

namespace StockTrackingCase.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
        });
  
        builder.Services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

        builder.Services.AddScoped<IStockRepository, StockRepository>();
        builder.Services.AddScoped<IStockUnitRepository, StockUnitRepository>();
        builder.Services.AddScoped<IStockService, StockService>();
        builder.Services.AddScoped<IStockUnitService, StokUnitService>();


        Log.Logger = new LoggerConfiguration()
           .WriteTo.Console()
           .WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Day)  
           .CreateLogger();

        builder.Services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders(); 
            loggingBuilder.AddSerilog();    
        });

        builder.Host.UseSerilog();

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

       
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
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
