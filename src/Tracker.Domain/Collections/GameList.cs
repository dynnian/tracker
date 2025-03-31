namespace Tracker.Domain.Collections
{
    using Entities;

    public class GameList
    {
        public Guid Id { get; set; }
        public required List<Game> Games { get; set; } = new();
        public required string OwnerUserId { get; set; } = null!;
    }
}