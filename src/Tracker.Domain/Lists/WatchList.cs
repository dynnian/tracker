using Tracker.Domain.Entities;

namespace Tracker.Domain.Lists;

public class WatchList
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required List<Movie> Movies { get; set; } = new();
    public required IApplicationUser Owner { get; set; }
}