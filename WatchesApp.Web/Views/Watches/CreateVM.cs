using System.ComponentModel.DataAnnotations;

namespace WatchesApp.Web.Views.Watches;

public class CreateVM
{
    public required WatchItemVM WatchItems { get; set; }
    public required List<CategoryItemVM> CategoriesItems { get; set; }

    public class CategoryItemVM
    {
        public required int Id { get; set; }


        public required string Name { get; set; } = string.Empty;
        public required string? Description { get; set; }
    }

    public class WatchItemVM
    {
        [Required(ErrorMessage = "You must specify a brand name")]
        [Display(Prompt = "Name of Brand")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must specify a model")]
        [Display(Prompt = "Model reference")]
        public string Model { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Price")]
        [Display(Prompt = "Price")]
        public decimal Price { get; set; }

        [Display(Prompt = "A short description")]
        public string? Description { get; set; }

        [Display(Prompt = "Link to model image")]
        public string? ImageUrl { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Year")]
        [Required(ErrorMessage = "Please select a year")]
        public int? ReleaseYear { get; set; }

        [Display(Name = "Check box if available")]
        [Required(ErrorMessage = "Yes/No")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Select from category")]
        public int Category { get; set; } = default; // e.g., Analog, Digital, Smart, etc.
    }

}
