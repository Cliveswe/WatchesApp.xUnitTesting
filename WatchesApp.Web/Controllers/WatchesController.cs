using Microsoft.AspNetCore.Mvc;
using WatchesApp.Web.Services;

namespace WatchesApp.Web.Controllers;
public class WatchesController : Controller
{
    // Dependency injection for the watch service
    private static WatchService watchService = new WatchService();

    [HttpGet("")]
    public IActionResult Index() {
        return View(watchService.GetAllWatches());
    }
}
