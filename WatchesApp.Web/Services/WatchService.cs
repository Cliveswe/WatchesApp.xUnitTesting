using WatchesApp.Web.Models;

namespace WatchesApp.Web.Services;

public class WatchService : IWatchRepository
{
    // Singleton instance of WatchService that is thread-safe and lazy initialization.
    private static WatchService? instance;
    private static readonly object lockObj = new object();

    /// <summary>
    /// Gets the singleton instance of the WatchService.
    /// </summary>
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

    private List<Watch> watches = new List<Watch>
{
    new Watch { Id = 1, Brand = "Nomos", Model = "Max Bill Chronoscope", Price = 2100m, Description = "Chronograph with minimalist Bauhaus aesthetics.", ImageUrl = "/images/nomos-maxbill-chronoscope.jpg", ReleaseYear = 2022, IsAvailable = true, Category = "Analog" },
    new Watch { Id = 2, Brand = "Frederique Constant", Model = "Classics Index", Price = 995m, Description = "Elegant Swiss dress watch.", ImageUrl = "/images/frederique-classics.jpg", ReleaseYear = 2021, IsAvailable = true, Category = "Analog" },
    new Watch { Id = 3, Brand = "Samsung", Model = "Galaxy Watch 6", Price = 399m, Description = "Advanced smartwatch with health tracking.", ImageUrl = "/images/samsung-galaxywatch6.jpg", ReleaseYear = 2023, IsAvailable = true, Category = "Smart" },
    new Watch { Id = 4, Brand = "Casio", Model = "G-Shock GA-100", Price = 120m, Description = "Rugged and durable digital watch.", ImageUrl = "/images/casio-gshock.jpg", ReleaseYear = 2020, IsAvailable = true, Category = "Digital" },
    new Watch { Id = 5, Brand = "Seiko", Model = "Presage Cocktail Time", Price = 450m, Description = "Elegant dress watch.", ImageUrl = "/images/seiko-presage.jpg", ReleaseYear = 2019, IsAvailable = false, Category = "Analog" },
    new Watch { Id = 6, Brand = "Tissot", Model = "PRX Powermatic 80", Price = 650m, Description = "Automatic watch with 80-hour power reserve.", ImageUrl = "/images/tissot-prx.jpg", ReleaseYear = 2021, IsAvailable = true, Category = "Analog" },
    new Watch { Id = 7, Brand = "Junghans", Model = "Max Bill Automatic", Price = 1100m, Description = "Iconic Bauhaus-inspired watch.", ImageUrl = "/images/junghans-maxbill.jpg", ReleaseYear = 2022, IsAvailable = true, Category = "Analog" },
    new Watch { Id = 8, Brand = "Tag Heuer", Model = "Carrera", Price = 3200m, Description = "Luxury sports chronograph.", ImageUrl = "/images/tag-carrera.jpg", ReleaseYear = 2021, IsAvailable = true, Category = "Analog" },
    new Watch { Id = 9, Brand = "Garmin", Model = "Fenix 7", Price = 699m, Description = "GPS multisport smartwatch.", ImageUrl = "/images/garmin-fenix.jpg", ReleaseYear = 2023, IsAvailable = true, Category = "Smart" },
    new Watch { Id = 10, Brand = "Citizen", Model = "Eco-Drive Chronograph", Price = 375m, Description = "Solar-powered chronograph.", ImageUrl = "/images/citizen-eco.jpg", ReleaseYear = 2020, IsAvailable = false, Category = "Analog" },
};


    public void AddWatch(Watch watch) {
        throw new NotImplementedException();
    }

    public void DeleteWatch(int id) {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get all watches sorted by brand name in ascending order.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Watch> GetAllWatches() {
        // Sort the watches by brand name in ascending order.
        watches.Sort((x, y) => x.Brand.CompareTo(y.Brand));
        return watches;
    }

    public Watch? GetWatchById(int id) {
        throw new NotImplementedException();
    }

    public void UpdateWatch(Watch watch) {
        throw new NotImplementedException();
    }
}
