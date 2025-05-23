// -----------------------------------------------------------------------------
// File: CreateVM.cs
// Summary: View model used for creating and managing watch items in the UI.
//          Includes form fields with validation and a list of category options 
//          for drop down selection.
// <author> [Clive Leddy] </author>
// <created> [2025-05-23] </created>
// Notes: Combines WatchItemVM for form input and CategoryItemVM for rendering 
//        category selections. Used in WatchesApp.Web.Views.Watches.
// -----------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace WatchesApp.Web.Views.Watches;

/// <summary>
/// Represents a view model for creating or managing watch items, including associated categories and details.
/// </summary>
/// <remarks>This class is designed to facilitate the creation and management of watch items in a user interface. 
/// It includes properties for watch details and category options, enabling seamless rendering and data
/// binding.</remarks>
public class CreateVM
{
    /// <summary>
    /// Gets or sets the list of available years, ordered in descending order, starting from the current year and going
    /// back to 1900.
    /// </summary>
    public List<int> AvailableYears { get; set; } = Enumerable.Range(1900, DateTime.Now.Year - 1899)
        .Reverse()
        .ToList();


    /// <summary>
    /// Gets or sets the collection of watch items to be displayed or managed.
    /// </summary>
    public required WatchItemVM WatchItems { get; set; }

    /// <summary>
    /// Gets or sets the list of category items used to render drop-down options.
    /// </summary>
    /// <remarks>This property is not included in the POST model and is intended solely for rendering
    /// purposes.</remarks>
    public List<CategoryItemVM> CategoryItems { get; set; } = new();

    /// <summary>
    /// Represents a view model for a category item, containing its unique identifier, name, and optional description.
    /// </summary>
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
        /// Gets or sets the description of the entity.
        /// </summary>
        public required string? Description { get; set; }
    }

    /// <summary>
    /// Represents a view model for a watch item, containing details such as brand, model, price, description, and
    /// availability.
    /// </summary>
    /// <remarks>This class is typically used to capture and display information about a watch in a user
    /// interface. It includes validation attributes to ensure required fields are provided and formatted
    /// correctly.</remarks>
    public class WatchItemVM
    {
        /// <summary>
        /// Gets or sets the name of the brand.
        /// </summary>
        /// <remarks>The brand name is required and must be specified. If not provided, a validation error
        /// will occur.</remarks>
        [Display(Prompt = "Brand Name.")]
        [Required(ErrorMessage = "You must specify a brand name.")]
        public string Brand { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the model reference.
        /// </summary>
        /// <remarks>The model is required and must be specified. If not provided, a validation error
        /// will occur.</remarks>
        [Display(Prompt = "Model reference.")]
        [Required(ErrorMessage = "You must specify a model.")]
        public string Model { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price of the watch.
        /// </summary>
        /// <remarks>This property is required and must be specified. The value is expected to be in a
        /// valid currency format.</remarks>
        [DataType(DataType.Currency)]
        [Display(Prompt = "Price.")]
        [Required(ErrorMessage = "All watchs have a value.")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets a short description.
        /// </summary>
        [Display(Prompt = "A short description.")]
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the URL of the image associated with the model.
        /// </summary>
        [Display(Prompt = "Link to model image.")]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the year of manufacture for the item.
        /// </summary>
        /// <remarks>The release year is required and must be specified. If not provided, a validation error
        /// will occur.</remarks>
        [DataType(DataType.Date)]
        [Display(Name = "Release Year.")]
        [Required(ErrorMessage = "Please select a year of manufacture.")]
        public int? ReleaseYear { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item is available.
        /// </summary>
        [Display(Name = "Check box if available.")]
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Gets or sets the selected category identifier.
        /// </summary>
        /// <remarks>The category represents a classification such as Analog, Digital, or Smart. A value
        /// must be provided to satisfy the <see cref="RequiredAttribute"/> constraint.</remarks>
        [Display(Name = "Select from category.")]
        [Required(ErrorMessage = "Please select a category.")]
        public int? Category { get; set; } = default; // e.g., Analog, Digital, Smart, etc.
    }

}
