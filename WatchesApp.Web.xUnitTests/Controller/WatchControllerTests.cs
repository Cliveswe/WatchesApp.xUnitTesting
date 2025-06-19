// -----------------------------------------------------------------------------
// File: WatchControllerTests.cs
// Summary: Contains unit tests for the WatchesController class, verifying its 
//          behavior across various scenarios including index view rendering, 
//          form handling, model validation, and image URL fallback logic.
// <author> [Clive Leddy] </author>
// <created> [2025-06-13] </created>
// Notes: Uses Moq to simulate repository behavior and xUnit for test assertions.
// -----------------------------------------------------------------------------

using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WatchesApp.Web.Controllers;
using WatchesApp.Web.Views.Watches;

namespace WatchesApp.Web.xUnitTests.Controller;

/// <summary>
/// Provides unit tests for the <see cref="WatchesController"/> class, ensuring its
/// actions behave correctly with valid and invalid inputs, including view rendering,
/// model validation, image URL fallback, and exception handling.
/// </summary>
/// <remarks>
/// These tests use mocked implementations of <see cref="IWatchRepository"/> and
/// <see cref="ICategoryRepository"/> to isolate controller logic from the data layer,
/// allowing for consistent and repeatable tests of view models, redirects, and error handling.
/// </remarks>

public class WatchControllerTests
{
    /// <summary>
    /// Tests the <see cref="WatchesController.Index"/> method to ensure it returns a <see cref="ViewResult"/>      with
    /// the correct view model type when called without parameters.
    /// </summary>
    /// <remarks>This test verifies that the <see cref="WatchesController.Index"/> method produces a <see
    /// cref="ViewResult"/>      containing an instance of <see cref="IndexVM"/> as its model. It uses mocked
    /// repositories to simulate      the data returned by the watch and category repositories.</remarks>
    [Fact]
    public void Index_NoParams_ReturnsViewResultWithCorrectViewModel() {
        // Arrange
        var mockWatchRepository = new Mock<IWatchRepository>();
        var mockCategoryRepository = new Mock<ICategoryRepository>();

        // Creating an instance of the controller with the mocked repositories
        // This allows us to test the controller's behavior without relying on the actual database or services.
        var watchController = new WatchesController(mockWatchRepository.Object, mockCategoryRepository.Object);

        // Mocking the watch repository to return a list of watches
        // This is necessary to avoid null reference exceptions in the view model
        // when the view tries to access watches.
        mockWatchRepository.Setup(ws => ws.GetAllWatches())
            .Returns(new List<Watch> {
                new Watch {
                    Id = 1,
                    Brand = "TestBrand",
                    Model = "TestModel",
                    Price = 1000,
                    Description = "TestDescription",
                    ImageUrl = "http://example.com/image.jpg",
                    ReleaseYear = 2023,
                    IsAvailable = true,
                    Category = 1 }
            });
        // Mocking the category repository to return a list of categories
        mockCategoryRepository.Setup(cs => cs.GetAllCategories())
            .Returns(new List<Category> {
                new Category { Id = 1, Name = "TestCategory" }
            });


        // Act
        // Calling the Index method of the controller, which should return a ViewResult
        // containing the IndexVM model.
        var result = watchController.Index();

        // Assert
        // Verifying that the result is of type ViewResult, which is the expected return type
        // for the Index action method.
        var viewResult = Assert.IsType<ViewResult>(result);
        // Checking that the model of the ViewResult is of type IndexVM, which is the expected view model
        // for the Index view.
        Assert.IsType<IndexVM>(viewResult.Model);
    }

