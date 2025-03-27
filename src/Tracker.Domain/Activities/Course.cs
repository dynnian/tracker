using Tracker.Domain.Entities;
using Tracker.Domain.Properties;

namespace Tracker.Domain.Activities;

public class Course
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public List<Tag> Tags { get; }
    public List<Subject> Subjects { get; }
    public List<Media> Files { get; }
    public string OwnerUserId { get; }
    public string? CertificateUrl { get; private set; }
    public Media? Certificate { get; private set; }
    public DateTime? StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public DateTime CreatedAt { get; }
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
        Subjects = subjects ?? [];
        Files = files ?? [];
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
}