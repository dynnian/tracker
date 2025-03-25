namespace Tracker.Domain.Validators;

public static class FileTypeValidator
{
    public static bool IsValidImageFileType(string contentType)
    {
        var validImageFileTypes = new List<string> { "image/jpeg", "image/png", "image/gif" };
        return validImageFileTypes.Contains(contentType);
    }

    public static bool IsValidVideoFileType(string contentType)
    {
        var validVideoFileTypes = new List<string> { "video/mp4", "video/quicktime" };
        return validVideoFileTypes.Contains(contentType);
    }

    public static bool IsValidAudioFileType(string contentType)
    {
        var validAudioFileTypes = new List<string> { "audio/mpeg", "audio/wav" };
        return validAudioFileTypes.Contains(contentType);
    }

    public static bool IsValidDocumentFileType(string contentType)
    {
        var validDocumentFileTypes = new List<string> { "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };
        return validDocumentFileTypes.Contains(contentType);
    }
}