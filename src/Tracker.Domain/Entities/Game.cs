namespace Tracker.Domain.Entities
{
    public class Game
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public string? Genre { get; private set; }
        public string? Url { get; private set; }
        public string? Publisher { get; private set; }
        public string? Platform { get; private set; }
        public Media? Cover { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string CreatedBy { get; private set; }
        public string? UpdatedBy { get; private set; }

        private Game() { }

        public Game(
            string name,
            string createdBy,
            string? description = null,
            string? genre = null,
            string? url = null,
            string? publisher = null,
            string? platform = null,
            Media? cover = null)
        {
            Id = Guid.NewGuid();
            Name = !string.IsNullOrWhiteSpace(name)
                ? name
                : throw new ArgumentNullException(nameof(name), "Game name cannot be empty.");
            Description = description;
            Genre = genre;
            Url = url;
            Publisher = publisher;
            Platform = platform;
            Cover = cover;
            CreatedBy = !string.IsNullOrWhiteSpace(createdBy)
                ? createdBy
                : throw new ArgumentNullException(nameof(createdBy), "CreatedBy cannot be empty.");
            CreatedAt = DateTime.Now;
        }

        public void UpdateDetails(
            string updatedBy,
            string? name = null,
            string? description = null,
            string? genre = null,
            string? url = null,
            string? publisher = null,
            string? platform = null,
            Media? cover = null)
        {
            if (new object?[] { name, description, genre, url, publisher, platform, cover }.All(p => p == null))
                throw new ArgumentException("At least one parameter must be provided.");

            Name = name ?? Name;
            Description = description ?? Description;
            Genre = genre ?? Genre;
            Url = url ?? Url;
            Publisher = publisher ?? Publisher;
            Platform = platform ?? Platform;
            Cover = cover ?? Cover;
            UpdatedBy = !string.IsNullOrWhiteSpace(updatedBy)
                ? updatedBy
                : throw new ArgumentNullException(nameof(updatedBy), "UpdatedBy cannot be empty.");
            UpdatedAt = DateTime.Now;
        }

        public static Game Load(
            Guid id,
            string name,
            string createdBy,
            DateTime createdAt,
            string? description = null,
            string? genre = null,
            string? url = null,
            string? publisher = null,
            string? platform = null,
            Media? cover = null)
        {
            return new Game
            {
                Id = id,
                Name = name,
                Description = description,
                Genre = genre,
                Url = url,
                Publisher = publisher,
                Platform = platform,
                Cover = cover,
                CreatedBy = createdBy,
                CreatedAt = createdAt
            };
        }
    }
}