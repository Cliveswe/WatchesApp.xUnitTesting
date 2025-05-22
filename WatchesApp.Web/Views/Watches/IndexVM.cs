namespace WatchesApp.Web.Views.Watches;

public class IndexVM
{

    public List<WatchItemVM> WatchItems { get; set; } = null!;

    public List<CategoryItemVM> CategoryItems { get; set; } = null!;

    public class CategoryItemVM
    {
        public required int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string? Description { get; set; }
    }
    public class WatchItemVM
    {
        public required string Brand { get; set; } = string.Empty;
        public required string Model { get; set; } = string.Empty;
        public required decimal Price { get; set; }
        public required string? Description { get; set; }
        public required string? ImageUrl { get; set; }
        public required int? ReleaseYear { get; set; }
        public required int Category { get; set; } = default; // e.g., Analog, Digital, Smart, etc.
    }
}