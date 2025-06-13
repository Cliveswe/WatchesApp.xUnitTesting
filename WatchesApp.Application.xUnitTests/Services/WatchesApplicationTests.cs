// -----------------------------------------------------------------------------
// File: WatchesApplicationTests.cs
// Summary: Contains unit tests for the WatchService class, verifying its behavior
//          and functionality using a mocked repository.
// <author> [Clive Leddy] </author>
// <created> [2024-06-14] </created>
// <remarks> Updated [2024-06-14] Added tests for add, retrieve by ID, and retrieve all watches. </remarks>
// Notes: Uses RepositoryMocks for simulating repository behavior in xUnit tests.
// -----------------------------------------------------------------------------

using Application.Interfaces;
using Application.Services;
using Moq;
using WatchesApp.Web.xUnitTests.Mocks;

namespace WatchesApp.Application.xUnitTests.Services;

/// <summary>
/// Contains unit tests for the <see cref="WatchService"/> class, verifying its behavior and functionality.
/// </summary>
/// <remarks>This class includes tests for key methods of the <see cref="WatchService"/> class, such as retrieving
/// watches by ID, retrieving all watches, and adding new watches. The tests use a mocked repository to simulate data
/// interactions and ensure the service behaves as expected under various conditions.</remarks>
public class WatchesApplicationTests
{
    private static WatchService WatchServiceWitMockRepository() {
        //var mockRepository = new Mock<IWatchRepository>();
        var mockRepository = RepositoryMocks.GetWatchRepository();
        // Create an instance of WatchService with a mocked repository.
        WatchService watchService = new WatchService(mockRepository.Object);

        return watchService;
    }

    /// <summary>
    /// Tests the <see cref="WatchService.GetWatchByID(int)"/> method to ensure it retrieves a watch by its ID.
    /// </summary>
    /// <remarks>This test verifies that the method correctly returns a watch object with the specified ID and
    /// that the returned object is not null. It uses a mocked repository to simulate the data source.</remarks>
    [Fact]
    public void GetWatchByIDTest() {
        // Arrange
        WatchService watchService = WatchServiceWitMockRepository();
        // Set up the mock to return a watch with ID 1
        int expectedWatchId = 3; // Example ID to test

        // Act
        // Call the method to retrieve the watch by ID.
        var watch = watchService.GetWatchByID(expectedWatchId);

        // Assert
        Assert.NotNull(watch);
        Assert.Equal(expectedWatchId, watch.Id);

    }


    /// <summary>
    /// Tests the <see cref="WatchService.GetAllWatches"/> method to ensure it retrieves all watches correctly.
    /// </summary>
    /// <remarks>This test verifies that the <see cref="WatchService.GetAllWatches"/> method returns a
    /// non-null and non-empty collection when the repository is properly mocked to contain watch data. It ensures the
    /// method behaves as expected under normal conditions.</remarks>
    [Fact]
    public void GetAllWatchesTest() {
        // Arrange
        // Create an instance of WatchService with a mocked repository.
        WatchService watchService = WatchServiceWitMockRepository();

        // Act
        // Call the method to retrieve all watches.
        var watches = watchService.GetAllWatches();

        // Assert
        Assert.NotNull(watches);
        Assert.NotEmpty(watches); // Assuming the mock repository has been set up to return some watches.
    }

    /// <summary>
    /// Tests the functionality of adding a new watch to the watch service and verifies that the watch is correctly
    /// added and retrievable.
    /// </summary>
    /// <remarks>This test ensures that the <see cref="WatchService.AddWatch"/> method successfully adds a
    /// watch to the repository and that the added watch can be retrieved using <see cref="WatchService.GetWatchByID"/>.
    /// It validates the integrity of the watch's properties after addition.</remarks>
    [Fact]
    public void AddWatchTest() {
        // Arrange
        WatchService watchService = WatchServiceWitMockRepository();

        var newWatch = new Domain.Entities.Watch {
            //Id = 1, // Assuming ID is set manually for the test; in a real scenario, this would be auto-generated.
            Brand = "Test Brand",
            Model = "Test Model",
            Price = 100.00m,
            ReleaseYear = 2025,
            Description = "Test Description",
            Category = 1,
            ImageUrl = "https://example.com/test-image.jpg",
            IsAvailable = true,
        };

        // Act
        watchService.AddWatch(newWatch);
        var allWatches = watchService.GetAllWatches();
        var addedWatch = allWatches.Last();
        var retrievedWatch = watchService.GetWatchByID(addedWatch.Id);

        // Assert
        //int expectedWatchId = watchService.GetAllWatches().Select(w => w.Id).Max() - 1; // Get a new ID for the test watch
        Assert.NotNull(retrievedWatch);
        Assert.Equal(newWatch.Brand, retrievedWatch.Brand);
        Assert.Equal(newWatch.Model, retrievedWatch.Model);
        Assert.Equal(newWatch.Price, retrievedWatch.Price);
        Assert.Equal(newWatch.Description, retrievedWatch.Description);
    }


    /// <summary>
    /// Tests that the <see cref="WatchService.GetWatchByID(int)"/> method throws an <see cref="ArgumentException"/> 
    /// when called with an invalid ID value.
    /// </summary>
    /// <remarks>This test verifies that the <see cref="WatchService"/> correctly handles invalid input by
    /// throwing  an <see cref="ArgumentException"/> when the ID parameter is set to 0.</remarks>
    [Fact]
    public void GetById_InvalidIdInput_ShouldThrowArgumentException() {
        // Arrange
        var productRepository = new Mock<IWatchRepository>();
        productRepository.Setup(o => o.GetWatchByID(0)).Throws<ArgumentException>();
        var service = new WatchService(productRepository.Object);
        // Act
        var result = Record.Exception(() => service.GetWatchByID(0));
        // Assert
        Assert.IsType<ArgumentException>(result);
    }
}