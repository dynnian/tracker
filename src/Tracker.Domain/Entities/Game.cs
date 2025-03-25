namespace Tracker.Domain.Entities;

public class Game
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? Genre { get; set; } = null!;
    public string? Url { get; set; } = null!;
    public string? Publisher { get; set; } = null!;
    public string? Platform { get; set; } = null!;
    public Media? Cover { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = null!;
    public required string CreatedBy { get; set; } = null!;
    public required string UpdatedBy { get; set; } = null!;
}