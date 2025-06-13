﻿// -----------------------------------------------------------------------------
// File: WatchesController.cs
// Summary: Handles watch-related HTTP requests such as displaying the main view,
//          listing watches, and managing categories. Works with services to
//          retrieve data and prepares view models for the views.
// <author> [Clive Leddy] </author>
// <created> [2025-05-23] </created>
// Notes: Connects watch and category services to the UI, enabling CR in CRUD
//        operations and validating image URLs before saving.
// -----------------------------------------------------------------------------

using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
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
        var categories = categoryService.GetAllCategories();

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
            CategoryItems = categories
        .Select(o => new IndexVM.CategoryItemVM {
            Id = o.Id,
            Name = o.Name,
            Description = o.Description
        }).ToList(),
        };


        // return View((watches, categories));
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
    public async Task<IActionResult> Create(CreateVM viewModel) {
        // Need to resend the Create action
        if(!ModelState.IsValid) {
            // Rebuild drop-down data
            var vm = BuildCreateViewModel();

            // Copy posted fields back so user input is preserved
            vm.WatchItems = viewModel.WatchItems;
            return View(viewModel);
        }

        Watch watch = await BuildWatchAsync(viewModel);

        watchService.AddWatch(watch);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Asynchronously constructs a <see cref="Watch"/> object based on the provided view model.
    /// </summary>
    /// <remarks>The method validates the image URL provided in the view model. If the URL is invalid or null,  a
    /// default placeholder image URL ("images/no-picture-Square210.png") is used instead.</remarks>
    /// <param name="viewModel">The view model containing the data required to create the <see cref="Watch"/> object.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the constructed <see cref="Watch"/>
    /// object.</returns>
    private static async Task<Watch> BuildWatchAsync(CreateVM viewModel) {
        // Ensure the ImageUrl is not null or empty before calling IsLinkValidAsync
        string imageUrl = viewModel.WatchItems.ImageUrl ?? string.Empty;

        // If the image URL is invalid, use a default image URL
        bool isValid = await IsLinkValidAsync(imageUrl);

        if(string.IsNullOrEmpty(viewModel.WatchItems.Description)) {
            viewModel.WatchItems.Description = "No description provided.";
        }

        Watch watch = new Watch {
            Brand = viewModel.WatchItems.Brand,
            Model = viewModel.WatchItems.Model,
            Price = viewModel.WatchItems.Price ?? 0, // Default to 0 if null
            Description = viewModel.WatchItems.Description,
            ImageUrl = isValid ? imageUrl : "images/no-picture-Square210.png",
            ReleaseYear = viewModel.WatchItems.ReleaseYear,
            IsAvailable = viewModel.WatchItems.IsAvailable,
            Category = viewModel.WatchItems.Category ?? 0 // Default to 0 if null
        };

        return watch;
    }

    /// <summary>
    /// Determines whether the specified URL is valid and accessible by performing an HTTP GET request.
    /// </summary>
    /// <remarks>This method performs an HTTP GET request to the specified URL with a timeout of 5 seconds. If
    /// the request fails (e.g., due to a timeout, network error, or invalid URL), the method returns <see
    /// langword="false"/>.</remarks>
    /// <param name="url">The URL to validate. Must be a well-formed, absolute URI.</param>
    /// <returns><see langword="true"/> if the URL is accessible and the server responds with a success status code (2xx);
    /// otherwise, <see langword="false"/>.</returns>
    private static async Task<bool> IsLinkValidAsync(string url) {
        try {
            using HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(5);

            HttpResponseMessage response = await client.GetAsync(url);
            return response.IsSuccessStatusCode;
        } catch {
            return false;
        }
    }

    [HttpGet("/throw")]
    public IActionResult Throw() {
        throw new Exception();
    }
}
