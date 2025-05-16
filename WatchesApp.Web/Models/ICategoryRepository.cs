namespace WatchesApp.Web.Models;

public interface ICategoryRepository
{
    IEnumerable<Category> AllCategories { get; }
    Category? GetCategoryById(int id);
}
