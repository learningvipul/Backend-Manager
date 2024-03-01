using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackendManager.Models;

public partial class LogbookContext : DbContext
{
    public LogbookContext()
    {
    }

    public LogbookContext(DbContextOptions<LogbookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<ExerciseSet> ExerciseSets { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<MuscleGroup> MuscleGroups { get; set; }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Logbook;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exercise__3214EC27C236397A");

            entity.ToTable("Exercise");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExerciseName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.MuscleGroupNavigation).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.MuscleGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Exercise__Muscle__286302EC");
        });

        modelBuilder.Entity<ExerciseSet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Exercise__3214EC271FD720FD");

            entity.ToTable("ExerciseSet");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExerciseDate).HasColumnType("datetime");

            entity.HasOne(d => d.ExerciseNavigation).WithMany(p => p.ExerciseSets)
                .HasForeignKey(d => d.Exercise)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExerciseS__Exerc__2F10007B");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => new { e.Person, e.Exercise }).HasName("PK__Goal__0B93F87B2BC69E09");

            entity.ToTable("Goal");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.ExerciseNavigation).WithMany(p => p.Goals)
                .HasForeignKey(d => d.Exercise)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Goal__Exercise__2C3393D0");

            entity.HasOne(d => d.PersonNavigation).WithMany(p => p.Goals)
                .HasForeignKey(d => d.Person)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Goal__Person__2B3F6F97");
        });

        modelBuilder.Entity<MuscleGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MuscleGr__3214EC27BAB33C59");

            entity.ToTable("MuscleGroup");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC27132AE101");

            entity.ToTable("Person");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Pass)
                .HasMaxLength(2550)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
