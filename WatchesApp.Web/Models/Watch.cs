using System.ComponentModel.DataAnnotations;

namespace WatchesApp.Web.Models;

public class Watch
{
    public int Id { get; set; }

    [Required(ErrorMessage = "You must specify a brand name")]

    public string Brand { get; set; } = string.Empty;

    [Required(ErrorMessage = "You must specify a model")]
    public string Model { get; set; } = string.Empty;


    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    [Display(Name = "Release Year")]
    public int ReleaseYear { get; set; }

    [Display(Name = "Is Available")]
    public bool IsAvailable { get; set; }

    public int Category { get; set; } = default; // e.g., Analog, Digital, Smart, etc.
}
