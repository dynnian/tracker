namespace Tracker.Domain.Entities;

public class Show
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? Director { get; set; } = null!;
    public string? Genre { get; set; } = null!;
    public string? Url { get; set; } = null!;
    public List<Season> Seasons { get; set; } = new();
    public Media? Cover { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = null!;
    public required string CreatedBy { get; set; } = null!;
    public required string UpdatedBy { get; set; } = null!;
}