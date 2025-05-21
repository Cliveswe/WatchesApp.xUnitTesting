using Microsoft.AspNetCore.Mvc;
using WatchesApp.Web.Models;
using WatchesApp.Web.Services;
using WatchesApp.Web.Views.Watches;

namespace WatchesApp.Web.Controllers;
public class WatchesController : Controller
{
    // Dependency injection for the watch service
    private readonly WatchService watchService;
    private readonly CategoryService categoryService;
    public WatchesController() {
        watchService = WatchService.GetInstance;
        categoryService = CategoryService.GetInstance;
    }

    [HttpGet("")]
    public IActionResult Index() {

        var watches = watchService.GetAllWatches();
        var categries = categoryService.GetAllCategories();

        var ViewModel = new IndexVM {
            WatchItems = watches
        .Select(o => new IndexVM.WatchItemVM {
            Brand = o.Brand,
            Model = o.Model,
            Price = o.Price,
            Description = o.Description,
            ImageUrl = o.ImageUrl,
            ReleaseYear = o.ReleaseYear,
            Category = o.Category
        }).ToList(),
            CategoryItems = categries
        .Select(o => new IndexVM.CategoryItemVM {
            Id = o.Id,
            Name = o.Name,
            Description = o.Description
        }).ToList(),
        };


        // return View((watches, categries));
        return View(ViewModel);
    }

    [HttpGet("/create")]
    public IActionResult Create() {

        //Need to send the categories to the view.
        ViewBag.Categories = categoryService.GetAllCategories();

        return View();
    }

    [HttpPost("/create")]
    public IActionResult Create(Watch watch) {
        //Need to resend the Create action
        if(!ModelState.IsValid) {

            ViewBag.Categories = categoryService.GetAllCategories();
            return View(new Watch());
        }

        watchService.AddWatch(watch);
        return RedirectToAction(nameof(Index));
    }
}