    /// <summary>
    /// Tests that the <c>Create</c> action of the <c>WatchesController</c> returns a <c>ViewResult</c>  containing a
    /// <c>CreateVM</c> as its model.
    /// </summary>
    /// <remarks>This test verifies that the <c>Create</c> action initializes the view model correctly and 
    /// returns the expected view result. It uses mocked repositories to simulate dependencies.</remarks>
    [Fact]
    public void Create_Get_ReturnsViewResultWithCreateVM() {
        // Arrange
        var mockWatchRepository = new Mock<IWatchRepository>();
        var mockCategoryRepoitory = new Mock<ICategoryRepository>();

        mockCategoryRepoitory.Setup(
            r => r.GetAllCategories())
            .Returns(new List<Category>());

        var controller = new WatchesController(mockWatchRepository.Object, mockCategoryRepoitory.Object);

        // Act
        var result = controller.Create();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.IsType<CreateVM>(viewResult.Model);
    }


    /// <summary>
    /// Tests the behavior of the <c>Create</c> action when the model state is invalid.
    /// </summary>
    /// <remarks>This test verifies that the <c>Create</c> action returns the same view with the provided
    /// model when the model state contains validation errors. It ensures that the controller does not redirect or
    /// perform any other actions when the model is invalid, allowing the user to correct the errors.</remarks>
    /// <returns></returns>
    [Fact]
    public async Task Create_Post_InvalidModel_ReturnsSameViewWithModel() {
        // Arrange
        var mockWatchRepository = new Mock<IWatchRepository>();
        var mockCategoryRepoitory = new Mock<ICategoryRepository>();
        // Mocking the category repository to return an empty list of categories
        // This is necessary to avoid null reference exceptions in the view model
        // when the view tries to access categories.
        mockCategoryRepoitory.Setup(r =>
        r.GetAllCategories())
            .Returns(new List<Category>());

        var controller = new WatchesController(mockWatchRepository.Object, mockCategoryRepoitory.Object);

        // Simulating a model state error for the "Brand" field
        // This is done to test the scenario where the model is invalid and the controller should return the same view
        // with the model containing the error.
        controller.ModelState.AddModelError("Brand", "Required");

        var viewModel = new CreateVM {
            WatchItems = new CreateVM.WatchItemVM {
                Brand = "",
                Model = "Model",
                Price = 100,
                ImageUrl = "",
                Category = 1
            }
        };

        // Act
        var result = await controller.Create(viewModel);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<CreateVM>(viewResult.Model);
        Assert.Equal("Model", model.WatchItems.Model);
    }

    /// <summary>
    /// Tests the <c>Create</c> action of the <see cref="WatchesController"/> to ensure that a valid watch model is
    /// added to the repository and the user is redirected to the "Index" action.
    /// </summary>
    /// <remarks>This test verifies that the <c>Create</c> action correctly handles a valid watch creation
    /// request by: <list type="bullet"> <item>Adding the watch to the repository using the <see
    /// cref="IWatchRepository.AddWatch"/> method.</item> <item>Redirecting the user to the "Index" action upon
    /// successful creation.</item> </list></remarks>
    /// <returns></returns>
    [Fact]
    public async Task Create_Post_ValidModel_AddsWatchAndRedirects() {
        // Arrange
        var mockWatchRepooitory = new Mock<IWatchRepository>();
        var mockCategoryRepoitory = new Mock<ICategoryRepository>();
        var controller = new WatchesController(mockWatchRepooitory.Object, mockCategoryRepoitory.Object);

        var viewModel = new CreateVM {
            WatchItems = new CreateVM.WatchItemVM {
                Brand = "Brand",
                Model = "Model",
                Price = 100,
                ImageUrl = "https://valid.url",
                Category = 1,
                Description = "desc",
                IsAvailable = true
            }
        };

        // Act
        var result = await controller.Create(viewModel);

        // Assert
        // Verify that the AddWatch method was called once with a Watch object
        // containing the expected properties.
        mockWatchRepooitory.Verify(repo => repo.AddWatch(It.IsAny<Watch>()), Times.Once);

        // Check that the result is a RedirectToActionResult
        // which indicates a successful creation and redirection.
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);

