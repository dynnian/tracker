namespace Tracker.Domain.Types
{
    public record ActivityStatusType(string Value)
    {
        public static ActivityStatusType Ongoing => new ActivityStatusType("Ongoing");

        public static ActivityStatusType InProgress => new ActivityStatusType("In progress");

        public static ActivityStatusType Completed => new ActivityStatusType("Completed");

        public static ActivityStatusType Dropped => new ActivityStatusType("Dropped");

        public static ActivityStatusType OnHold => new ActivityStatusType("On hold");

        public static ActivityStatusType Planned => new ActivityStatusType("Planned");

        public static ActivityStatusType NotStarted => new ActivityStatusType("Not started");

        public static ActivityStatusType Unknown => new ActivityStatusType("Unknown");
    }
}
