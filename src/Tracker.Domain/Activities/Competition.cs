namespace Tracker.Domain.Activities
{
    using Tracker.Domain.Settings;
    using Tracker.Domain.Entities;

    // Represents a competition a user has participated in.
    public class Competition
    {
        public Guid Id { get; private set; }

        // The name of the competition.
        public string Name { get; private set; }

        // A brief description of the competition.
        public string? Description { get; private set; }

        // The user ID of the owner of the competition.
        public string OwnerUserId { get; private set; }

        // The URL of the competition.
        public string? CompetitionUrl { get; private set; }

        // The URL of the certificate of the competition.
        public string? CertificateUrl { get; set; }

        // A list of tags associated with the competition. eg Completed, Ongoing, etc.
        public List<Tag>? Tags { get; }

        // A list of subjects related to the competition. eg. Machine Learning, Web Development, etc.
        public List<Subject>? RelatedSubjects { get; }

        // A list of files related to the competition.
        public List<Media>? Files { get; }

        // The date the competition started.
        public DateTime? StartDate { get; private set; }

        // The date the competition ended.
        public DateTime? EndDate { get; private set; }

        // The date the competition was created in the system.
        public DateTime CreatedAt { get; }

        // The date the competition was last updated in the system.
        public DateTime? UpdatedAt { get; private set; }

        private Competition() { }

        public Competition(
            string name,
            string ownerUserId,
            string? description = null,
            string? competitionUrl = null,
            string? certificateUrl = null,
            List<Tag>? tags = null,
            List<Subject>? subjects = null,
            List<Media>? files = null,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            OwnerUserId = ownerUserId;
            Description = description;
            CompetitionUrl = competitionUrl;
            CertificateUrl = certificateUrl;
            Tags = tags ?? new();
            RelatedSubjects = subjects ?? new();
            Files = files ?? new();
            StartDate = startDate;
            EndDate = endDate;
            CreatedAt = DateTime.Now;
        }

        public void UpdateDetails(
            string name,
            string? description = null,
            string? competitionUrl = null,
            string? certificateUrl = null,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            Name = name;
            Description = description;
            CompetitionUrl = competitionUrl;
            CertificateUrl = certificateUrl;
            StartDate = startDate;
            EndDate = endDate;
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