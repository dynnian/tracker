namespace Tracker.Domain.Entities
{
    public class Season
    {
        public Guid Id { get; private set; }

        // The title of the season
        public string Name { get; private set; }

        // The description of the season
        public string? Description { get; private set; }

        // The number of the season
        public int Number { get; private set; }

        // The list of episodes in the season
        public List<Episode> Episodes { get; private set; }

        // The date and time the season was created in the system.
        public DateTime CreatedAt { get; private set; }

        // The ID of the user who created the season
        public string CreatedBy { get; private set; }

        // The date and time the season was last updated in the system.
        public DateTime? UpdatedAt { get; private set; }

        // The ID of the user who last updated the season
        public string? UpdatedBy { get; private set; }

        private Season() { }
    }
}