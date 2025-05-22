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
        //ViewBag.Categories = categoryService.GetAllCategories();
        //var categories = categoryService.GetAllCategories();

        //var ViewModel = new CreateVM {
        //    WatchItems = new CreateVM.WatchItemVM(),
        //    CategoriesItems = categories
        //    .Select(o => new CreateVM.CategoryItemVM {
        //        Id = o.Id,
        //        Name = o.Name,
        //        Description = o.Description
        //    }).ToList()
        //};
        var viewModel = BuildCreateViewModel();

        return View(viewModel);
    }

    private CreateVM BuildCreateViewModel() {
        var categories = categoryService.GetAllCategories();
        var viewModel = new CreateVM {
            WatchItems = new CreateVM.WatchItemVM(),
            CategoryItems = categories
                .Select(o => new CreateVM.CategoryItemVM {
                    Id = o.Id,
                    Name = o.Name,
                    Description = o.Description
                }).ToList()
        };
        return viewModel;
    }

    [HttpPost("/create")]
    public IActionResult Create(CreateVM viewModel) {
        // Need to resend the Create action
        if(!ModelState.IsValid) {
            return View(viewModel);
        }

        // Need to cast the ViewModel to Watch.
        Watch watch = new Watch {
            Brand = viewModel.WatchItems.Brand,
            Model = viewModel.WatchItems.Model,
            Price = viewModel.WatchItems.Price ?? 0, // Default to 0 if null
            Description = viewModel.WatchItems.Description,
            ImageUrl = viewModel.WatchItems.ImageUrl,
            ReleaseYear = viewModel.WatchItems.ReleaseYear,
            IsAvailable = viewModel.WatchItems.IsAvailable,
            Category = viewModel.WatchItems.Category ?? 0 // Default to 0 if null
        };

        watchService.AddWatch(watch);
        return RedirectToAction(nameof(Index));
    }
}
