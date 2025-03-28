namespace Tracker.Domain.Activities
{
    using Tracker.Domain.Entities;
    using Tracker.Domain.Settings;

    public class Certification
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string OwnerUserId { get; private set; }
        public string? Description { get; private set; }
        public List<Tag>? Tags { get; }
        public List<Subject>? RelatedSubjects { get; }
        public List<Media>? Files { get; }
        public string? CertificateUrl { get; private set; }
        public Media? Certificate { get; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; private set; }
    }
}