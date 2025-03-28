namespace Tracker.Domain.Settings
{
    // Represents any kind of file saved in the server and it's controlled by the media service
    public class Media
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public required string FileName { get; set; }
        public required string ContentType { get; set; }
        public required string FilePath { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.Now;
        public string UploadedBy { get; set; } = null!;
    }
}