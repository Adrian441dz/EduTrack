namespace EduTrack.Core.Entities;

public class Group
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TeacherId { get; set; }
    public Teacher? Teacher { get; set; }

    public string Name { get; set; } = string.Empty;       // Ej. "Grupo A"
    public string GradeLevel { get; set; } = string.Empty; // Ej. "Preescolar 2°", "Confirmación Nivel 1"
    public string SchoolYear { get; set; } = string.Empty; // Ej. "2026-2027"
    public string Room { get; set; } = string.Empty;       // Ej. "Salón 4"
    public bool IsActive { get; set; } = true;

    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}