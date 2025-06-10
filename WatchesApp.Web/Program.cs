// -----------------------------------------------------------------------------
// File: Program.cs
// Summary: Entry point for the web application. Sets up services, middle-ware,
//          and the HTTP request pipeline. Registers controllers, static files,
//          and configures DI for watch and category services.
// <author> [Clive Leddy] </author>
// <created> [2025-05-23] </created>
// Notes: Standard ASP.NET Core startup pattern using minimal hosting model.
// -----------------------------------------------------------------------------

using Application.Interfaces;
using Application.Services;
using Infrastructure.Repositories;

namespace WatchesApp.Web;

public class Program
{
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        //Add the singleton services to the IServaceCollection
        builder.Services.AddTransient<IWatchRepository, WatchService>();
        //Add the singleton services to the ICategoryRepository
        builder.Services.AddSingleton<ICategoryRepository, CategoryService>();
        builder.Services.AddSingleton<IWatchRepository, WatchRepository>();

        // Register services to the container that supports MVC pattern.
        builder.Services.AddControllersWithViews();

        // Build the application where we can configure the HTTP request pipeline.
        var app = builder.Build();


        if(!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/error/exception");
            app.UseStatusCodePagesWithRedirects("/error/http/{0}");
        }

        // Register middle-ware for the HTTP request pipeline.
        app.MapControllers();

        //Register middle-ware for static files.
        app.UseStaticFiles();

        // Start the application and listen for incoming HTTP requests.
        app.Run();
    }
}
