namespace Tracker.Domain.Entities
{
    using Exceptions;
    using Types;
    using Validators;

    // Represents a project a user is working or has worked on.
    public sealed class Project
    {
        public Guid Id { get; private set; }

        // The name of the project.
        public string Name { get; private set; }

        // The user ID of the owner of the project.
        public string OwnerUserId { get; private set; }

        // A brief description of the project.
        public string? Description { get; private set; }

        // The URL of the project. It can be a GitHub repository, a blog post, etc.
        public string? ProjectUrl { get; private set; }

        // The icon associated with the project.
        public Media? Icon { get; private set; }

        // The type of progression of the project, can be ongoing or onetime
        public ProjectProgressionType ProgressionType { get; private set; }

        // The current state of the project
        public ActivityStatusType StatusType { get; private set; }

        // A list of tags associated with the project. eg Creative, Technical, Academic, etc.
        public List<Tag> Tags { get; private set; }

        // A list of files related to the project.
        public List<Media> Files { get; private set; }

        // A list of subjects related to the project. eg. Machine Learning, Web Development, etc.
        public List<Subject> RelatedSubjects { get; private set; }

        // A list of courses related to the project.
        public List<Course> RelatedCourses { get; private set; }

        // A list of competitions related to the project. An user may have participated in a competition with a project.
        public List<Competition> RelatedCompetitions { get; private set; }

        // A list of certifications related to the project. An user may have worked on a project on a certification.
        public List<Certification> RelatedCertifications { get; private set; }

        // The date the project started.
        public DateTime? StartDate { get; private set; }

        // If the project's progression type is onetime, the date the project ended.
        public DateTime? EndDate { get; private set; }

        // The date the project was created in the system.
        public DateTime CreatedAt { get; private set; }

        // The date the project was last updated in the system.
        public DateTime? UpdatedAt { get; private set; }

        // To prevent direct instantiation without data.
        private Project() { }

        public Project(
            string name,
            string owner,
            string? projectUrl = null,
            string? description = null,
            Media? icon = null,
            ProjectProgressionType? progressionType = null,
            ActivityStatusType? statusType = null,
            List<Tag>? tags = null,
            List<Media>? files = null,
            List<Subject>? subjects = null,
            List<Course>? courses = null,
            List<Competition>? competitions = null,
            List<Certification>? certifications = null,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            Id = Guid.NewGuid();
            Name = !string.IsNullOrWhiteSpace(name)
                ? name
                : throw new ArgumentNullException(nameof(name), "Project name cannot be empty.");
            OwnerUserId = !string.IsNullOrWhiteSpace(owner)
                ? owner
                : throw new ArgumentNullException(nameof(owner), "OwnerUserId cannot be empty.");
            Description = description;
            ProjectUrl = projectUrl;
            ValidateIcon(icon);
            ProgressionType = progressionType ?? ProjectProgressionType.OnGoing;
            StatusType = statusType ?? ActivityStatusType.NotStarted;
            Icon = icon;
            Tags = tags ?? [];
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
            ProjectProgressionType? progressionType = null,
            ActivityStatusType? statusType = null,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            if (new object?[] { name, description, projectUrl, startDate, endDate }.All(p => p == null))
                throw new ArgumentException("At least one parameter must be provided.");

            Name = name ?? Name;
            Description = description ?? Description;
            ProjectUrl = projectUrl ?? ProjectUrl;
            ProgressionType = progressionType ?? ProgressionType;
            StatusType = statusType ?? StatusType;
            StartDate = startDate ?? StartDate;
            EndDate = endDate ?? EndDate;
            UpdatedAt = DateTime.Now;
        }

        public static Project Load(
            Guid id,
            string name,
            string owner,
            DateTime createdAt,
            string? projectUrl = null,
            string? description = null,
            Media? icon = null,
            ProjectProgressionType? progressionType = null,
            ActivityStatusType? statusType = null,
            List<Tag>? tags = null,
            List<Media>? files = null,
            List<Subject>? subjects = null,
            List<Course>? courses = null,
            List<Competition>? competitions = null,
            List<Certification>? certifications = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            DateTime? updatedAt = null)
        {
            return new Project
            {
                Id = id,
                Name = name,
                OwnerUserId = owner,
                Description = description,
                ProjectUrl = projectUrl,
                Icon = icon,
                ProgressionType = progressionType ?? ProjectProgressionType.OnGoing,
                StatusType = statusType ?? ActivityStatusType.NotStarted,
                Tags = tags ?? [],
                Files = files ?? [],
                RelatedSubjects = subjects ?? [],
                RelatedCourses = courses ?? [],
                RelatedCompetitions = competitions ?? [],
                RelatedCertifications = certifications ?? [],
                StartDate = startDate,
                EndDate = endDate,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt
            };
        }

        public void UpdateIcon(Media icon)
        {
            ValidateIcon(icon);
            Icon = icon;
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

        public void AddCourses(List<Course> courses)
        {
            Utilities.AddItemsFromList(RelatedCourses, courses);
            UpdatedAt = DateTime.Now;
        }

        public void RemoveCourses(List<Course> courses)
        {
            Utilities.RemoveItemsFromList(RelatedCourses, courses);
            UpdatedAt = DateTime.Now;
        }

        public void AddCompetitions(List<Competition> competitions)
        {
            Utilities.AddItemsFromList(RelatedCompetitions, competitions);
            UpdatedAt = DateTime.Now;
        }

        public void RemoveCompetitions(List<Competition> competitions)
        {
            Utilities.RemoveItemsFromList(RelatedCompetitions, competitions);
            UpdatedAt = DateTime.Now;
        }

        public void AddCertifications(List<Certification> certifications)
        {
            Utilities.AddItemsFromList(RelatedCertifications, certifications);
            UpdatedAt = DateTime.Now;
        }

        public void RemoveCertifications(List<Certification> certifications)
        {
            Utilities.RemoveItemsFromList(RelatedCertifications, certifications);
            UpdatedAt = DateTime.Now;
        }

        private static void ValidateIcon(Media? icon)
        {
            if (icon != null && !FileTypeValidator.IsValidImageFileType(icon.ContentType))
            {
                throw new InvalidImageFileTypeException("Invalid image file type.");
            }
        }
    }
}
