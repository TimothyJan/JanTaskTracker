using Microsoft.EntityFrameworkCore;
using JanTaskTracker.Server.Models;

namespace JanTaskTracker.Server.Repositories
{
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly JanTaskTrackerDbContext _context;

        public ProjectTaskRepository(JanTaskTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectTaskDTO>> GetAllProjectTasksAsync()
        {
            var tasks = await _context.ProjectTasks.ToListAsync();
            return tasks.Select(task => MapToDTO(task));
        }

        public async Task<ProjectTaskDTO> GetProjectTaskByIdAsync(int id)
        {
            var task = await _context.ProjectTasks.FindAsync(id);
            return task != null ? MapToDTO(task) : null;
        }

        public async Task CreateProjectTaskAsync(ProjectTaskDTO taskDto)
        {
            var task = MapToEntity(taskDto);
            await _context.ProjectTasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProjectTaskAsync(ProjectTaskDTO taskDto)
        {
            var task = await _context.ProjectTasks.FindAsync(taskDto.ProjectTaskId);
            if (task == null) return false;

            task = MapToEntity(taskDto, task);
            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProjectTaskAsync(int id)
        {
            var task = await _context.ProjectTasks.FindAsync(id);
            if (task == null) return false;

            _context.ProjectTasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<int>> GetProjectTaskIdsByProjectIdAsync(int projectId)
        {
            return await _context.ProjectTasks
                .Where(task => task.ProjectId == projectId)
                .Select(task => task.ProjectTaskId)
                .ToListAsync();
        }

        // Helper methods for mapping
        private ProjectTaskDTO MapToDTO(ProjectTask task)
        {
            return new ProjectTaskDTO
            {
                ProjectTaskId = task.ProjectTaskId,
                ProjectId = task.ProjectId,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                AssignedEmployeeId = task.AssignedEmployeeId,
                StartDate = task.StartDate,
                DueDate = task.DueDate
            };
        }

        private ProjectTask MapToEntity(ProjectTaskDTO dto, ProjectTask existingTask = null)
        {
            if (existingTask == null) existingTask = new ProjectTask();
            existingTask.ProjectTaskId = dto.ProjectTaskId;
            existingTask.ProjectId = dto.ProjectId;
            existingTask.Title = dto.Title;
            existingTask.Description = dto.Description;
            existingTask.Status = dto.Status;
            existingTask.AssignedEmployeeId = dto.AssignedEmployeeId;
            existingTask.StartDate = dto.StartDate;
            existingTask.DueDate = dto.DueDate;
            return existingTask;
        }

    }
}
