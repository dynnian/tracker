namespace Tracker.Domain.Collections
{
    using Tracker.Domain.Settings;

    public class ReadingList
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required List<Book> Books { get; set; } = new();
        public required string OwnerUserId { get; set; } = null!;
    }
}