namespace EduTrack.Core.Entities;

public class Teacher
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string IdentityUserId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SchoolName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Group> Groups { get; set; } = new List<Group>();
}