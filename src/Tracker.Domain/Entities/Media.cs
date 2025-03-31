namespace Tracker.Domain.Entities
{
    // Represents any kind of file saved in the server and it's controlled by the media service
    public class Media
    {
        public Guid Guid { get; private set; }
        public string FileName { get; private set; }
        public string ContentType { get; private set; }
        public string FilePath { get; private set; }
        public long FileSize { get; private set; }
        public string UploadedBy { get; private set; }
        public DateTime UploadedAt { get; private set; }

        private Media() { }

        public Media(
            string fileName,
            string contentType,
            string filePath,
            long fileSize,
            string uploadedBy)
        {
            Guid = Guid.NewGuid();
            FileName = fileName;
            ContentType = contentType;
            FilePath = filePath;
            FileSize = fileSize;
            UploadedBy = uploadedBy;
            UploadedAt = DateTime.Now;
        }

        public static Media Load(
            Guid guid,
            string fileName,
            string contentType,
            string filePath,
            long fileSize,
            string uploadedBy,
            DateTime uploadedAt)
        {
            return new Media
            {
                Guid = guid,
                FileName = fileName,
                ContentType = contentType,
                FilePath = filePath,
                FileSize = fileSize,
                UploadedBy = uploadedBy,
                UploadedAt = uploadedAt
            };
        }
    }
}