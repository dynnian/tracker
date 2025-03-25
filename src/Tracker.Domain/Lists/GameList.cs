using Tracker.Domain.Entities;

namespace Tracker.Domain.Lists;

public class GameList
{
    public Guid Id { get; set; }
    public required List<Game> Games { get; set; } = new();
    public required string Owner { get; set; } = null!;
}