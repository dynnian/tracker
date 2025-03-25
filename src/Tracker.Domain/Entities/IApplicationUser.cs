namespace Tracker.Domain.Entities;

public interface IApplicationUser
{
    string Id { get; set; }
    string? UserName { get; set; }
    string? Email { get; set; }
}