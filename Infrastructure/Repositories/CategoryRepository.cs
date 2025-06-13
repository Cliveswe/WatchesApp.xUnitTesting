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


    /// <summary>
    /// Represents a collection of predefined watch categories.
    /// </summary>
    /// <remarks>Each category in the collection includes an identifier, a name, and a description that provides
    /// additional details about the category. This collection is initialized with a set of default categories, such as
    /// "Analog", "Digital", "Smart", and "Hybrid".</remarks>
    private readonly List<Category> categories = [
        new Category { Id = 1, Name = "Analog", Description = "Containing internal moving parts that need regular servicing."},
        new Category { Id = 2, Name = "Digital", Description = "Contains a battery that needs replacing when depleted."},
        new Category { Id = 3, Name = "Smart", Description ="Requires to be connected to a mobile phone or requires a sim-card."},
        new Category { Id = 4, Name = "Hybrid", Description ="It combines the traditional mechanical energy source (wound mainspring) with a quartz-based regulation system."},
    ];

    /// <summary>
    /// Retrieves all categories sorted by their names in ascending order.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> containing all categories, ordered by name.</returns>
    public IEnumerable<Category> GetAllCategories() => categories.OrderBy(c => c.Name);

    /// <summary>
    /// Retrieves a category by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the category to retrieve.</param>
    /// <returns>The <see cref="Category"/> object with the specified identifier, or <see langword="null"/>  if no category with
    /// the given identifier exists.</returns>
    public Category? GetCategoryById(int id) =>
        categories.FirstOrDefault(c => c.Id == id);

    /// <summary>
    /// Retrieves a category by its name.
    /// </summary>
    /// <param name="name">The name of the category to search for. This parameter is case-insensitive.</param>
    /// <returns>The <see cref="Category"/> object that matches the specified name, or <see langword="null"/> if no matching
    /// category is found.</returns>
    public Category? GetCategoryByName(string name) =>
        categories.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
}
