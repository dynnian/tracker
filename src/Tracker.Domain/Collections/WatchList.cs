namespace Tracker.Domain.Collections
{
    using Entities;

    public class WatchList
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required List<Movie> Movies { get; set; } = new();
        public required string OwnerUserId { get; set; } = null!;
    }
}