namespace Tracker.Domain.Collections
{
    using Tracker.Domain.Entities;

    public class TagList
    {
        public Guid Id { get; set; }
        public required List<Tag> Tags { get; set; } = new();
        public required string OwnerUserId { get; set; } = null!;
    }
}