using JanTaskTracker.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JanTaskTracker.Server.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task CreateProjectAsync(Project project);
        Task<bool> UpdateProjectAsync(Project project);
        Task<bool> DeleteProjectAsync(int id);
        Task<IEnumerable<int>> GetAllProjectIdsAsync();
    }
}