using Tracker.Domain.Entities;
using Tracker.Domain.Properties;
using Tracker.Domain.Validators;

namespace Tracker.Domain.Activities;

public sealed class OngoingProject : IProject
{
    public Guid Id { get; }
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public string? ProjectUrl { get; private set; }
    public IApplicationUser Owner { get; } = null!;
    public Media? Icon { get; private set; }
    public List<Media>? Files { get; private set; }
    public List<Subject>? Subjects { get; private set; }
    public DateTime? StartDate { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; private set; }

    private OngoingProject() { }

    public OngoingProject(
        string name, 
        string description, 
        string projectUrl, 
        IApplicationUser owner,
        Media? icon = null,
        List<Media>? files = null,
        DateTime? startDate = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        ProjectUrl = projectUrl;
        Owner = owner;
        Icon = icon;
        if (Icon != null && !FormatValidator.IsValidImageFileType(Icon.ContentType))
        {
            throw new ArgumentException("Invalid image file type.", nameof(icon));
        }
        Files = files ?? new();
        StartDate = startDate;
        CreatedAt = DateTime.Now;
    }

    public void UpdateDetails(
        string? name = null,
        string? description = null,
        string? projectUrl = null,
        DateTime? startDate = null)
    {
        if (name == null && description == null && projectUrl == null && startDate == null)
        {
            throw new ArgumentException("At least one parameter must be provided.");
        }

        Name = name ?? Name;
        Description = description ?? Description;
        ProjectUrl = projectUrl ?? ProjectUrl;
        StartDate = startDate ?? StartDate;
        UpdatedAt = DateTime.Now;
    }

    public void UpdateIcon(Media icon)
    {
        Icon = icon;
        if (!FormatValidator.IsValidImageFileType(Icon.ContentType))
        {
            throw new ArgumentException("Invalid image file type.", nameof(icon));
        }
        UpdatedAt = DateTime.Now;
    }

    public void AddFiles(List<Media> files)
    {
        if (files == null || files.Count == 0)
        {
            throw new ArgumentException("No files provided.");
        }
        foreach (var file in files)
        {
            Files?.Add(file);
        }
        UpdatedAt = DateTime.Now;
    }

    public void RemoveFiles(List<Media> files)
    {
        if (files == null || files.Count == 0)
        {
            throw new ArgumentException("No files provided.");
        }
        foreach (var file in files)
        {
            Files?.Remove(file);
        }
        UpdatedAt = DateTime.Now;
    }
}