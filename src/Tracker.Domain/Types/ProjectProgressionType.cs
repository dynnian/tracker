namespace Tracker.Domain.Types
{
    /// <summary>
    /// Represents the type of progression for a project.
    /// </summary>
    /// <param name="Value"></param>
    public record ProjectProgressionType(string Value)
    {
        public static ProjectProgressionType OneTime { get; } = new ProjectProgressionType("One time");
        public static ProjectProgressionType OnGoing { get; } = new ProjectProgressionType("Ongoing");
    }
}
