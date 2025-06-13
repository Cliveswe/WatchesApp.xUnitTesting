// -----------------------------------------------------------------------------
// File: RepositoryMocks.cs
// Summary: Provides static helper methods to create mock implementations of
//          repository interfaces for unit testing. Supplies pre-configured mocks
//          for IWatchRepository and ICategoryRepository with sample data.
// <author> [Clive Leddy] </author>
// <created> [2025-06-13] </created>
// <remarks> Updated [2025-06-13] Added detailed mock setup for category and watch repositories. </remarks>
// Notes: Intended for use in xUnit test projects. Uses Moq for mocking.
// -----------------------------------------------------------------------------
using Application.Interfaces;
using Domain.Entities;
using Moq;

namespace WatchesApp.Mocks;

/// <summary>
/// Provides static methods for creating mock implementations of repository interfaces used in testing scenarios.
/// </summary>
/// <remarks>This class is designed to simplify the creation of mock repositories for unit testing purposes. It
/// includes methods for generating pre-configured mock implementations of the <see cref="IWatchRepository"/> and <see
/// cref="ICategoryRepository"/>  interfaces. These mocks simulate the behavior of their respective repositories by
/// providing predefined data and  implementations for common operations, such as retrieving all items or querying by
/// specific criteria.</remarks>
public class RepositoryMocks
{

