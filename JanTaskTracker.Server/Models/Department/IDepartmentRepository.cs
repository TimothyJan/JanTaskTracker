﻿
namespace JanTaskTracker.Server.Models
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();
        Task<DepartmentDTO> GetDepartmentByIdAsync(int id);
        Task AddDepartmentAsync(DepartmentDTO departmentDto);
        Task UpdateDepartmentAsync(DepartmentDTO departmentDto);
        Task DeleteDepartmentAsync(int id);
    }
}
