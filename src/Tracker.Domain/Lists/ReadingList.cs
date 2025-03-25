using Tracker.Domain.Entities;

namespace Tracker.Domain.Lists;

public class ReadingList
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required List<Book> Books { get; set; } = new();
    public required string Owner { get; set; }
}