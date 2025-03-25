using Tracker.Domain.Entities;
using Tracker.Domain.Exceptions;
using Tracker.Domain.Properties;
using Tracker.Domain.Validators;

namespace Tracker.Domain.Activities;

public sealed class OnetimeProject : IProject
{
    public Guid Id { get; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string? ProjectUrl { get; private set; }
    public string Owner { get; }
    public Media? Icon { get; private set; }
    public List<Media> Files { get; }
    public List<Subject> RelatedSubjects { get; }
    public List<Course> RelatedCourses { get; }
    public List<Competition> RelatedCompetitions { get; }
    public List<Certification> RelatedCertifications { get; }
    public DateTime? StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; private set; }

    private OnetimeProject() { }

    public OnetimeProject(
        string name,
        string description,
        string projectUrl,
        string owner,
        Media? icon = null,
        List<Media>? files = null,
        List<Subject>? subjects = null,
        List<Course>? courses = null,
        List<Competition>? competitions = null,
        List<Certification>? certifications = null,
        DateTime? startDate = null,
        DateTime? endDate = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        ProjectUrl = projectUrl;
        Owner = owner;
        ValidateIcon(icon);
        Icon = icon;
        Files = files ?? [];
        RelatedSubjects = subjects ?? [];
        RelatedCourses = courses ?? [];
        RelatedCompetitions = competitions ?? [];
        RelatedCertifications = certifications ?? [];
        StartDate = startDate;
        EndDate = endDate;
        CreatedAt = DateTime.Now;
    }

    public void UpdateDetails(
        string? name = null,
        string? description = null,
        string? projectUrl = null,
        DateTime? startDate = null,
        DateTime? endDate = null)
    {
        if (name == null && description == null && projectUrl == null && startDate == null && endDate == null)
        {
            throw new ArgumentException("At least one parameter must be provided.");
        }

        Name = name ?? Name;
        Description = description ?? Description;
        ProjectUrl = projectUrl ?? ProjectUrl;
        StartDate = startDate ?? StartDate;
        EndDate = endDate ?? EndDate;
        UpdatedAt = DateTime.Now;
    }

    public void UpdateIcon(Media icon)
    {
        ValidateIcon(icon);
        Icon = icon;
        UpdatedAt = DateTime.Now;
    }

    public void AddFiles(List<Media> files) => AddItems(Files, files);

    public void RemoveFiles(List<Media> files) => RemoveItems(Files, files);

    public void AddSubjects(List<Subject> subjects) => AddItems(RelatedSubjects, subjects);

    public void RemoveSubjects(List<Subject> subjects) => RemoveItems(RelatedSubjects, subjects);

    public void AddCourses(List<Course> courses) => AddItems(RelatedCourses, courses);

    public void RemoveCourses(List<Course> courses) => RemoveItems(RelatedCourses, courses);

    public void AddCompetitions(List<Competition> competitions) => AddItems(RelatedCompetitions, competitions);

    public void RemoveCompetitions(List<Competition> competitions) => RemoveItems(RelatedCompetitions, competitions);

    public void AddCertifications(List<Certification> certifications) => AddItems(RelatedCertifications, certifications);

    public void RemoveCertifications(List<Certification> certifications) => RemoveItems(RelatedCertifications, certifications);

    private void ValidateIcon(Media? icon)
    {
        if (icon != null && !FileTypeValidator.IsValidImageFileType(icon.ContentType))
        {
            throw new InvalidImageFileTypeException("Invalid image file type.");
        }
    }

    private void AddItems<T>(List<T> targetList, List<T> items)
    {
        if (items == null || items.Count == 0)
        {
            throw new NoItemsProvidedException("No items provided.");
        }
        targetList.AddRange(items);
        UpdatedAt = DateTime.Now;
    }

    private void RemoveItems<T>(List<T> targetList, List<T> items)
    {
        if (items == null || items.Count == 0)
        {
            throw new NoItemsProvidedException("No items provided.");
        }
        foreach (var item in items)
        {
            targetList.Remove(item);
        }
        UpdatedAt = DateTime.Now;
    }
}