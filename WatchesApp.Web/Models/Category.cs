using System.ComponentModel.DataAnnotations;

namespace WatchesApp.Web.Models;

public class Category
{
    public int Id { get; set; }

    [Display(Name = "Select from category")]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

}
