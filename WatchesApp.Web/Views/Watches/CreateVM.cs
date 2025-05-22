using System.ComponentModel.DataAnnotations;

namespace WatchesApp.Web.Views.Watches;

public class CreateVM
{
    public required WatchItemVM WatchItems { get; set; }

    //CategoryItems is not part of the POST model. It is only used to render
    //the drop down options.
    public List<CategoryItemVM> CategoryItems { get; set; } = new();

    public class CategoryItemVM
    {
        public required int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
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
        [Required(ErrorMessage = "You must specify a brand name.")]
        [Display(Prompt = "Brand Name.")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must specify a model.")]
        [Display(Prompt = "Model reference.")]
        public string Model { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "All watchs have a value.")]
        [Display(Prompt = "Price.")]
        public decimal? Price { get; set; }

        [Display(Prompt = "A short description.")]
        public string? Description { get; set; }

        [Display(Prompt = "Link to model image.")]
        public string? ImageUrl { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Year.")]
        [Required(ErrorMessage = "Please select a year of manufacture.")]
        public int? ReleaseYear { get; set; }

        [Display(Name = "Check box if available.")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Select from category.")]
        [Required(ErrorMessage = "Please select a category.")]
        public int? Category { get; set; } = default; // e.g., Analog, Digital, Smart, etc.
    }

}