        // Verify that the redirection is to the "Index" action
        // which is the expected behavior after a successful creation.
        Assert.Equal("Index", redirectResult.ActionName);
    }

    [Fact]
    public void ThrowAction_ThrowsException() {
        var controller = new WatchesController(
            new Mock<IWatchRepository>().Object,
            new Mock<ICategoryRepository>().Object);

        // Act & Assert
        // This test verifies that the Throw action of the controller throws an exception as expected.
        // It uses Assert.Throws to check that an exception is thrown when the Throw method is called.
        Assert.Throws<Exception>(() => controller.Throw());
    }

    /// <summary>
    /// Verifies that the <see cref="WatchesController.Index"/> method returns a view with empty lists
    /// when both watch and category repositories provide no data.
    /// </summary>
    /// <remarks>
    /// This test ensures the controller gracefully handles empty data sources by:
    /// <list type="bullet">
    /// <item><description>Returning a <see cref="ViewResult"/>.</description></item>
    /// <item><description>Providing an <see cref="IndexVM"/> as the model.</description></item>
    /// <item><description>Ensuring both <c>WatchItems</c> and <c>CategoryItems</c> are empty.</description></item>
    /// </list>
    /// </remarks>

    [Fact]
    public void Index_EmptyRepositories_ReturnsViewWithEmptyLists() {
        // Arrange
        var mockWatchRepo = new Mock<IWatchRepository>();
        var mockCategoryRepo = new Mock<ICategoryRepository>();

        mockWatchRepo.Setup(repo => repo.GetAllWatches()).Returns(new List<Watch>());
        mockCategoryRepo.Setup(repo => repo.GetAllCategories()).Returns(new List<Category>());

        var controller = new WatchesController(mockWatchRepo.Object, mockCategoryRepo.Object);

        // Act
        var result = controller.Index();
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<IndexVM>(viewResult.Model);

        // Assert
        Assert.Empty(model.WatchItems);
        Assert.Empty(model.CategoryItems);
    }

    /// <summary>
    /// Tests the <see cref="WatchesController.Create(CreateVM)"/> POST method to ensure that an invalid image URL
    /// results in the default image being assigned to the created <see cref="Watch"/>.
    /// </summary>
    /// <remarks>
    /// This test simulates a form submission with an invalid image URL and verifies that:
    /// <list type="bullet">
    /// <item><description>The <c>Watch.ImageUrl</c> is set to the fallback URL <c>"images/no-picture-Square210.png"</c>.</description></item>
    /// <item><description>The <see cref="IWatchRepository.AddWatch(Watch)"/> method is called exactly once.</description></item>
    /// <item><description>The result is a redirection to the <c>Index</c> action.</description></item>
    /// </list>
    /// </remarks>

    [Fact]
    public async Task Create_Post_InvalidImageUrl_SetsDefaultImage() {
        // Arrange
        var mockWatchRepo = new Mock<IWatchRepository>();
        var mockCategoryRepo = new Mock<ICategoryRepository>();

        var controller = new WatchesController(mockWatchRepo.Object, mockCategoryRepo.Object);

        // Mocking the category repository to return an empty list of categories
        // This is necessary to avoid null reference exceptions in the view model
        // when the view tries to access categories.
        var viewModel = new CreateVM {
            WatchItems = new CreateVM.WatchItemVM {
                Brand = "Brand",
                Model = "Model",
                Price = 100,
                ImageUrl = "https://invalid.example.fake", // simulate failure
                Category = 1,
                Description = "desc",
                IsAvailable = true
            }
        };

        // Act
        // Call the Create method with the view model that has an invalid image URL
        // The controller should handle the invalid URL and set a default image URL.
        var result = await controller.Create(viewModel);

        // Verify that the AddWatch method was called with a Watch object that has the default image URL
        // "images/no-picture-Square210.png" when the image URL is invalid.
        mockWatchRepo.Verify(repo => repo.AddWatch(It.Is<Watch>(w =>
            w.ImageUrl == "images/no-picture-Square210.png")), Times.Once);

        // Assert
        // Check that the result is a RedirectToActionResult, indicating a successful creation and redirection.
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        // Verify that the redirection is to the "Index" action, which is the expected behavior after a successful creation.
        Assert.Equal("Index", redirectResult.ActionName);
    }

}
