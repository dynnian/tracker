namespace Tracker.Domain.Activities
{
    using Tracker.Domain.Settings;
    using Tracker.Domain.Entities;

    // Represents a course a user is taking or has taken.
    public class Course
    {
        public Guid Id { get; private set; }

        // The name of the course.
        public string Name { get; private set; }

        // A brief description of the course.
        public string? Description { get; private set; }

        // A list of tags associated with the course. eg Completed, Ongoing, etc.
        public List<Tag> Tags { get; }

        // A list of subjects related to the course. eg. Machine Learning, Web Development, etc.
        public List<Subject> RelatedSubjects { get; }

        // A list of files related to the course.
        public List<Media> RelatedFiles { get; }

        // The user ID of the owner of the course.
        public string OwnerUserId { get; }

        // The URL of the certificate of the course.
        public string? CertificateUrl { get; private set; }

        // The certificate file of the course.
        public Media? Certificate { get; private set; }

        // The date the course started.
        public DateTime? StartDate { get; private set; }

        // The date the course ended.
        public DateTime? EndDate { get; private set; }

        // The date the course was created in the system.
        public DateTime CreatedAt { get; }

        // The date the course was last updated in the system.
        public DateTime? UpdatedAt { get; private set; }

        private Course() { }

        public Course(
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
            Name = name;
            OwnerUserId = owner;
            Description = description;
            CertificateUrl = certificateUrl;
            Certificate = certificate;
            Tags = tags ?? [];
            RelatedSubjects = subjects ?? [];
            RelatedFiles = files ?? [];
            StartDate = startDate;
            EndDate = endDate;
            CreatedAt = DateTime.Now;
        }

        public void UpdateDetails(
            string? name = null,
            string? description = null,
            string? certificateUrl = null,
            Media? certificate = null,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            Name = name ?? Name;
            Description = description ?? Description;
            CertificateUrl = certificateUrl ?? CertificateUrl;
            Certificate = certificate ?? Certificate;
            StartDate = startDate ?? StartDate;
            EndDate = endDate ?? EndDate;
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

        public void AddFiles(List<Media> files)
        {
            Utilities.AddItemsFromList(RelatedFiles, files);
            UpdatedAt = DateTime.Now;
        }

        public void RemoveFiles(List<Media> files) 
        { 
            Utilities.RemoveItemsFromList(RelatedFiles, files);
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