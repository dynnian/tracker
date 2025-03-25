using Tracker.Domain.Entities;

namespace Tracker.Domain.Properties;

// Denotes the state of a given entity, such as a course, project, competition, etc.
public class Tag
{
    public int Id { get; set; }
    public required string Name { get; set; } = null!;
    public Color Color { get; set; } = null!;
    public List<object>? Entities { get; set; } = new();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public IApplicationUser? CreatedBy { get; set; } = null!;
}