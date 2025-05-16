using Microsoft.AspNetCore.Mvc;
using WatchesApp.Web.Models;
using WatchesApp.Web.Services;

namespace WatchesApp.Web.Controllers;
public class WatchesController : Controller
{
    // Dependency injection for the watch service
    private IWatchRepository watchService;

    public WatchesController() {
        watchService = WatchService.GetInstance;
    }
    [HttpGet("")]
    public IActionResult Index() {
        return View(watchService.GetAllWatches());
    }
}
