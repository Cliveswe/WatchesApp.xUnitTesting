namespace WatchesApp.Web.Models;

public interface ICategoryRepository
{
    IEnumerable<Category> GetAllCategories();
    Category? GetCategoryById(int id);
}
