// -----------------------------------------------------------------------------
// File: WatchesController.cs
// Summary: Handles watch-related HTTP requests like showing the main view,
//          listing watches, and managing categories. Works with services to
//          pull data and prepares it for the views.
// <author>Clive Leddy</author>
// <created>2025-05-23</created>
// Notes: This controller connects the watch and category services to the UI.
// -----------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using WatchesApp.Web.Models;
using WatchesApp.Web.Views.Watches;

namespace WatchesApp.Web.Controllers;

/// <summary>
/// Provides endpoints for managing watches and their associated categories in the application.
/// </summary>
/// <remarks>The <see cref="WatchesController"/> class handles HTTP requests related to watches and categories, 
/// including displaying the main view, creating new watch items, and managing related data. It interacts with the
/// underlying services to retrieve and manipulate data, and prepares view models for rendering in the views.</remarks>
/// <param name="watchService"></param>
/// <param name="categoryService"></param>
public class WatchesController(IWatchRepository watchService, ICategoryRepository categoryService) : Controller
{
    // Dependency injection for the watch service
    //private readonly WatchService watchService;
    //private readonly CategoryService categoryService;
    //public WatchesController() {
    //    watchService = WatchService.GetInstance;
    //    categoryService = CategoryService.GetInstance;
    //}

    /// <summary>
    /// Handles the HTTP GET request for the root endpoint and returns the main view for the application.
    /// </summary>
    /// <remarks>This method retrieves all watches and categories from their respective services, transforms
    /// the data into view models, and passes the resulting view model to the view for rendering. The view model
    /// includes a list of watches and a list of categories, each with their relevant details.</remarks>
    /// <returns>An <see cref="IActionResult"/> that renders the main view populated with the watch and category data.</returns>
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

    /// <summary>
    /// Displays the creation form for a new item.
    /// </summary>
    /// <remarks>This method prepares the necessary data for the creation form and returns the corresponding
    /// view. The data is encapsulated in a view model, which is passed to the view for rendering.</remarks>
    /// <returns>An <see cref="IActionResult"/> that renders the creation form view.</returns>
    [HttpGet("/create")]
    public IActionResult Create() {

        //Need to send the categories to the view.
        //ViewBag.Categories = categoryService.GetAllCategories();
        //var categories = categoryService.GetAllCategories();

        var viewModel = BuildCreateViewModel();

        return View(viewModel);
    }

    /// <summary>
    /// Builds and returns a <see cref="CreateVM"/> instance populated with category and watch item data.
    /// </summary>
    /// <remarks>The returned <see cref="CreateVM"/> object includes a list of category items derived from the
    /// available categories and an initialized <see cref="CreateVM.WatchItemVM"/> instance. This method is intended to
    /// prepare the data required for creating a new view model.</remarks>
    /// <returns>A <see cref="CreateVM"/> instance containing a list of category items and an initialized watch item.</returns>
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

    /// <summary>
    /// Handles the creation of a new watch item based on the provided view model.
    /// </summary>
    /// <remarks>This action validates the provided view model and, if valid, maps its data to a new watch
    /// entity, which is then added to the data store. If the model state is invalid, the same view is returned  with
    /// the validation errors displayed.</remarks>
    /// <param name="viewModel">The view model containing the details of the watch to be created.</param>
    /// <returns>An <see cref="IActionResult"/> that renders the creation view with validation errors if the model state is
    /// invalid, or redirects to the index page upon successful creation.</returns>
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
