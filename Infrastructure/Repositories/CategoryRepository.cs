using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private static CategoryRepository? instance;
    private static readonly object lockObj = new();


    public static CategoryRepository GetInstance {
        get {
            if(instance == null) {
                lock(lockObj) {
                    if(instance == null) {
                        instance = new CategoryRepository();
                    }
                }
            }
            return instance;
        }
    }


    public IEnumerable<Category> GetAllCategories() {
        throw new NotImplementedException();
    }

    public Category? GetCategoryById(int id) {
        throw new NotImplementedException();
    }

    public Category? GetCategoryByName(string name) {
        throw new NotImplementedException();
    }
}
