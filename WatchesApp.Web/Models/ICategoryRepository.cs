namespace WatchesApp.Web.Models;

public interface ICategoryRepository
{
    List<Category> GetAllCategories();
    Category? GetCategoryById(int id);
}
