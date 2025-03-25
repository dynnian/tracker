namespace Tracker.Domain.Exceptions;

public class InvalidImageFileTypeException(string message) : Exception(message);

public class InvalidVideoFileTypeException(string message) : Exception(message);

public class InvalidAudioFileTypeException(string message) : Exception(message);

public class InvalidDocumentFileTypeException(string message) : Exception(message);

public class NoItemsProvidedException(string message) : Exception(message);