namespace Tracker.Domain.Validators;

public static class FormatValidator
{
    public static bool IsValidImageFileType(string contentType)
    {
        var validImageFileTypes = new List<string> { "image/jpeg", "image/png", "image/gif" };
        return validImageFileTypes.Contains(contentType);
    }
}