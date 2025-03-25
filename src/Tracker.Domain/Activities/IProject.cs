using Tracker.Domain.Entities;
using Tracker.Domain.Properties;

namespace Tracker.Domain.Activities;

public interface IProject
{
    public Guid Id { get; }
    public string Name { get; }
    public string? Description { get; }
    public string? ProjectUrl { get; }
    public IApplicationUser Owner { get; }
    public Media? Icon { get; }
    public List<Media>? Files { get; }
    public List<Subject>? Subjects { get; }
    public DateTime? StartDate { get; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; }
}