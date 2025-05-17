using WatchesApp.Web.Models;

namespace WatchesApp.Web.Services;

public class CategoryService : ICategoryRepository
{
    private static CategoryService instance;

    private static readonly object lockObj = new object();
    public static CategoryService GetInstance {
        get {
            if(instance == null) {
                lock(lockObj) {
                    if(instance == null)
                        instance = new CategoryService();
                }
            }
            return instance;
        }
    }

    private List<Category> categories = new List<Category> {
        new Category { Id = 1, Name = "Analog", Description = "Containing internal moving parts that need regular servicing."},
        new Category { Id = 2, Name = "Digital", Description = "Contains a battery that needs replacing when depleted."},
        new Category { Id = 3, Name = "Smart", Description ="Requires to be connected to a mobile phone or requires a sim-card."},
        new Category { Id = 4, Name = "Hybrid", Description ="It combines the traditional mechanical energy source (wound mainspring) with a quartz-based regulation system."},
    };

    public IEnumerable<Category> GetAllCategories() => categories;

    public Category? GetCategoryById(int id) {
        var res = categories.FirstOrDefault(c => c.Id == id);
        return res;
    }

    public Category GetCategoryByName(string name) => categories.Find(c => c.Name == name);
}
