using Microsoft.AspNetCore.Mvc;
using WatchesApp.Web.Models;
using WatchesApp.Web.Services;

namespace WatchesApp.Web.Controllers;
public class WatchesController : Controller
{
    // Dependency injection for the watch service
    private IWatchRepository watchService;
    private ICategoryRepository categoryService;
    public WatchesController() {
        watchService = WatchService.GetInstance;
        categoryService = CategoryService.GetInstance;
    }

    [HttpGet("")]
    public IActionResult Index() {

        var watches = watchService.GetAllWatches();
        var categries = categoryService.GetAllCategories();

        return View((watches, categries));
    }
}
