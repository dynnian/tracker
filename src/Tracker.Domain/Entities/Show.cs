namespace Tracker.Domain.Entities
{
    public class Show
    {
        public Guid Id { get; private set; }

        // The title of the show
        public string Title { get; private set; }

        // The description of the show
        public string? Description { get; private set; }

        // The director of the show
        public string? Director { get; private set; }

        // The genre of the show
        public string? Genre { get; private set; }

        // A link to a website about the show, e.g. IMDB, RottenTomatoes, etc
        public string? Url { get; private set; }

        // The number of seasons in the show
        public int? Seasons { get; private set; }

        // The total number of episodes in the show
        public int? TotalEpisodes { get; private set; }

        // The list of seasons in the show
        public List<Season> SeasonsList { get; private set; }

        // The cover of the show
        public Media? Cover { get; private set; }

        // The date and time the show was created in the system.
        public DateTime CreatedAt { get; private set; }

        // The ID of the user who created the show
        public string CreatedBy { get; private set; }

        // The date and time the show was updated in the system.
        public DateTime? UpdatedAt { get; private set; }

        // The ID of the user who last updated the show
        public string? UpdatedBy { get; private set; }

        private Show() { }

        public Show(
            string title,
            string createdBy,
            string? description = null,
            string? director = null,
            string? genre = null,
            string? url = null,
            int? seasons = null,
            int? totalEpisodes = null,
            List<Season>? seasonsList = null,
            Media? cover = null)
        {
            Id = Guid.NewGuid();
            Title = !string.IsNullOrWhiteSpace(title)
                ? title
                : throw new ArgumentNullException(nameof(title), "Show title cannot be empty.");
            Description = description;
            Director = director;
            Genre = genre;
            Url = url;
            Seasons = seasons;
            SeasonsList = seasonsList ?? [];
            TotalEpisodes = totalEpisodes;
            Cover = cover;
            CreatedBy = !string.IsNullOrWhiteSpace(createdBy)
                ? createdBy
                : throw new ArgumentNullException(nameof(createdBy), "CreatedBy cannot be empty.");
            CreatedAt = DateTime.Now;
        }

        public void UpdateDetails(
            string updatedBy,
            string? title = null,
            string? description = null,
            string? director = null,
            string? genre = null,
            string? url = null,
            int? seasons = null,
            int? totalEpisodes = null,
            Media? cover = null)
        {
            if (new object?[] { title, description, director, genre, url, seasons, totalEpisodes, cover }.All(p => p == null))
                throw new ArgumentException("At least one parameter must be provided.");

            Title = title ?? Title;
            Description = description ?? Description;
            Director = director ?? Director;
            Genre = genre ?? Genre;
            Url = url ?? Url;
            Seasons = seasons ?? Seasons;
            TotalEpisodes = totalEpisodes ?? TotalEpisodes;
            Cover = cover ?? Cover;
            UpdatedBy = !string.IsNullOrWhiteSpace(updatedBy)
                ? updatedBy
                : throw new ArgumentNullException(nameof(updatedBy), "UpdatedBy cannot be empty.");
            UpdatedAt = DateTime.Now;
        }

        public static Show Load(
            Guid id,
            string createdBy,
            DateTime createdAt,
            string title,
            string? description = null,
            string? director = null,
            string? genre = null,
            string? url = null,
            int? seasons = null,
            int? totalEpisodes = null,
            Media? cover = null,
            string? updatedBy = null,
            DateTime? updatedAt = null)
        {
            return new Show
            {
                Id = id,
                Title = !string.IsNullOrWhiteSpace(title)
                    ? title
                    : throw new ArgumentNullException(nameof(title), "Show title cannot be empty."),
                Description = description,
                Director = director,
                Genre = genre,
                Url = url,
                Seasons = seasons,
                TotalEpisodes = totalEpisodes,
                Cover = cover,
                CreatedBy = !string.IsNullOrWhiteSpace(createdBy)
                    ? createdBy
                    : throw new ArgumentNullException(nameof(createdBy), "CreatedBy cannot be empty."),
                CreatedAt = createdAt,
                UpdatedBy = updatedBy,
                UpdatedAt = updatedAt
            };
        }
    }
}