namespace Tracker.Domain.Entities
{
    public class Movie
    {
        public Guid Id { get; private set; }

        // The title of the movie
        public string Title { get; private set; }

        // The description of the movie
        public string? Description { get; private set; }

        // The director of the movie
        public string? Director { get; private set; }

        // The genre of the movie
        public string? Genre { get; private set; }

        // A link to a website about the movie, e.g. IMDB, RottenTomatoes, etc
        public string? Url { get; private set; }

        // The duration of the movie in hours, minutes and seconds
        public TimeSpan? Duration { get; private set; }

        // The cover of the movie
        public Media? Cover { get; private set; }

        // The date and time the movie was created in the system.
        public DateTime CreatedAt { get; private set; }

        // The ID of the user who created the movie
        public string CreatedBy { get; private set; }

        // The date and time the movie was updated in the system.
        public DateTime? UpdatedAt { get; private set; }

        // The ID of the user who last updated the movie
        public string? UpdatedBy { get; private set; }

        private Movie() { }

        public Movie(
            string title,
            string createdBy,
            string? description = null,
            string? director = null,
            string? genre = null,
            string? url = null,
            TimeSpan? duration = null,
            Media? cover = null) 
        {
            Id = Guid.NewGuid();
            Title = !string.IsNullOrWhiteSpace(title)
                ? title
                : throw new ArgumentNullException(nameof(title), "Movie title cannot be empty.");
            Description = description;
            Director = director;
            Genre = genre;
            Url = url;
            Duration = duration;
            Cover = cover;
            CreatedAt = DateTime.Now;
            CreatedBy = !string.IsNullOrWhiteSpace(createdBy)
                ? createdBy
                : throw new ArgumentNullException(nameof(createdBy), "CreatedBy cannot be empty.");
        }

        public void UpdateDetails(
            string updatedBy,
            string? title = null,
            string? description = null,
            string? director = null,
            string? genre = null,
            string? url = null,
            TimeSpan? duration = null,
            Media? cover = null)
        {
            if (new object?[] { title, description, director, genre, url, duration, cover }.All(p => p == null))
                throw new ArgumentException("At least one parameter must be provided.");

            Title = title ?? Title;
            Description = description ?? Description;
            Director = director ?? Director;
            Genre = genre ?? Genre;
            Url = url ?? Url;
            Duration = duration ?? Duration;
            Cover = cover ?? Cover;
            UpdatedBy = !string.IsNullOrWhiteSpace(updatedBy)
                ? updatedBy
                : throw new ArgumentNullException(nameof(updatedBy), "UpdatedBy cannot be empty.");
            UpdatedAt = DateTime.Now;
        }

        public static Movie Load(
            Guid id,
            string createdBy,
            DateTime createdAt,
            string title,
            string? description = null,
            string? director = null,
            string? genre = null,
            string? url = null,
            TimeSpan? duration = null,
            Media? cover = null,
            string? updatedBy = null,
            DateTime? updatedAt = null)
        {
            return new Movie()
            {
                Id = id,
                Title = !string.IsNullOrWhiteSpace(title)
                    ? title
                    : throw new ArgumentNullException(nameof(title), "Movie title cannot be empty."),
                Description = description,
                Director = director,
                Genre = genre,
                Url = url,
                Duration = duration,
                Cover = cover,
                CreatedAt = createdAt,
                CreatedBy = !string.IsNullOrWhiteSpace(createdBy)
                    ? createdBy
                    : throw new ArgumentNullException(nameof(createdBy), "CreatedBy cannot be empty."),
                UpdatedAt = updatedAt,
                UpdatedBy = updatedBy
            };
        }
    }
}