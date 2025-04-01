namespace Tracker.Domain.Entities
{
    public class Album
    {
        public Guid Id { get; private set; }

        // The title of the album
        public string Title { get; private set; }

        // The artist of the album
        public Artist Artist { get; private set; }

        // The genre of the album
        public string? Genre { get; private set; }

        // The release date of the album
        public DateOnly? ReleaseDate { get; private set; }

        // The cover of the album
        public Media? Cover { get; private set; }

        // The date and time the album was created in the system.
        public DateTime CreatedAt { get; private set; }

        // The ID of the user who created the album
        public string CreatedBy { get; private set; }

        // The date and time the album was updated in the system.
        public DateTime? UpdatedAt { get; private set; }

        // The ID of the user who last updated the album
        public string? UpdatedBy { get; private set; }
    }
}