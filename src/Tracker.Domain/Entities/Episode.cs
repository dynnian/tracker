namespace Tracker.Domain.Entities;

public class Episode
{
    public Guid Id { get; set; }
    public required string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public int Number { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = null!;
    public required IApplicationUser CreatedBy { get; set; } = null!;
    public required IApplicationUser UpdatedBy { get; set; } = null!;
}