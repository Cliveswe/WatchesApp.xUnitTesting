// -----------------------------------------------------------------------------
// File: ICategoryRepository.cs
// Summary: Interface defining repository methods to access watch categories,
//          including retrieval by ID, name, and fetching all categories.
// <author> [Clive Leddy] </author>
// <created> [2025-05-23] </created>
// Notes: Enables abstraction for category data access within the WatchesApp.
// -----------------------------------------------------------------------------

namespace WatchesApp.Web.Models;

/// <summary>
/// Defines a contract for accessing and managing category data.
/// </summary>
/// <remarks>This interface provides methods to retrieve category information by various criteria, such as
/// retrieving all categories, finding a category by its unique identifier, or searching by name. Implementations of
/// this interface are responsible for ensuring the integrity and consistency of the category data.</remarks>
public interface ICategoryRepository
{
    /// <summary>
    /// Retrieves all categories available in the system.
    /// </summary>
    /// <remarks>This method provides a read-only view of the categories. The caller should not assume any
    /// specific order of the returned categories unless explicitly documented elsewhere.</remarks>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Category"/> objects representing all categories. The collection
    /// will be empty if no categories are available.</returns>
    IEnumerable<Category> GetAllCategories();

    /// <summary>
    /// Retrieves a category by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the category to retrieve. Must be a non-negative integer.</param>
    /// <returns>The <see cref="Category"/> object corresponding to the specified <paramref name="id"/>, or <see
    /// langword="null"/> if no category with the given identifier exists.</returns>
    Category? GetCategoryById(int id);

    /// <summary>
    /// Retrieves a category by its name.
    /// </summary>
    /// <param name="name">The name of the category to retrieve. This value cannot be null or empty.</param>
    /// <returns>The <see cref="Category"/> object that matches the specified name, or <see langword="null"/> if no category with
    /// the given name exists.</returns>
    Category? GetCategoryByName(string name);
}
