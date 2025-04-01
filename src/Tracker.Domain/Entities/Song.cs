namespace Tracker.Domain.Entities
{
    public class Song
    {
        public Guid Id { get; private set; }

        // The title of the song
        public string Title { get; private set; }

        // The artist of the song
        public Artist Artist { get; private set; }

        // The album of the song
        public Album Album { get; private set; }

        // The genre of the song
        public string? Genre { get; private set; }

        // The duration of the song in hours, minutes and seconds
        public TimeSpan? Duration { get; private set; }

        // The date and time the song was created in the system.
        public DateTime CreatedAt { get; private set; }

        // The ID of the user who created the song
        public string CreatedBy { get; private set; }

        // The date and time the song was updated in the system.
        public DateTime? UpdatedAt { get; private set; }

        // The ID of the user who last updated the song
        public string? UpdatedBy { get; private set; }
    }
}