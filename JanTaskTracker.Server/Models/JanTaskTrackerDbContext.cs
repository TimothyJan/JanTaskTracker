using Microsoft.EntityFrameworkCore;
using JanTaskTracker.Server.Models;

namespace JanTaskTracker.Server
{
    public class JanTaskTrackerDbContext: DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }

        public JanTaskTrackerDbContext(DbContextOptions<JanTaskTrackerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees) // Navigation property for Employees
                .HasForeignKey(e => e.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes for Departments

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany(r => r.Employees) // Ensure Role has navigation property for Employees
                .HasForeignKey(e => e.RoleID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes for Roles

            modelBuilder.Entity<Employee>().Property(e => e.Salary).HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Role>()
                .HasOne(r => r.Department)
                .WithMany(d => d.Roles) // Ensure Department has navigation property for Roles
                .HasForeignKey(r => r.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes for Roles

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjectId);
                entity.Property(e => e.ProjectName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<ProjectTask>(entity =>
            {
                entity.HasKey(e => e.ProjectTaskId);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50);

                entity.HasOne<Employee>()
                      .WithMany()
                      .HasForeignKey(e => e.AssignedEmployeeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Seed data
            SeedData.ApplySeedData(modelBuilder);
        }
    }
}
