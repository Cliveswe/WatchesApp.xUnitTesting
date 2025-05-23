using WatchesApp.Web.Models;
using WatchesApp.Web.Services;

namespace WatchesApp.Web;

public class Program
{
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        //Add the singleton services to the IServaceCollection
        builder.Services.AddSingleton<IWatchRepository, WatchService>();
        //Add the singleton services to the ICategoryRepository
        builder.Services.AddSingleton<ICategoryRepository, CategoryService>();

        // Register services to the container that supports MVC pattern.
        builder.Services.AddControllersWithViews();

        // Build the application where we can configure the HTTP request pipeline.
        var app = builder.Build();

        // Register middle-ware for the HTTP request pipeline.
        app.MapControllers();

        //Register middle-ware for static files.
        app.UseStaticFiles();

        // Start the application and listen for incoming HTTP requests.
        app.Run();
    }
}
