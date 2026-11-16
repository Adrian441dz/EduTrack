namespace EduTrack.Core.Entities;

public enum AttendanceStatus
{
    Present = 1, // Verde (Por defecto)
    Absent = 2,  // Rojo (Cuenta para alerta de 3 faltas)
    Late = 3,    // Amarillo
    Excused = 4  // Azul
}

public class Attendance
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid StudentId { get; set; }
    public Student? Student { get; set; }

    public Guid GroupId { get; set; }
    public Group? Group { get; set; }

    public DateOnly Date { get; set; }
    public AttendanceStatus Status { get; set; } = AttendanceStatus.Present;
    public string? Notes { get; set; }
}