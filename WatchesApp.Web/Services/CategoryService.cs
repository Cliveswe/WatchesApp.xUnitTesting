// -----------------------------------------------------------------------------
// File: CategoryService.cs
// Summary: Singleton service implementing ICategoryRepository to manage and provide
//          predefined watch categories, with methods to get all categories or 
//          search by ID or name.
// Author: [Clive Leddy]
// Created: [2025-05-23]
// Notes: Thread-safe singleton with a static category list initialized at startup.
// -----------------------------------------------------------------------------

using WatchesApp.Web.Models;

namespace WatchesApp.Web.Services;

/// <summary>
/// Provides functionality for managing and retrieving predefined watch categories.
/// </summary>
/// <remarks>The <see cref="CategoryService"/> class implements the <see cref="ICategoryRepository"/> interface
/// and follows the singleton design pattern. It provides methods to retrieve all categories, as well as to search for
/// specific categories by their unique identifier or name.</remarks>
public class CategoryService : ICategoryRepository
{
    /// <summary>
    /// Represents a singleton instance of the <see cref="CategoryService"/> class.
    /// </summary>
    /// <remarks>This static field holds the single, shared instance of the <see cref="CategoryService"/>
    /// class. It is initialized eagerly and cannot be modified.</remarks>
    private static CategoryService instance = new();

    /// <summary>
    /// A static object used to synchronize access to shared resources in a thread-safe manner.
    /// </summary>
    /// <remarks>This object is intended to be used as a lock for critical sections of code that require 
    /// mutual exclusion to prevent race conditions. Ensure that all threads use this object consistently for locking
    /// to maintain proper synchronization.</remarks>
    private static readonly object lockObj = new object();

    /// <summary>
    /// Gets the singleton instance of the <see cref="CategoryService"/> class.
    /// </summary>
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

    /// <summary>
    /// Represents a collection of predefined watch categories.
    /// </summary>
    /// <remarks>Each category in the collection includes an identifier, a name, and a description that provides
    /// additional details about the category. This collection is initialized with a set of default categories, such as
    /// "Analog", "Digital", "Smart", and "Hybrid".</remarks>
    private List<Category> categories = new List<Category> {
        new Category { Id = 1, Name = "Analog", Description = "Containing internal moving parts that need regular servicing."},
        new Category { Id = 2, Name = "Digital", Description = "Contains a battery that needs replacing when depleted."},
        new Category { Id = 3, Name = "Smart", Description ="Requires to be connected to a mobile phone or requires a sim-card."},
        new Category { Id = 4, Name = "Hybrid", Description ="It combines the traditional mechanical energy source (wound mainspring) with a quartz-based regulation system."},
    };

    /// <summary>
    /// Retrieves all categories in the collection.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Category"/> objects representing all categories. The collection
    /// will be empty if no categories are available.</returns>
    public IEnumerable<Category> GetAllCategories() => categories;

    /// <summary>
    /// Retrieves a category by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the category to retrieve.</param>
    /// <returns>The <see cref="Category"/> object with the specified identifier, or <see langword="null"/> if no category with
    /// the given identifier exists.</returns>
    public Category? GetCategoryById(int id) {
        var res = categories.FirstOrDefault(c => c.Id == id);
        return res;
    }

    /// <summary>
    /// Retrieves a category from the collection that matches the specified name.
    /// </summary>
    /// <param name="name">The name of the category to search for. This value is case-sensitive and cannot be null.</param>
    /// <returns>The <see cref="Category"/> object that matches the specified name, or <see langword="null"/> if no matching category
    /// is found.</returns>
    public Category? GetCategoryByName(string name) => categories.Find(c => c.Name == name);
}
