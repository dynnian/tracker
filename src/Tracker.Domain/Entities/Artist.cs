namespace Tracker.Domain.Entities
{
    public class Artist
    {
        public Guid Id { get; private set; }

        // The name of the artist
        public string Name { get; private set; }

        // The genre of the artist
        public string? Genre { get; private set; }

        // The biography of the artist
        public string? Biography { get; private set; }

        // The date of birth of the artist
        public DateOnly? DateOfBirth { get; private set; }

        // The date of death of the artist
        public DateOnly? DateOfDeath { get; private set; }

        // The cover of the artist
        public Media? ProfilePicture { get; private set; }

        // The date and time the artist was created in the system.
        public DateTime CreatedAt { get; private set; }

        // The ID of the user who created the artist
        public string CreatedBy { get; private set; }

        // The date and time the artist was updated in the system.
        public DateTime? UpdatedAt { get; private set; }

        // The ID of the user who last updated the artist
        public string? UpdatedBy { get; private set; }

        private Artist() { }

        public Artist(
            string name,
            string createdBy,
            string? genre = null,
            string? biography = null,
            DateOnly? dateOfBirth = null,
            DateOnly? dateOfDeath = null,
            Media? profilePicture = null)
        {
            Id = Guid.NewGuid();
            Name = !string.IsNullOrWhiteSpace(name)
                ? name
                : throw new ArgumentNullException(nameof(name), "Artist name cannot be empty.");
            Genre = genre;
            Biography = biography;
            DateOfBirth = dateOfBirth;
            DateOfDeath = dateOfDeath;
            ProfilePicture = profilePicture;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        public void UpdateDetails(
            string updatedBy,
            string? name = null,
            string? genre = null,
            string? biography = null,
            DateOnly? dateOfBirth = null,
            DateOnly? dateOfDeath = null,
            Media? profilePicture = null)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name;
            if (!string.IsNullOrWhiteSpace(genre))
                Genre = genre;
            if (!string.IsNullOrWhiteSpace(biography))
                Biography = biography;
            if (dateOfBirth.HasValue)
                DateOfBirth = dateOfBirth;
            if (dateOfDeath.HasValue)
                DateOfDeath = dateOfDeath;
            if (profilePicture != null)
                ProfilePicture = profilePicture;

            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = !string.IsNullOrWhiteSpace(updatedBy)
                ? updatedBy
                : throw new ArgumentNullException(nameof(updatedBy), "UpdatedBy cannot be empty.");
        }

        public static Artist Load(
            Guid id,
            string name,
            string createdBy,
            DateTime createdAt,
            string updatedBy,
            DateTime? updatedAt = null,
            string? genre = null,
            string? biography = null,
            DateOnly? dateOfBirth = null,
            DateOnly? dateOfDeath = null,
            Media? profilePicture = null)
        {
            return new Artist(name, "System")
            {
                Id = id,
                Genre = genre,
                Biography = biography,
                DateOfBirth = dateOfBirth,
                DateOfDeath = dateOfDeath,
                ProfilePicture = profilePicture,
                CreatedAt = createdAt,
                CreatedBy = createdBy,
                UpdatedAt = updatedAt,
                UpdatedBy = updatedBy
            };
        }
    }
}