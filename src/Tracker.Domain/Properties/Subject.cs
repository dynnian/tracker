using Tracker.Domain.Entities;

namespace Tracker.Domain.Properties;

// Denotes the concepts, technologies, or topics covered in a project, course, competition, etc.
public class Subject
{
    public int Id { get; set; }
    public required string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public IApplicationUser? CreatedBy { get; set; } = null!;
}