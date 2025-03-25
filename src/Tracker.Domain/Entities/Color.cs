namespace Tracker.Domain.Entities;

public class Color
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; } = null!;
    public required string Hex { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public required IApplicationUser CreatedBy { get; set; } = null!;
}