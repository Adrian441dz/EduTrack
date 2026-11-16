namespace EduTrack.Core.Entities;

public class Student
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid GroupId { get; set; }
    public Group? Group { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly DateOfBirth { get; set; }

    // Semáforo Rojo: Alertas Médicas y Alergias
    public bool HasMedicalAlert { get; set; } = false;
    public string? MedicalAlertDetails { get; set; }

    // Contacto de Emergencia y Seguimiento
    public string GuardianName { get; set; } = string.Empty;
    public string EmergencyPhone { get; set; } = string.Empty;
    public string? PedagogicalNotes { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}