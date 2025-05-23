// -----------------------------------------------------------------------------
// File: Category.cs
// Summary: Model class representing a watch category with ID, name, and optional
//          description. Used for grouping watches in the application.
// Author: [Clive Leddy]
// Created: [2025-05-23]
// Notes: Commonly linked with watch items to organize them by type.
// -----------------------------------------------------------------------------

namespace WatchesApp.Web.Views.Watches;

/// <summary>
/// Represents the view model for the index page, containing collections of watch items and category items.
/// </summary>
/// <remarks>This class serves as a container for the data displayed or managed on the index page of an
/// application. It includes a collection of <see cref="WatchItemVM"/> objects, which represent individual watch items,
/// and a collection of <see cref="CategoryItemVM"/> objects, which represent categories or groupings.</remarks>
public class IndexVM
{
    /// <summary>
    /// Gets or sets the collection of watch items to be displayed or managed.
    /// </summary>
    public required List<WatchItemVM> WatchItems { get; set; }

    /// <summary>
    /// Gets or sets the collection of category items.
    /// </summary>
    public required List<CategoryItemVM> CategoryItems { get; set; }

    /// <summary>
    /// Represents a category item with an identifier, name, and optional description.
    /// </summary>
    /// <remarks>This class is typically used to model a category or grouping entity in an application. The
    /// <see cref="Id"/> uniquely identifies the category, while the <see cref="Name"/> provides a readable label.
    /// The <see cref="Description"/> is optional and can be used to provide additional details about the
    /// category.</remarks>
    public class CategoryItemVM
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public required int Id { get; set; }

        /// <summary>
        /// Gets or sets the name associated with the object.
        /// </summary>
        public required string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description associated with the object.
        /// </summary>
        public required string? Description { get; set; }
    }

    /// <summary>
    /// Represents a view model for a watch item, containing details such as brand, model, price, and other related
    /// information.
    /// </summary>
    /// <remarks>This class is designed to encapsulate the key properties of a watch item, including its
    /// brand, model, price, description,  image URL, release year, and category. It can be used in scenarios where
    /// watch-related data needs to be displayed or processed.</remarks>
    public class WatchItemVM
    {
        /// <summary>
        /// Gets or sets the brand name of the product.
        /// </summary>
        public required string Brand { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the model name associated with the object.
        /// </summary>
        public required string Model { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price of the item.
        /// </summary>
        public required decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the description of the entity.
        /// </summary>
        public required string? Description { get; set; }

        /// <summary>
        /// Gets or sets the URL of the image associated with this entity.
        /// </summary>
        public required string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the release year of the item.
        /// </summary>
        public required int? ReleaseYear { get; set; }

        /// <summary>
        /// Gets or sets the category identifier for the item.
        /// </summary>
        public required int Category { get; set; } = default; // e.g., Analog, Digital, Smart, etc.
    }
}