namespace Tracker.Domain.Entities;

public class Book
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? Author { get; set; } = null!;
    public string? Publisher { get; set; } = null!;
    public string? Isbn { get; set; } = null!;
    public string? Url { get; set; } = null!;
    public int Pages { get; set; }
    public Media? Cover { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = null!;
    public required string CreatedBy { get; set; } = null!;
    public required string UpdatedBy { get; set; } = null!;
}