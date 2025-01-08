﻿// <auto-generated />
using System;
using JanTaskTracker.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JanTaskTracker.Server.Migrations
{
    [DbContext(typeof(JanTaskTrackerDbContext))]
    partial class JanTaskTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JanTaskTracker.Server.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentID = 1,
                            DepartmentName = "Finance"
                        },
                        new
                        {
                            DepartmentID = 2,
                            DepartmentName = "Human Resources"
                        },
                        new
                        {
                            DepartmentID = 3,
                            DepartmentName = "Information Technology"
                        });
                });

            modelBuilder.Entity("JanTaskTracker.Server.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("RoleID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            DepartmentID = 1,
                            Name = "Bob Smith",
                            RoleID = 2,
                            Salary = 70000m
                        },
                        new
                        {
                            EmployeeID = 2,
                            DepartmentID = 2,
                            Name = "Catherine Green",
                            RoleID = 5,
                            Salary = 65000m
                        },
                        new
                        {
                            EmployeeID = 3,
                            DepartmentID = 3,
                            Name = "David Brown",
                            RoleID = 7,
                            Salary = 90000m
                        });
                });

            modelBuilder.Entity("JanTaskTracker.Server.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            Description = "First project",
                            DueDate = new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectName = "Project Alpha",
                            StartDate = new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Active"
                        },
                        new
                        {
                            ProjectId = 2,
                            Description = "Second project",
                            DueDate = new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectName = "Project Beta",
                            StartDate = new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Active"
                        });
                });

            modelBuilder.Entity("JanTaskTracker.Server.Models.ProjectTask", b =>
                {
                    b.Property<int>("ProjectTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectTaskId"));

                    b.Property<int>("AssignedEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProjectTaskId");

                    b.HasIndex("AssignedEmployeeId");

                    b.ToTable("ProjectTasks");

                    b.HasData(
                        new
                        {
                            ProjectTaskId = 1,
                            AssignedEmployeeId = 3,
                            Description = "Task for Project Alpha",
                            DueDate = new DateTime(2024, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectId = 1,
                            StartDate = new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Completed",
                            Title = "Task 1"
                        },
                        new
                        {
                            ProjectTaskId = 2,
                            AssignedEmployeeId = 3,
                            Description = "Another Task for Project Alpha",
                            DueDate = new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectId = 1,
                            StartDate = new DateTime(2024, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Active",
                            Title = "Task 2"
                        },
                        new
                        {
                            ProjectTaskId = 3,
                            AssignedEmployeeId = 2,
                            Description = "Task for Project Beta",
                            DueDate = new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectId = 2,
                            StartDate = new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Completed",
                            Title = "Task 3"
                        },
                        new
                        {
                            ProjectTaskId = 4,
                            AssignedEmployeeId = 2,
                            Description = "Another Task for Project Beta",
                            DueDate = new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectId = 2,
                            StartDate = new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Active",
                            Title = "Task 4"
                        });
                });

            modelBuilder.Entity("JanTaskTracker.Server.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            DepartmentID = 1,
                            RoleName = "Accountant"
                        },
                        new
                        {
                            RoleID = 2,
                            DepartmentID = 1,
                            RoleName = "Financial Analyst"
                        },
                        new
                        {
                            RoleID = 3,
                            DepartmentID = 1,
                            RoleName = "Finance Manager"
                        },
                        new
                        {
                            RoleID = 4,
                            DepartmentID = 2,
                            RoleName = "HR Assistant"
                        },
                        new
                        {
                            RoleID = 5,
                            DepartmentID = 2,
                            RoleName = "HR Specialist"
                        },
                        new
                        {
                            RoleID = 6,
                            DepartmentID = 2,
                            RoleName = "HR Director"
                        },
                        new
                        {
                            RoleID = 7,
                            DepartmentID = 3,
                            RoleName = "Software Engineer"
                        },
                        new
                        {
                            RoleID = 8,
                            DepartmentID = 3,
                            RoleName = "Front-End Developer"
                        },
                        new
                        {
                            RoleID = 9,
                            DepartmentID = 3,
                            RoleName = "Back-End Developer"
                        },
                        new
                        {
                            RoleID = 10,
                            DepartmentID = 3,
                            RoleName = "Full-Stack Developer"
                        });
                });

            modelBuilder.Entity("JanTaskTracker.Server.Models.Employee", b =>
                {
                    b.HasOne("JanTaskTracker.Server.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JanTaskTracker.Server.Models.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("JanTaskTracker.Server.Models.ProjectTask", b =>
                {
                    b.HasOne("JanTaskTracker.Server.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("AssignedEmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("JanTaskTracker.Server.Models.Role", b =>
                {
                    b.HasOne("JanTaskTracker.Server.Models.Department", "Department")
                        .WithMany("Roles")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("JanTaskTracker.Server.Models.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("JanTaskTracker.Server.Models.Role", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
