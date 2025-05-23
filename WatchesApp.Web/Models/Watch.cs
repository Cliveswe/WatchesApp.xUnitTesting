// -----------------------------------------------------------------------------
// File: Watch.cs
// Summary: Data model representing a watch. Includes properties for brand,
//          model, price, availability, and more. Used for form input and display.
// Author: [Clive Leddy]
// Created: [2025-05-23]
// Notes: Includes validation attributes for form handling in Razor views.
// -----------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace WatchesApp.Web.Models;

public class Watch
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the brand.
    /// </summary>
    /// <remarks>The Brand must be valid and is required for form submissions. If not provided,
    /// a validation error will occur.</remarks>
    [Display(Prompt = "Name of Brand")]
    [Required(ErrorMessage = "You must specify a brand name")]
    public string Brand { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the model reference.
    /// </summary>
    /// <remarks>The Model must be valid and is required for form submissions. If not provided,
    /// a validation error will occur.</remarks>
    [Display(Prompt = "Model reference")]
    [Required(ErrorMessage = "You must specify a model")]
    public string Model { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price of the item.
    /// </summary>
    /// <remarks>The Price must be valid and is required for form submissions. If not provided,
    /// a validation error will occur.</remarks>
    [DataType(DataType.Currency)]
    [Display(Prompt = "Price")]
    [Required(ErrorMessage = "Price")]
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets a short description.
    /// </summary>
    [Display(Prompt = "A short description")]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the URL of the image associated with the model.
    /// </summary>
    [Display(Prompt = "Link to model image")]
    public string? ImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the release year of the item.
    /// </summary>
    /// <remarks>The release year must be a valid year and is required for form submissions. If not provided,
    /// a validation error will occur.</remarks>
    [DataType(DataType.Date)]
    [Display(Name = "Release Year")]
    [Required(ErrorMessage = "Please select a year")]
    public int? ReleaseYear { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the item is available.
    /// </summary>
    /// <remarks>The IsAvailable must be valid and is required for form submissions. If not provided,
    /// a validation error will occur.</remarks>
    [Display(Name = "Check box if available")]
    [Required(ErrorMessage = "Yes/No")]
    public bool IsAvailable { get; set; }

    /// <summary>
    /// Gets or sets the category identifier for the item.
    /// </summary>
    [Display(Name = "Select from category")]
    public int Category { get; set; } = default; // e.g., Analog, Digital, Smart, etc.
}
