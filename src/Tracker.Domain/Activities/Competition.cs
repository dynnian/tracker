using Tracker.Domain.Entities;
using Tracker.Domain.Properties;

namespace Tracker.Domain.Activities;

public class Competition
{
    public int Id { get; set; }
    public required string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public List<Tag>? Tags { get; set; } = new();
    public List<Subject>? Subjects { get; set; } = new();
    public List<Media>? Files { get; set; } = new();
    public required IApplicationUser Participant { get; set; }
    public string? CompetitionUrl { get; set; } = null!;
    public string? CertificateUrl { get; set; } = null!;
    public DateTime? StartDate { get; set; } = null!;
    public DateTime? EndDate { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = null!;
}