    /// <summary>
    /// Creates and returns a mock implementation of the <see cref="IWatchRepository"/> interface.
    /// </summary>
    /// <remarks>This method is primarily intended for testing purposes. It sets up a mock repository
    /// containing a predefined collection of watches with sample data, including various brands, models, prices,
    /// descriptions, images, release years, availability statuses, and categories. The mock repository simulates the
    /// behavior of the <see cref="IWatchRepository"/> interface by providing implementations for methods such as <see
    /// cref="IWatchRepository.GetAllWatches"/> and <see cref="IWatchRepository.GetWatchByID(int)"/>.</remarks>
    /// <returns>A mock implementation of <see cref="IWatchRepository"/> pre-configured with sample watch data.</returns>
    public static Mock<IWatchRepository> GetWatchRepository() {

        // Represents a collection of predefined watches available in the system.
        // Create a list of watches with various properties such as brand, model, price, description, image URL, release year, availability status, and category.
        // This list is used to simulate a repository of watches for testing purposes.
        // The watches are initialized with sample data, including luxury, dress, sports, and smart-watches.
        // This is a workaround to ensure that the watches are available for testing purposes.
        List<Watch> watches = [
            new Watch { Id = 1, Brand = "Nomos", Model = "Club Sport neomatik", Price = 21000m, Description = "Chronograph with minimalist Bauhaus aesthetics.", ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fcdn.nomos-glashuette.com%2Fmedia%2Fimage%2F3e%2F72%2F93%2F800xauto-q80-bg238238238%2F0782_club_sport_neomatik_42_datum_blau_front_masked.jpg&f=1&nofb=1&ipt=d88422cf1281e0abf0230d1f4263e49b50bede8f02eeb6d043568ddab1fb74fa", ReleaseYear = 2022, IsAvailable = true, Category = 1},
            new Watch { Id = 2, Brand = "Frederique Constant", Model = "Classics Index", Price = 9950m, Description = "Elegant Swiss dress watch.", ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse2.mm.bing.net%2Fth%3Fid%3DOIP.B2386un1OvR1Ec2p2g--jQHaMF%26pid%3DApi&f=1&ipt=ad89465a5f65775f3d53f229cb89715a42f09c6bcd2507639d4f056a4fcdc48d", ReleaseYear = 2021, IsAvailable = true, Category = 1},
            new Watch { Id = 3, Brand = "Samsung", Model = "Galaxy Watch 6", Price = 3990m, Description = "Advanced smartwatch with health tracking.", ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.droid-life.com%2Fwp-content%2Fuploads%2F2023%2F06%2FGalaxy-Watch-6-Classic-980x653.jpg&f=1&nofb=1&ipt=cc9a519a34d6c6d636d479ab002c789fd40ada949f76329b37cb586aa3774a79", ReleaseYear = 2023, IsAvailable = true, Category = 3},
            new Watch { Id = 4, Brand = "Casio", Model = "G-Shock GA-100", Price = 1200m, Description = "Rugged and durable digital watch.", ImageUrl = "https://www.casio.com/content/dam/casio/product-info/locales/sg/en/timepiece/product/watch/G/GA/GA1/GA-100CB-1A/assets/GA-100CB-1A_Seq1.png", ReleaseYear = 2020, IsAvailable = true, Category = 2},
            new Watch { Id = 5, Brand = "Seiko", Model = "Presage Cocktail Time", Price = 4500m, Description = "Elegant dress watch.", ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.watchnation.com%2Fwp-content%2Fuploads%2F2022%2F06%2Fimage340392944.jpg&f=1&nofb=1&ipt=81cfa6b88e812e924502fc6ae0c7a9433c4e8bc025a32d9d0ea1879ff083ac90", ReleaseYear = 2019, IsAvailable = false, Category = 1},
            new Watch { Id = 6, Brand = "Tissot", Model = "PRX Powermatic 80", Price = 6500m, Description = "Automatic watch with 80-hour power reserve.", ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.ytimg.com%2Fvi%2FQ7HYiWk--As%2Fmaxresdefault.jpg&f=1&nofb=1&ipt=2c07a850b270ef7b8797cc9907163f1f76db205f82429c52fbac5fda69d3c321", ReleaseYear = 2021, IsAvailable = true, Category = 1},
            new Watch { Id = 7, Brand = "Junghans", Model = "Max Bill Automatic", Price = 11000m, Description = "Iconic Bauhaus-inspired watch.", ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimages.watchfinder.co.uk%2Fimages%2Fwatchfinderimages%2Fmedia%2Farticles%2F0%2F2022%2F04%2F19%2FJunghans-2.jpg&f=1&nofb=1&ipt=a8435b8d1c41ef69c52d7ee3805e5e2bac766561f99594c418ae88b98977d6fa", ReleaseYear = 2022, IsAvailable = true, Category = 1},
            new Watch { Id = 8, Brand = "Tag Heuer", Model = "Carrera", Price = 32000m, Description = "Luxury sports chronograph.", ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fmagazine.chrono24.com%2Fcdn-cgi%2Fimage%2Ff%3Dauto%2Cmetadata%3Dnone%2Cq%3D65%2F2023%2F06%2FHigh-Quality-JPG-CloseUp-2_V2_1-1-1-original.jpeg&f=1&nofb=1&ipt=35579b76e09f6da24a4c2e436bf5ab82bcb2e687b38ef79fc1d68f8dd8b27abc", ReleaseYear = 2021, IsAvailable = true, Category = 1},
            new Watch { Id = 9, Brand = "Garmin", Model = "Fenix 7", Price = 6990m, Description = "GPS multi-sport smartwatch.", ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.garmin.co.kr%2Fm%2Fkr%2Fg%2Fproducts%2Ffenix-7-solar-gray-cf-lg.jpg&f=1&nofb=1&ipt=5bc1ebebd1ef4ca31ef67215a38856b7cc11905867075ec558d94fe677ebc762", ReleaseYear = 2023, IsAvailable = true, Category = 3},
            new Watch { Id = 10, Brand = "Citizen", Model = "Eco-Drive Chronograph", Price = 3750m, Description = "Solar-powered chronograph.", ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi5.walmartimages.com%2Fasr%2Fec25b544-ae3a-4822-a85c-59eff685ca45.647bbaedc7c2296bc115f1a3c4f14060.jpeg%3FodnWidth%3D1000%26odnHeight%3D1000%26odnBg%3Dffffff&f=1&nofb=1&ipt=f6ea445cfc3dd2583563aae7a80356d47d579425c6ab10c1f7bf9e2c1fec27bd", ReleaseYear = 2020, IsAvailable = false, Category = 1},
           // new Watch {Id = 11, Brand ="Grand Seiko", Model ="SBGA413", Price = 65000m, Description ="Heritage collection a dial inspired by the cherry blossoms of spring in Japan", ImageUrl="https://www.grand-seiko.com/us-en/-/media/Images/Product--Image/All/GrandSeiko/2022/02/19/21/50/SBGA413G/SBGA413G.png", ReleaseYear= 2022 ,IsAvailable= false, Category=4},
           // new Watch {Id = 12, Brand ="Ressence", Model ="Type 3 Black", Price = 544500m, Description ="Re-imagines traditional watch design through innovative use of oil-filled chambers and magnetic transmission systems.", ImageUrl="https://feldmarwatch.com/wp-content/uploads/2024/02/type-35.jpg", ReleaseYear= 2013 ,IsAvailable= false, Category=1}
            ];

        // Set the PieId for each pie.
        // This is necessary because the PieId is not set in the original pie data  and we need it for testing purposes
        // This is a workaround to ensure that each pie has a unique PieId.
        // In a real application, this would be handled by the database.
        var mockWatchRepository = new Mock<IWatchRepository>();

        // Assign unique PieId to each pie
        mockWatchRepository.Setup(repo => repo.GetAllWatches()).Returns(watches);

        // Mock the GetPieById method to return the first pie when any id is requested.
        // This is necessary to simulate the behavior of the repository in the tests.
        // This is a workaround to ensure that the GetPieById method returns the correct pie.
        // This is necessary because the GetPieById method is not set in the original pie data and we need it for testing purposes.
        mockWatchRepository.Setup(repo => repo.GetWatchByID(It.IsAny<int>())).Returns(watches[0]);

        mockWatchRepository.Setup(repo => repo.AddWatch(It.IsAny<Watch>()));
        //    mockWatchRepository.Setup(repo => repo.AddWatch(It.IsAny<Watch>()))
        //        .Callback<Watch>(watch => {
        //            int nextId = watches.Count > 0 ? watches.Max(w => w.Id) + 1 : 1;
        //            watch.Id = nextId;
        //            watches.Add(watch);
        //        });
        return mockWatchRepository;
    }

    /// <summary>
    /// Creates and returns a mock implementation of the <see cref="ICategoryRepository"/> interface.
    /// </summary>
    /// <remarks>The returned mock repository is pre-configured to simulate the behavior of an <see
    /// cref="ICategoryRepository"/>  for testing purposes. It includes predefined watch categories such as "Analog",
    /// "Digital", "Smart", and "Hybrid",  each with an identifier, name, and description. The mock repository supports
    /// the following operations: <list type="bullet"> <item> <description><see
    /// cref="ICategoryRepository.GetAllCategories"/>: Returns the full list of predefined categories.</description>
    /// </item> <item> <description><see cref="ICategoryRepository.GetCategoryById(int)"/>: Retrieves a category by its
    /// identifier.</description> </item> <item> <description><see
    /// cref="ICategoryRepository.GetCategoryByName(string)"/>: Retrieves a category by its name, using a
    /// case-insensitive comparison.</description> </item> </list> This mock is useful for unit testing scenarios where
    /// a real implementation of <see cref="ICategoryRepository"/> is not required.</remarks>
    /// <returns>A mock implementation of the <see cref="ICategoryRepository"/> interface, pre-configured with predefined watch
    /// categories.</returns>
    public static Mock<ICategoryRepository> GetCategoryRepository() {

        /// <summary>
        /// Represents a collection of predefined watch categories.
        /// </summary>
        /// <remarks>Each category in the collection includes an identifier, a name, and a description that provides
        /// additional details about the category. This collection is initialized with a set of default categories, such as
        /// "Analog", "Digital", "Smart", and "Hybrid".</remarks>
        List<Category> categories = [
            new Category { Id = 1, Name = "Analog", Description = "Containing internal moving parts that need regular servicing."},
            new Category { Id = 2, Name = "Digital", Description = "Contains a battery that needs replacing when depleted."},
            new Category { Id = 3, Name = "Smart", Description ="Requires to be connected to a mobile phone or requires a sim-card."},
            new Category { Id = 4, Name = "Hybrid", Description ="It combines the traditional mechanical energy source (wound mainspring) with a quartz-based regulation system."},
            ];

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
        mockCategoryRepository.Setup(repo => repo.GetAllCategories()).Returns(categories);

        // Mock the GetCategoryById method to return the first category when any id is requested.
        // This is necessary to simulate the behavior of the repository in the tests and is a workaround to ensure that the
        mockCategoryRepository.Setup(repo => repo.GetCategoryById(It.IsAny<int>()))
            .Returns((int id) => categories.FirstOrDefault(c => c.Id == id));

        // GetCategoryByName method returns the correct category.
        // This is necessary because the GetCategoryByName method is not set in the original category data and we need it for testing purposes.
        mockCategoryRepository.Setup(repo => repo.GetCategoryByName(It.IsAny<string>()))
            .Returns((string name) => categories.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
        return mockCategoryRepository;
    }

}
