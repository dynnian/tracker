namespace Tracker.Domain.Entities
{
    public class Episode
    {
        public Guid Id { get; private set; }

        // The title of the episode
        public string Title { get; private set; }

        // The description of the episode
        public string? Description { get; private set; }

        // The episode number
        public int Number { get; private set; }

        // The date and time the episode was released
        public DateTime CreatedAt { get; private set; }

        // The ID of the user who created the episode
        public string CreatedBy { get; private set; }

        // The date and time the episode was last updated in the system.
        public DateTime? UpdatedAt { get; private set; }

        // The ID of the user who last updated the episode
        public string? UpdatedBy { get; private set; }

        private Episode() { }
    }
}