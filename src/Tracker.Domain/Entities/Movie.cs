namespace Tracker.Domain.Entities;

public class Movie
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? Director { get; set; } = null!;
    public string? Genre { get; set; } = null!;
    public string? Url { get; set; } = null!;
    public Media? Cover { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = null!;
    public required IApplicationUser CreatedBy { get; set; } = null!;
    public required IApplicationUser UpdatedBy { get; set; } = null!;
}