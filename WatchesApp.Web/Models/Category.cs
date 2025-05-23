// -----------------------------------------------------------------------------
// File: Category.cs
// Summary: Model class representing a watch category with ID, name, and optional
//          description. Used for grouping watches in the application.
// <author> [Clive Leddy] </author>
// <created> [2025-05-23] </created>
// Notes: Commonly linked with watch items to organize them by type.
// -----------------------------------------------------------------------------

namespace WatchesApp.Web.Models;

/// <summary>
/// Represents a category with an identifier, name, and optional description.
/// </summary>
/// <remarks>This class is commonly used to categorize or group related entities in an application. The <see
/// cref="Id"/> property uniquely identifies the category, while the <see cref="Name"/> provides a readable
/// label. The <see cref="Description"/> property can be used to store additional details about the category.</remarks>
public class Category
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name associated with the object.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description associated with the object.
    /// </summary>
    public string? Description { get; set; }

}
