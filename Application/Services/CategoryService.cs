// -----------------------------------------------------------------------------
// File: CategoryService.cs
// Summary: Provides a simple service for accessing and searching predefined watch
//          categories through a repository. Supports getting all categories or
//          finding by ID or name.
// <author> [Clive Leddy] </author>
// <created> [2025-05-23] </created>
// Remarks: Implements ICategoryRepository to provide a higher-level interface for
//          category management. Designed to be used in Razor Pages projects, it
//          wraps an ICategoryRepository and delegates all category operations to it.
// <remarks>Updated [2025-06-10] to remove singleton pattern and focus on repository
//        delegation. This class now serves as a simple service for accessing and
//        searching predefined watch categories through an injected repository.</remarks>
// Notes: Designed for use in Razor Pages projects. Wraps an ICategoryRepository
//        and delegates all category operations to it.
// -----------------------------------------------------------------------------

using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

/// <summary>
/// Provides functionality for managing and retrieving predefined watch categories.
/// </summary>
/// <remarks>The <see cref="CategoryService"/> class implements the <see cref="ICategoryRepository"/> interface
/// and follows the singleton design pattern. It provides methods to retrieve all categories, as well as to search for
/// specific categories by their unique identifier or name.</remarks>
public class CategoryService(ICategoryRepository repository) : ICategoryRepository
{

    /// <summary>
    /// Retrieves all categories in the collection.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Category"/> objects representing all categories. The collection
    /// will be empty if no categories are available.</returns>
    public IEnumerable<Category> GetAllCategories() => repository.GetAllCategories();

    /// <summary>
    /// Retrieves a category by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the category to retrieve.</param>
    /// <returns>The <see cref="Category"/> object with the specified identifier, or <see langword="null"/> if no category with
    /// the given identifier exists.</returns>
    public Category? GetCategoryById(int id) => repository.GetCategoryById(id);

    /// <summary>
    /// Retrieves a category by its name.
    /// </summary>
    /// <param name="name">The name of the category to retrieve. Cannot be null or empty.</param>
    /// <returns>The <see cref="Category"/> object that matches the specified name, or <see langword="null"/> if no matching
    /// category is found.</returns>
    public Category? GetCategoryByName(string name) => repository.GetCategoryByName(name);
}
