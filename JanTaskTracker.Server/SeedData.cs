using JanTaskTracker.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace JanTaskTracker.Server.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new JanTaskTrackerDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<JanTaskTrackerDbContext>>()))
            {
                // Check if data already exists
                if (context.Departments.Any() || context.Roles.Any() || context.Employees.Any() || context.Projects.Any() || context.ProjectTasks.Any())
                {
                    return; // Database has been seeded
                }

                // Seed Departments
                var departments = new[]
                {
                    new Department { DepartmentID = 0, DepartmentName = "Finance" },
                    new Department { DepartmentID = 1, DepartmentName = "Human Resources" },
                    new Department { DepartmentID = 2, DepartmentName = "Information Technology" }
                };

                context.Departments.AddRange(departments);

                // Seed Roles
                var roles = new[]
                {
                    new Role { RoleID = 0, RoleName = "Accountant", DepartmentID = 0 },
                    new Role { RoleID = 1, RoleName = "Financial Analyst", DepartmentID = 0 },
                    new Role { RoleID = 2, RoleName = "Finance Manager", DepartmentID = 0 },
                    new Role { RoleID = 3, RoleName = "HR Assistant", DepartmentID = 1 },
                    new Role { RoleID = 4, RoleName = "HR Specialist", DepartmentID = 1 },
                    new Role { RoleID = 5, RoleName = "HR Director", DepartmentID = 1 },
                    new Role { RoleID = 6, RoleName = "Software Engineer", DepartmentID = 2 },
                    new Role { RoleID = 7, RoleName = "Front-End Developer", DepartmentID = 2 },
                    new Role { RoleID = 8, RoleName = "Back-End Developer", DepartmentID = 2 },
                    new Role { RoleID = 9, RoleName = "Full-Stack Developer", DepartmentID = 2 }
                };

                context.Roles.AddRange(roles);

                // Seed Employees
                var employees = new[]
                {
                    new Employee { EmployeeID = 0, Name = "Bob Smith", Salary = 70000, DepartmentID = 0, RoleID = 1 },
                    new Employee { EmployeeID = 1, Name = "Catherine Green", Salary = 65000, DepartmentID = 1, RoleID = 4 },
                    new Employee { EmployeeID = 2, Name = "David Brown", Salary = 90000, DepartmentID = 2, RoleID = 6 }
                };

                context.Employees.AddRange(employees);

                // Seed Projects
                var projects = new[]
                {
                    new Project { ProjectId = 0, ProjectName = "Project Alpha", Description = "First project", Status = "Active", StartDate = new DateTime(2024, 11, 13), DueDate = new DateTime(2025, 11, 13) },
                    new Project { ProjectId = 1, ProjectName = "Project Beta", Description = "Second project", Status = "Active", StartDate = new DateTime(2024, 11, 13), DueDate = new DateTime(2025, 1, 13) }
                };

                context.Projects.AddRange(projects);

                // Seed ProjectTasks
                var projectTasks = new[]
                {
                    new ProjectTask { ProjectTaskId = 0, ProjectId = 0, Title = "Task 1", Description = "Task for Project Alpha", Status = "Completed", AssignedEmployeeId = 2, StartDate = new DateTime(2024, 11, 13), DueDate = new DateTime(2024, 12, 13) },
                    new ProjectTask { ProjectTaskId = 1, ProjectId = 0, Title = "Task 2", Description = "Another Task for Project Alpha", Status = "Active", AssignedEmployeeId = 2, StartDate = new DateTime(2024, 12, 13), DueDate = new DateTime(2025, 1, 13) },
                    new ProjectTask { ProjectTaskId = 2, ProjectId = 1, Title = "Task 3", Description = "Task for Project Beta", Status = "Completed", AssignedEmployeeId = 1, StartDate = new DateTime(2025, 1, 13), DueDate = new DateTime(2025, 2, 13) },
                    new ProjectTask { ProjectTaskId = 3, ProjectId = 1, Title = "Task 4", Description = "Another Task for Project Beta", Status = "Active", AssignedEmployeeId = 1, StartDate = new DateTime(2024, 11, 13), DueDate = new DateTime(2025, 2, 13) }
                };

                context.ProjectTasks.AddRange(projectTasks);

                // Save changes
                context.SaveChanges();
            }
        }
    }
}
