using Tracker.Domain.Entities;
using Tracker.Domain.Properties;

namespace Tracker.Domain.Activities;

public class Competition
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; set; }
    public List<Tag>? Tags { get; set; }
    public List<Subject>? Subjects { get; set; }
    public List<Media>? Files { get; set; }
    public required string OwnerUserId { get; set; }
    public string? CompetitionUrl { get; set; }
    public string? CertificateUrl { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

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
        Subjects = subjects ?? new();
        Files = files ?? new();
        StartDate = startDate;
        EndDate = endDate;
        CreatedAt = DateTime.Now;
    }
}