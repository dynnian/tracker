namespace Tracker.Domain.Settings
{
    public class Episode
    {
        public Guid Id { get; set; }
        public required string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public int Number { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = null!;
        public required string CreatedBy { get; set; } = null!;
        public required string UpdatedBy { get; set; } = null!;
    }
}