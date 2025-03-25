using Tracker.Domain.Entities;
using Tracker.Domain.Properties;

namespace Tracker.Domain.Lists;

public class TagList
{
    public Guid Id { get; set; }
    public required List<Tag> Tags { get; set; } = new();
    public required IApplicationUser Owner { get; set; } = null!;
}