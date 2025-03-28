namespace Tracker.Domain.Collections
{
    using Tracker.Domain.Settings;

    public class WatchList
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required List<Movie> Movies { get; set; } = new();
        public required string OwnerUserId { get; set; } = null!;
    }
}