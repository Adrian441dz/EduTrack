using EduTrack.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.Infrastructure.Persistence;

public class EduTrackDbContext : IdentityDbContext
{
    public EduTrackDbContext(DbContextOptions<EduTrackDbContext> options) : base(options)
    {
    }

    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Attendance> Attendances => Set<Attendance>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Teacher: Índice único vinculado al usuario de Identity
        builder.Entity<Teacher>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.HasIndex(t => t.IdentityUserId).IsUnique();
            entity.Property(t => t.FullName).HasMaxLength(120).IsRequired();
            entity.Property(t => t.SchoolName).HasMaxLength(150);
        });

        // Group: Relación con Teacher
        builder.Entity<Group>(entity =>
        {
            entity.HasKey(g => g.Id);
            entity.Property(g => g.Name).HasMaxLength(50).IsRequired();
            entity.Property(g => g.GradeLevel).HasMaxLength(80).IsRequired();
            entity.Property(g => g.SchoolYear).HasMaxLength(20).IsRequired();
            entity.HasOne(g => g.Teacher)
                  .WithMany(t => t.Groups)
                  .HasForeignKey(g => g.TeacherId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Student: Expediente y Semáforo Médico
        builder.Entity<Student>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.FirstName).HasMaxLength(80).IsRequired();
            entity.Property(s => s.LastName).HasMaxLength(100).IsRequired();
            entity.Property(s => s.GuardianName).HasMaxLength(120).IsRequired();
            entity.Property(s => s.EmergencyPhone).HasMaxLength(25).IsRequired();
            entity.Property(s => s.MedicalAlertDetails).HasMaxLength(300);
            entity.HasOne(s => s.Group)
                  .WithMany(g => g.Students)
                  .HasForeignKey(s => s.GroupId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Attendance: Regla de negocio de 1 registro único por alumno por día
        builder.Entity<Attendance>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.HasIndex(a => new { a.StudentId, a.Date }).IsUnique();
            entity.HasOne(a => a.Student)
                  .WithMany(s => s.Attendances)
                  .HasForeignKey(a => a.StudentId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(a => a.Group)
                  .WithMany(g => g.Attendances)
                  .HasForeignKey(a => a.GroupId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}