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
        
        private Song() { }
        
        public Song(
            string title,
            string createdBy,
            Artist artist,
            Album album,
            string? genre = null,
            TimeSpan? duration = null)
        {
            Id = Guid.NewGuid();
            Title = !string.IsNullOrWhiteSpace(title)
                ? title
                : throw new ArgumentNullException(nameof(title), "Song title cannot be empty");
            CreatedBy = !string.IsNullOrWhiteSpace(createdBy)
                ? createdBy
                : throw new ArgumentNullException(nameof(createdBy), "CreatedBy cannot be empty");
            Artist = artist;
            Album = album;
            Genre = genre;
            Duration = duration;
            CreatedAt = DateTime.Now;
        }
        
        public void UpdateDetails(
            string updatedby,
            string? title = null,
            Artist? artist = null,
            Album? album = null,
            string? genre = null,
            TimeSpan? duration = null)
        {
            Title = title ?? Title;
            Artist = artist ?? Artist;
            Genre = genre ?? Genre;
            Album = album ?? Album;
            Duration = duration ?? Duration;
            UpdatedBy = !string.IsNullOrWhiteSpace(updatedby)
                ? updatedby
                : throw new ArgumentNullException(nameof(updatedby), "UpdatedBy cannot be empty");
            UpdatedAt = DateTime.Now;
        }
        
        public static Song Load(
            Guid id,
            string title,
            string createdBy,
            DateTime createdAt,
            Album album,
            Artist artist,
            string? genre = null,
            TimeSpan? duration = null,
            string? updatedBy = null,
            DateTime? UpdatedAt = null)
        {
            return new Song
            {
                Id = id,
                Title = !string.IsNullOrWhiteSpace(title)
                    ? title
                    : throw new ArgumentNullException(nameof(title), "Title cannot be empty"),
                Album = album,
                Artist = artist,
                Duration = duration,
                Genre = genre,
                CreatedAt = createdAt,
                CreatedBy = !string.IsNullOrWhiteSpace(createdBy)
                    ? createdBy
                    : throw new ArgumentNullException(nameof(createdBy), "Createdby cannot be empty"),
                UpdatedAt = UpdatedAt,
                UpdatedBy = updatedBy,
            };
        }
    }
}