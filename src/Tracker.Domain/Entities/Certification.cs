namespace Tracker.Domain.Entities
{
    // Represents a certification an user is currently pusuing or has completed.
    public class Certification
    {
        public Guid Id { get; private set; }

        // The name of the certification.
        public string Name { get; private set; }

        // The user ID of the owner of the certification.
        public string OwnerUserId { get; private set; }

        // A brief description of the certification.
        public string? Description { get; private set; }

        // The URL of the certificate.
        public string? CertificateUrl { get; private set; }

        // The certificate file.
        public Media? Certificate { get; private set; }

        // A list of tags associated with the certification. eg Creative, Technical, Academic, etc.
        public List<Tag> Tags { get; private set; }

        // A list of subjects related to the certification. eg. Cloud, Development, Cibersecurity, etc.
        public List<Subject> RelatedSubjects { get; private set; }

        // A list of courses related to the certification.
        public List<Media> Files { get; private set; }

        // The date the certification started.
        public DateTime? StartDate { get; private set; }

        // If the certification's progression type is onetime, the date the certification ended.
        public DateTime? EndDate { get; private set; }

        // The date the certification was created in the system.
        public DateTime CreatedAt { get; private set; }

        // The date the certification was last updated in the system.
        public DateTime? UpdatedAt { get; private set; }

        private Certification() { }

        public Certification(
            string name,
            string owner,
            string? description = null,
            string? certificateUrl = null,
            Media? certificate = null,
            List<Tag>? tags = null,
            List<Subject>? subjects = null,
            List<Media>? files = null,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            Id = Guid.NewGuid();
            Name = !string.IsNullOrWhiteSpace(name)
                ? name
                : throw new ArgumentNullException(nameof(name), "Project name cannot be empty.");
            OwnerUserId = !string.IsNullOrWhiteSpace(owner)
                ? owner
                : throw new ArgumentNullException(nameof(owner), "OwnerUserId cannot be empty.");
            Description = description;
            CertificateUrl = certificateUrl;
            Certificate = certificate;
            Tags = tags ?? [];
            RelatedSubjects = subjects ?? [];
            Files = files ?? [];
            StartDate = startDate;
            EndDate = endDate;
            CreatedAt = DateTime.Now;
        }

        public void UpdateDetails(
            string? name = null,
            string? description = null,
            string? certificateUrl = null,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            if (new object?[] { name, description, certificateUrl, startDate, endDate }.All(p => p == null))
                throw new ArgumentException("At least one parameter must be provided.");

            Name = name ?? Name;
            Description = description ?? Description;
            CertificateUrl = certificateUrl ?? CertificateUrl;
            StartDate = startDate ?? StartDate;
            EndDate = endDate ?? EndDate;
            UpdatedAt = DateTime.Now;
        }

        public static Certification Load(
            Guid id,
            string name,
            string owner,
            DateTime createdAt,
            List<Tag>? tags = null,
            List<Subject>? subjects = null,
            List<Media>? files = null,
            string? description = null,
            string? certificateUrl = null,
            Media? certificate = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            DateTime? updatedAt = null)
        {
            return new Certification
            {
                Id = id,
                Name = name,
                OwnerUserId = owner,
                Description = description,
                CertificateUrl = certificateUrl,
                Certificate = certificate,
                Tags = tags ?? [],
                RelatedSubjects = subjects ?? [],
                Files = files ?? [],
                StartDate = startDate,
                EndDate = endDate,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt
            };
        }

        public void AddTags(List<Tag> tags)
        {
            Utilities.AddItemsFromList(Tags, tags);
            UpdatedAt = DateTime.Now;
        }

        public void RemoveTags(List<Tag> tags)
        {
            Utilities.RemoveItemsFromList(Tags, tags);
            UpdatedAt = DateTime.Now;
        }

        public void AddFiles(List<Media> files)
        {
            Utilities.AddItemsFromList(Files, files);
            UpdatedAt = DateTime.Now;
        }

        public void RemoveFiles(List<Media> files)
        {
            Utilities.RemoveItemsFromList(Files, files);
            UpdatedAt = DateTime.Now;
        }

        public void AddSubjects(List<Subject> subjects)
        {
            Utilities.AddItemsFromList(RelatedSubjects, subjects);
            UpdatedAt = DateTime.Now;
        }

        public void RemoveSubjects(List<Subject> subjects)
        {
            Utilities.RemoveItemsFromList(RelatedSubjects, subjects);
            UpdatedAt = DateTime.Now;
        }
    }
}
