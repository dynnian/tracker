using Tracker.Domain.Entities;
using Tracker.Domain.Properties;

namespace Tracker.Domain.Activities;

public interface IProject
{
    public Guid Id { get; }
    public string Name { get; }
    public string? Description { get; }
    public string? ProjectUrl { get; }
    public string OwnerUserId { get; }
    public Media? Icon { get; }
    public List<Media>? Files { get; }
    public List<Course>? RelatedCourses { get; }
    public List<Subject>? RelatedSubjects { get; }
    public List<Competition>? RelatedCompetitions { get; }
    public List<Certification>? RelatedCertifications { get; }
    public DateTime? StartDate { get; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; }
}