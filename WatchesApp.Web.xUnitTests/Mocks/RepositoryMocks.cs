namespace WatchesApp.Web.xUnitTests.Mocks;
public class RepositoryMocks
{
    /*
    public static Mock<IWatchRepository> GetWatchRepository() {
        // Set the PieId for each pie.
        // This is necessary because the PieId is not set in the original pie data  and we need it for testing purposes
        // This is a workaround to ensure that each pie has a unique PieId.
        // In a real application, this would be handled by the database.
        var mockWatchRepository = new Mock<IWatchRepository>();

        // Assign unique PieId to each pie
        mockWatchRepository.Setup(repo => repo.AllWatches).Returns(watches);

        // Mock the GetPieById method to return the first pie when any id is requested.
        // This is necessary to simulate the behavior of the repository in the tests.
        // This is a workaround to ensure that the GetPieById method returns the correct pie.
        // This is necessary because the GetPieById method is not set in the original pie data and we need it for testing purposes.
        mockWatchRepository.Setup(repo => repo.GetWatchById(It.IsAny<int>())).Returns(watches[0]);
        return mockWatchRepository;
    }

    public static Mock<ICategoryRepository> GetCategoryRepository() {
        var categories = new List<Category>
        {
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Fruit Pies",
                    Description = "Lorem ipsum"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Cheese cakes",
                    Description = "Lorem ipsum"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Fruit Pies",
                    Description = "Seasonal pies"
                }
            };

        // Create a mock of the ICategoryRepository and set up the AllCategories property to return the list of categories.
        // This is necessary to simulate the behavior of the repository in the tests and is a workaround to ensure that the
        // AllCategories property returns the correct categories.
        // This is also necessary because the AllCategories property is not set in the original category data and we need
        // it for testing purposes.
        var mockCategoryRepository = new Mock<ICategoryRepository>();

        // Set up the AllCategories property to return the list of categories.
        // This is necessary to simulate the behavior of the repository in the tests and is a workaround to ensure that the
        // AllCategories property returns the correct categories.
        // This is necessary because the AllCategories property is not set in the original category data and we need it for testing purposes.
        mockCategoryRepository.Setup(repo => repo.AllCategories).Returns(categories);

        return mockCategoryRepository;
    }
    */
}
