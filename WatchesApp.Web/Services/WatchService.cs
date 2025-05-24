// -----------------------------------------------------------------------------
// File: WatchService.cs
// Summary: Service class for managing a list of watches. Provides a thread-safe
//          singleton instance with methods to add and retrieve watches.
// <author> [Clive Leddy] </author>
// <created> [2025-05-23] </created>
// Notes: Preloaded with sample watches. Implements IWatchRepository for DI use.
// -----------------------------------------------------------------------------

using WatchesApp.Web.Models;

namespace WatchesApp.Web.Services;

/// <summary>
/// Provides functionality for managing a collection of watches, including adding new watches, retrieving all watches,
/// and accessing a singleton instance of the service.
/// </summary>
/// <remarks>The <see cref="WatchService"/> class is implemented as a thread-safe singleton, ensuring that only
/// one instance of the service exists throughout the application. It maintains a collection of watches with various
/// properties such as brand, model, price, and category. The service allows adding new watches to the collection and
/// retrieving all watches sorted by brand name.</remarks>
public class WatchService : IWatchRepository
{
    // Singleton instance of WatchService that is thread-safe and lazy initialization.
    private static WatchService? instance;
    private static readonly object lockObj = new object();
    private CategoryService categoryService = CategoryService.GetInstance;

    /// <summary>
    /// Gets the singleton instance of the <see cref="WatchService"/> class.
    /// </summary>
    /// <remarks>This property ensures thread-safe lazy initialization of the <see cref="WatchService"/>
    /// instance. Use this property to access the single shared instance of the service.</remarks>
    public static WatchService GetInstance {
        get {
            if(instance == null) {
                lock(lockObj) {
                    if(instance == null) {
                        instance = new WatchService();
                    }
                }
            }
            return instance;
        }
    }

    /// <summary>
    /// Represents a collection of predefined watches available in the system.
    /// </summary>
    /// <remarks>This list contains a set of watch objects, each with properties such as brand, model, price,
    /// description, image URL, release year, availability status, and category. The collection is initialized with a
    /// variety  of watches, including luxury, dress, sports, and smart-watches, to provide a diverse
    /// selection.</remarks>
    private List<Watch> watches = new List<Watch>
{
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
    new Watch {Id = 11, Brand ="Grand Seiko", Model ="SBGA413", Price = 65000m, Description ="Heritage collection a dial inspired by the cherry blossoms of spring in Japan", ImageUrl="https://www.grand-seiko.com/us-en/-/media/Images/Product--Image/All/GrandSeiko/2022/02/19/21/50/SBGA413G/SBGA413G.png", ReleaseYear= 2022 ,IsAvailable= false, Category=4},
    new Watch {Id = 12, Brand ="Ressence", Model ="Type 3 Black", Price = 544500m, Description ="Re-imagines traditional watch design through innovative use of oil-filled chambers and magnetic transmission systems.", ImageUrl="https://feldmarwatch.com/wp-content/uploads/2024/02/type-35.jpg", ReleaseYear= 2013 ,IsAvailable= false, Category=1}
};

    /// <summary>
    /// Gets the next available unique identifier for a new watch.
    /// </summary>
    private int NextId { get => watches.Count > 0 ? watches.Max(o => o.Id) + 1 : 1; }

    /// <summary>
    /// Adds a new watch to the collection and assigns it a unique identifier.
    /// </summary>
    /// <remarks>The <paramref name="watch"/> parameter must not be null. The method assigns a unique
    /// identifier to the watch before adding it to the collection.</remarks>
    /// <param name="watch">The watch to add. The <see cref="Watch.Id"/> property will be set to a unique value.</param>
    public void AddWatch(Watch watch) {
        int N = NextId;

        watch.Id = N;
        if(watch.ImageUrl == null) {
            watch.ImageUrl = "/images/no-picture-Square210.png"; // Default image URL if none provided
        }
        watches.Add(watch);
    }


    /// <summary>
    /// Retrieves all watches in the collection, sorted by brand name in ascending order.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Watch"/> objects, sorted by brand name in ascending order.</returns>
    public IEnumerable<Watch> GetAllWatches() {
        // Sort the watches by brand name in ascending order.
        watches.Sort((x, y) => x.Brand.CompareTo(y.Brand));
        return watches;
    }
}
