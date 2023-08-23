using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectManagementPRN221.Models
{
    public partial class ProjectManagementContext : DbContext
    {
        public ProjectManagementContext()
        {
        }

        public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =localhost; database = ProjectManagement;uid=sa;pwd=123;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.Email, "UQ__Account__A9D105342AEADFE7")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Account__RoleId__3A81B327");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.FinishDate).HasColumnType("date");

                entity.Property(e => e.IsFinished)
                    .HasColumnName("isFinished")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProjectName).HasMaxLength(255);

                entity.Property(e => e.Topic).HasMaxLength(100);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__Project__TeamId__48CFD27E");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Mssv)
                    .HasName("PK__Student__6CB3B7F91C282067");

                entity.ToTable("Student");

                entity.Property(e => e.Mssv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MSSV");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Cmnd)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("CMND");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName).HasMaxLength(255);

                /*entity.HasOne(d => d.Account)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Student__Account__3D5E1FD2");*/
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.Leader)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeamName).HasMaxLength(225);

                entity.HasOne(d => d.LeaderNavigation)
                    .WithMany(p => p.TeamsNavigation)
                    .HasForeignKey(d => d.Leader)
                    .HasConstraintName("FK__Team__Leader__412EB0B6");

                entity.HasMany(d => d.Mssvs)
                    .WithMany(p => p.Teams)
                    .UsingEntity<Dictionary<string, object>>(
                        "StudentTeam",
                        l => l.HasOne<Student>().WithMany().HasForeignKey("Mssv").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__StudentTea__MSSV__44FF419A"),
                        r => r.HasOne<Team>().WithMany().HasForeignKey("TeamId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__StudentTe__TeamI__440B1D61"),
                        j =>
                        {
                            j.HasKey("TeamId", "Mssv").HasName("PK__StudentT__94F1DCE6767719F1");

                            j.ToTable("StudentTeam");

                            j.IndexerProperty<string>("Mssv").HasMaxLength(10).IsUnicode(false).HasColumnName("MSSV");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
